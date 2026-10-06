using UnityEngine;

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
            if(horizontal < 0)
            {
                spriteRenderer.flipX = true;
            } else
            {
                spriteRenderer.flipX = false;
            }
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
        lifes.TakeDamage();
        transform.position = startPoint.transform.position;
    }
}
