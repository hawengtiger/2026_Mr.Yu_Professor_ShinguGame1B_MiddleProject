using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

/// <summary>
/// === | 플레이어 움직임. | ===
/// </summary>
public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// | public 변수 | =====================
    /// </summary>
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public string nextScene;

    public Animator animator;

    public float itemSpeed = 4f;

    public bool item = false;

    /// <summary>
    /// | private 변수 | =====================
    /// </summary>
    private Rigidbody2D rb;
    private bool isGrounded;
    private float moveInput;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        if (rb.linearVelocity.x != 0)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }

    }

    public void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        moveInput = input.x;
    }

    public void OnJump(InputValue value)
    {
        if (value.isPressed && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (item) return;

        if (collision.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Reset"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (collision.CompareTag("Speed"))
        {
            moveSpeed = itemSpeed;
            SoundManager.Instance.PlaySFX("Item");
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Item"))
        {
            item = true;
            SoundManager.Instance.PlaySFX("Item");
            Destroy(collision.gameObject);

        }

        if (collision.CompareTag("Flag"))
        {
            collision.GetComponent<Level>().MovetoLevel();
        }
    }
}
