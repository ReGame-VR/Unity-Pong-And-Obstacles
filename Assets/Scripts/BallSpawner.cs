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
        ball.transform.localScale = new Vector3(1, 1, 1);
        initialImpulse = ball.GetComponent<BallBehavior>().initialImpulse;
        initialImpulse = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // If "U" is pressed, next ball spawned will be slow.
        if (Input.GetKeyUp(KeyCode.U))
        {
            initialImpulse = new Vector3(Random.Range(2.0f, 3.0f), 0, Random.Range(2.0f, 3.0f));
            Debug.Log("Next ball will spawn at slow speed.");
        }
        // If "I" is pressed, next ball spawned will be medium-speed.
        if (Input.GetKeyUp(KeyCode.I))
        {
            initialImpulse = new Vector3(Random.Range(3.0f, 6.0f), 0, Random.Range(3.0f, 6.0f));
            Debug.Log("Next ball will spawn at medium speed.");
        }
        // If "O" is pressed, next ball spawned will be fast.
        if (Input.GetKeyUp(KeyCode.O))
        {
            initialImpulse = new Vector3(Random.Range(6.0f, 10.5f), 0, Random.Range(6.0f, 10.5f));
            Debug.Log("Next ball will spawn at fast speed.");
        }
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
