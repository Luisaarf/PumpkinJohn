using UnityEngine;
using UnityEngine.SceneManagement;

public class PumpkinJohn : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public Lifes lifes;
    public GameObject startPoint;
    public float walkSpeed = 5.0f;
    public float jumpForce = 5.0f;
    public bool isOnGround = true;
    private float horizontal = 0.0f;
    private bool makeJump = false;

    private bool hasKey = false;

    void Awake()
    {
        lifes = GetComponent<Lifes>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        rb.freezeRotation = true; 
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        if(horizontal != 0) {
            animator.SetBool("IsWalking", true);
        }else
        {
            animator.SetBool("IsWalking", false);
        }
        if(Input.GetKey(KeyCode.Space) && isOnGround) {
            makeJump = true;
            animator.SetTrigger("isJumping");
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * walkSpeed, rb.linearVelocity.y);
        if (makeJump)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            makeJump = false;
        }
    }

    void OnBecameInvisible()
    {
         if (startPoint == null) return;
        lifes.TakeDamage();
        transform.position = startPoint.transform.position;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Key")){
            hasKey = false;
            collision.gameObject.SetActive(false);
        }    
        if(collision.gameObject.CompareTag("Door") && hasKey) SceneManager.LoadScene("GameOver");
    }
}
