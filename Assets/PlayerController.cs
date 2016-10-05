using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float walkSpeed = 2.0f;
    [SerializeField]
    private float jumpPower = 700.0f;
    [SerializeField]
    private LayerMask groundLayer;

    private Animator playerAnim;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb2D;

    private bool moveRight;
    private bool moveLeft;
    private bool moveJump;
    private bool isGrounded;
    private bool flipX;

    void Start() {
        playerAnim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update() {
        isGrounded = Physics2D.Linecast(
                transform.position + transform.up * 1,
                transform.position - transform.up * 0.05f,
                groundLayer);

        if (Input.GetKey(KeyCode.RightArrow)) {
            moveRight = true;
        } else {
            moveRight = false;
        }

        if (Input.GetKey(KeyCode.LeftArrow)) {
            moveLeft = true;
        } else {
            moveLeft = false;
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            if (isGrounded == true) {
                isGrounded = false;
                rb2D.AddForce(Vector2.up * jumpPower);
            }
        }
    }

    void FixedUpdate() {
        if (moveRight == true) {
            spriteRenderer.flipX = false;
            rb2D.velocity = new Vector2(walkSpeed, rb2D.velocity.y);
            playerAnim.SetBool("Walk", true);
        } else if (moveLeft == true) {
            spriteRenderer.flipX = true;
            rb2D.velocity = new Vector2(-walkSpeed, rb2D.velocity.y);
            playerAnim.SetBool("Walk", true);
        } else {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
            playerAnim.SetBool("Walk", false);
        }
    }
}