using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private Animator animator;
    private int hits = 0;

    void Start()
    {
        animator = GetComponent<Animator>();
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
}