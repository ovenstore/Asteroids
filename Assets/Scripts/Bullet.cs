using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float xBound;
    public float yBound;
    void FixedUpdate()
    {
        transform.position += speed * Time.deltaTime * transform.up;

        if (transform.position.x < -xBound || transform.position.x > xBound || transform.position.y < -yBound || transform.position.y > yBound)
        {
            Destroy(gameObject);
        }
    }
}
