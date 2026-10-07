using UnityEngine;
using UnityEngine.UI;

public class LifesUI : MonoBehaviour
{
    [SerializeField] private Sprite[] statesHeart = new Sprite[3];
    [SerializeField] private Lifes lifes;
    [SerializeField] private Image[] heartImages = new Image[3];
    void OnEnable()
    {
        lifes.onChangeQuantLife += UpdateUI;
        UpdateUI(lifes.currLife);
    }

    void changeHeartState( int indexState,  int indexImage)
    {
        Debug.Log("INDEX STATE " +  indexState + 1+"INDEX IMAGE" + indexImage);
        heartImages[indexImage].sprite = statesHeart[indexState  % 2  == 0? 2 : 1];
        if(indexState + 1 == 1 && indexImage < 2) heartImages[indexImage + 1].sprite = statesHeart[0];
    }

    void OnDisable()
    {
        lifes.onChangeQuantLife -= UpdateUI;
    }

    void UpdateUI(int value)
    {
        //2,4,6 //corações cheios
        //6 -> 0
        //5 -> 1 
        changeHeartState(value % 2  , Mathf.CeilToInt(value / 2f) - 1);
        //1,2,3  //index objetos
        //1,2|3,4|5,6
        Debug.Log("Vidas: " + value);
        Debug.Log("Vidas dividida: " + Mathf.CeilToInt(value / 2f));
    }
}
