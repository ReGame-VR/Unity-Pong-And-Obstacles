using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Script to manage spawning in balls, their speed and size, and general
 * other spawning-related applications.
 */
public class BallSpawner : MonoBehaviour
{
    // GameObject reference to Ball prefab
    public GameObject ball;
    // enum to decide the size of each new spawned ball
    public enum BallSize {Small, Medium, Large};
    // public floats for easily changing each BallSize's actual scale modifier
    public float smallScale, medScale, largeScale;
    // enum to decide the speed of each new spawned ball
    public enum BallSpeed { Slow, Medium, Fast };
    // public Vector3's for easily changing each BallSpeed's actual speed modifier,
    // with max and min because there is some randomization each time
    public float slowSpeedMin, slowSpeedMax, medSpeedMin, medSpeedMax, fastSpeedMin, fastSpeedMax;
    // Ints for tracking current number of balls and max total number.
    public int currBalls, maxBalls;
    // Ints to randomly choose left/right and down/up direction (-1 or 1)
    int horizDirection, vertDirection;
    // Array of GameObjects containing all Spawnpoints for balls.
    public GameObject[] spawnpoints;
    // Vector3 referring to ball's initialImpulse field
    Vector3 initialImpulse;

    // Start is called before the first frame update
    void Start()
    {
        spawnpoints = GameObject.FindGameObjectsWithTag("BallSpawn");
        initialImpulse = ball.GetComponent<BallBehavior>().initialImpulse;
        ResetBallPrefab();
    }

    // Resets the ball prefab to default for next ball spawning
    void ResetBallPrefab()
    {
        ball.transform.localScale = new Vector3(1, 1, 1);
        initialImpulse = new Vector3(0, 0, 0);
    }

    // Spawns ball with given difficulty parameters
    void SpawnBall(BallSize size, BallSpeed speed)
    {
        SetSpeed(speed);

    }

    // Sets up initialImpulse to properly reflect the selected BallSpeed
    void SetSpeed(BallSpeed speed)
    {
        if (speed.Equals(BallSpeed.Slow))
        {
            initialImpulse = new Vector3(Random.Range(slowSpeedMin, slowSpeedMax), 0, Random.Range(slowSpeedMin, slowSpeedMax));
        }
        if (speed.Equals(BallSpeed.Medium))
        {
            initialImpulse = new Vector3(Random.Range(medSpeedMin, medSpeedMax), 0, Random.Range(medSpeedMin, medSpeedMax));
        }
        if (speed.Equals(BallSpeed.Fast))
        {
            initialImpulse = new Vector3(Random.Range(fastSpeedMin, fastSpeedMax), 0, Random.Range(fastSpeedMin, fastSpeedMax));
        }
    }

    void SetSize(BallSize size)
    {
        if (size.Equals(BallSize.Small))
        {
            ball.transform.localScale = new Vector3(smallScale, smallScale, smallScale);
        }
        if (size.Equals(BallSize.Medium))
        {
            ball.transform.localScale = new Vector3(medScale, medScale, medScale);
        }
        if (size.Equals(BallSize.Large))
        {
            ball.transform.localScale = new Vector3(smallScale, smallScale, smallScale);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // If "J" is pressed, next ball spawned will be small.
        if (Input.GetKeyUp(KeyCode.J))
        {
            ball.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            Debug.Log("Next ball will spawn at small size.");
        }
        // If "K" is pressed, next ball spawned will be medium-sized.
        if (Input.GetKeyUp(KeyCode.K))
        {
            ball.transform.localScale = new Vector3(.6f, .6f, .6f);
            Debug.Log("Next ball will spawn at medium size.");
        }
        // If "L" is pressed, next ball spawned will be large.
        if (Input.GetKeyUp(KeyCode.L))
        {
            ball.transform.localScale = new Vector3(.85f, .85f, .85f);
            Debug.Log("Next ball will spawn at large size.");
        }
        // Spawns a ball with current specifics and adds it to balls list.
        if (Input.GetKeyUp(KeyCode.RightShift) && currBalls < maxBalls && initialImpulse != new Vector3(0, 0, 0))
        {
            Vector3 chosenSpawn = spawnpoints[Random.Range(0, spawnpoints.Length)].gameObject.transform.position;
            currBalls += 1;
            Debug.Log("Spawned ball at " + chosenSpawn);
            horizDirection = Random.Range(0, 2) * 2 - 1;
            vertDirection = Random.Range(0, 2) * 2 - 1;
            initialImpulse = new Vector3(initialImpulse.x * horizDirection, initialImpulse.y, initialImpulse.z * vertDirection);
            ball.GetComponent<BallBehavior>().initialImpulse = initialImpulse;
            Instantiate(ball, chosenSpawn, Quaternion.identity);
        }
    }
}
