using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 3f;

    private Rigidbody2D rb;
    private bool isMovingRight = true;
    private bool isMovingUp = true;
    public bool isY_Axis = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isY_Axis)
        {
            UpMove();
        }
        else
        {
            RightMove();
        }
    }

    void UpMove()
    {
        if (isMovingUp)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, moveSpeed);
        }
        else
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, -moveSpeed);
        }
    }

    void RightMove()
    {
        if (isMovingRight)
        {
            rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y);
        }
        else
        {
            rb.linearVelocity = new Vector2(-moveSpeed, rb.linearVelocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Boundary"))
        {
            if (isY_Axis)
            {
                isMovingUp = !isMovingUp;
            }
            else
            {
                isMovingRight = !isMovingRight;
            }
        }
    }

}
