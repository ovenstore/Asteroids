using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]


public class Player : MonoBehaviour
{
    public float speed;
    private bool moveForward = false;
    public float rotationSpeed;
    private float rotation = 0f;
    public float xBound;
    public float yBound;
    private Rigidbody2D rb;
    public GameObject bullet;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() 
    {
        if (moveForward) {
            rb.AddForce(transform.up * speed);
        } 

        rb.rotation -= rotation * rotationSpeed;

        ScreenWrap();        
    }

    void OnForward(InputValue input) 
    {
        moveForward = input.isPressed;
    }

    void OnTurn(InputValue input)
    {
        rotation = input.Get<float>();
    }

    void OnShoot()
    {
        Instantiate(bullet, rb.position, transform.rotation);
    }

    void ScreenWrap()
    {
        if (rb.position.x < -xBound)
        {
            rb.position = new Vector2(xBound, rb.position.y);
        }
        
        if (rb.position.x > xBound)
        {
            rb.position = new Vector2(-xBound, rb.position.y);
        }
        
        if (rb.position.y < -yBound)
        {
            rb.position = new Vector2(rb.position.x, yBound);
        }
        
        if (rb.position.y > yBound)
        {
            rb.position = new Vector2(rb.position.y, -yBound);
        }
    }
}
