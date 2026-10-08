using System.Numerics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created



    private Rigidbody2D rb;
    public float jumpForce = 10f;
    public float Preasure = 0f;
    public bool Held = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Held == true)
        {
            Debug.Log("Let it gooooo");
            jumpForce = 10f + Preasure;
            Bounce();
            jumpForce = 10f;
            Held = false;

        }
    }
     void OnCollisionEnter2D(Collision2D collision)
    {
        // Check what we hit using the collision data
        Debug.Log("Collided with: " + collision.gameObject.name);

        // Check if the hit object has a specific tag
        if (collision.gameObject.CompareTag("Bouncable") && !Input.GetKey(KeyCode.Space))
        {
            Bounce();
        }
    }
    void Bounce()
    {
        rb.AddForce(new UnityEngine.Vector2(0f, jumpForce), ForceMode2D.Impulse);
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("Stay Collision with: " + collision.gameObject.name);
        
        if (Input.GetKey(KeyCode.Space))
        {
            Held = true;
            jumpForce = 0f;
            Preasure += 1f;
        }

    }

}
