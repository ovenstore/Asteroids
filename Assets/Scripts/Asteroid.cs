using UnityEditor.Callbacks;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float speed;
    public float xBound;
    public float yBound;
    public GameObject mediumAsteroid;
    public GameObject smallAsteroid;
    private Rigidbody2D rb;
    private Animator animator;
    private int hits = 0;
    private int size = 1;

    void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (rb.position.x < -xBound || rb.position.x > xBound || rb.position.y < -yBound || rb.position.y > yBound)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Bullet"))
        {
            Destroy(collider.gameObject);

            hits++;

            animator.SetInteger("Hits", hits);
        } 
    }

    public void DestroyAsteroid()
    {
        Destroy(gameObject);
    }

    void BreakApart()
    {
        Asteroid asteroid1;
        Asteroid asteroid2;

        int setSize;

        // get two opposite random directions
        Vector2 direction1 = Random.insideUnitCircle.normalized;
        Vector2 direction2 = -direction1;

        switch(size)
        {
            case 1:     // small asteroids don't break apart
                return;
            
            case 2:
                asteroid1 = Instantiate(smallAsteroid, rb.position, Quaternion.identity).GetComponent<Asteroid>();
                asteroid2 = Instantiate(smallAsteroid, rb.position, Quaternion.identity).GetComponent<Asteroid>();
                
                setSize = 1;

                break;
            
            case 3:
                asteroid1 = Instantiate(mediumAsteroid, rb.position, Quaternion.identity).GetComponent<Asteroid>();
                asteroid2 = Instantiate(mediumAsteroid, rb.position, Quaternion.identity).GetComponent<Asteroid>();

                setSize = 2;

                break;
            
            // this is necessary in case asteroid is unassigned, we can't call SetDirection() and SetSize() if it's unassigned
            default:
                Debug.Log("Something bad happened...");
                return;
        }

        asteroid1.SetDirection(direction1);
        asteroid1.SetSize(setSize);
        asteroid1.SetHits(1);

        asteroid2.SetDirection(direction2);
        asteroid2.SetSize(setSize);
        asteroid2.SetHits(1);
    }

    // set certain values externally when an asteroid is instantiated
    public void SetDirection(Vector2 setDirection)
    {
        rb.linearVelocity = setDirection.normalized * speed;
    }

    public void SetSize(int setSize)
    {
        size = setSize;
    }

    public void SetHits(int setHits)
    {
        hits = setHits;
    }
}