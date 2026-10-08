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
        heartImages[indexImage].sprite = statesHeart[indexState  % 2  == 0? 1: 2];
        if(indexState + 1 == 1 && indexImage < 2) heartImages[indexImage + 1].sprite = statesHeart[0];
    }

    void OnDisable()
    {
        lifes.onChangeQuantLife -= UpdateUI;
    }

    void UpdateUI(int value)
    {
        changeHeartState(value % 2  , Mathf.CeilToInt(value / 2f) - 1);
    }
}
