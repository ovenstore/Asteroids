using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject largeAsteroid;
    public GameObject mediumAsteroid;
    public GameObject smallAsteroid;
    public int xBound;
    public int yBound;
    public int odds;

    void Start()
    {
        
    }

    void FixedUpdate()
    {   
        // need a better way to spawn in asteroids
        if (Random.Range(1, odds+1) == 1)
        {
            SpawnAsteroid();
        }
    }

    // spawns an asteroid of a random size
    void SpawnAsteroid()
    {
        int random = Random.Range(1, 4);

        Vector2 startingPoint = GetStartingPoint();

        Asteroid asteroid;
        
        int size = 0;

        switch(random)
        {
            case 1:
                asteroid = Instantiate(largeAsteroid, startingPoint, Quaternion.identity).GetComponent<Asteroid>();
                size = 3;
                break;
            
            case 2:
                asteroid = Instantiate(mediumAsteroid, startingPoint, Quaternion.identity).GetComponent<Asteroid>();
                size = 2;
                break;
            
            case 3:
                asteroid = Instantiate(smallAsteroid, startingPoint, Quaternion.identity).GetComponent<Asteroid>();
                size = 1;
                break;

            // this is necessary in case asteroid is unassigned, we can't call SetDirection() and SetSize() if it's unassigned
            default:
                return;
        }

        // setting the direction to (0,0) - (starting point) will point the asteroid towards (0,0)
        Vector2 direction = Vector2.zero - startingPoint;

        asteroid.SetDirection(direction);

        // set the asteroid size variable so that it knows its own size
        asteroid.SetSize(size);
    }

    // randomly selects a side of the screen and gets a random corresponding x/y coordinate, returns a vector
    Vector2 GetStartingPoint()
    {
        int random = Random.Range(1, 5);
        int x = 0;
        int y = 0;

        switch(random)
        {
            case 1:
                x = -xBound;
                y = Random.Range(-yBound, yBound);
                break;
            
            case 2:
                x = xBound;
                y = Random.Range(-yBound, yBound);
                break;
            
            case 3:
                x = Random.Range(-xBound, xBound);
                y = yBound;
                break;
            
            case 4:
                x = Random.Range(-xBound, xBound);
                y = -yBound;
                break;
        }

        return new Vector2(x, y);
    }
}
