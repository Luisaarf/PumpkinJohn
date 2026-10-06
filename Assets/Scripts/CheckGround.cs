using UnityEngine;

public class CheckGround : MonoBehaviour
{
    private PumpkinJohn pumpkinJohn;
    void Start()
    {
        pumpkinJohn = GetComponentInParent<PumpkinJohn>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            pumpkinJohn.isOnGround = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            pumpkinJohn.isOnGround = false;
        }
    }
}
