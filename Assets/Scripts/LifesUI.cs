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

    void changeHeartState( int indexState,  Image image)
    {
        image.sprite = statesHeart[indexState];
    }

    void OnDisable()
    {
        lifes.onChangeQuantLife -= UpdateUI;
    }

    void UpdateUI(int value)
    {
        //2,4,6
        //1,2,3
        Debug.Log("Vidas: " + value);
    }
}
