using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float jumpForce = 10f;
    public float pressure = 0f;
    public bool held = false;

    private Vector2 lockedPosition;
    public float rotationSpeed = 400f;
    private bool isGrounded = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (held == true)
        {
            pressure += 10f * Time.deltaTime;

            if (Input.GetKeyUp(KeyCode.Space) || pressure > 10)
            {
                jumpForce = 10f + pressure;
                Bounce();
                jumpForce = 10f;
                held = false;
                pressure = 0f;
                isGrounded = false;
            }
        }
        float input = Input.GetAxis("Horizontal");
        transform.Rotate(0, 0, -input * rotationSpeed * Time.deltaTime);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collided with: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Bouncable"))
        {
            isGrounded = true;

            if (!Input.GetKey(KeyCode.Space) && held == false)
            {
                Bounce();
            }
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bouncable"))
        {
            isGrounded = false;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("Stay Collision with: " + collision.gameObject.name);


        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            held = true;
            jumpForce = 0f;
        }
    }

    void Bounce()
    {
        rb.linearVelocity = Vector2.zero;
        rb.AddForce((Vector2)transform.up * jumpForce, ForceMode2D.Impulse);
    }
    public float getPressure()
    {
        return pressure;
    }
}


