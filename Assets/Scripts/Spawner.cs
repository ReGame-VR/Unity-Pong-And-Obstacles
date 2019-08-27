using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Script to manage spawning in balls, their speed and size, and general
 * other spawning-related applications.
 */
public class Spawner : MonoBehaviour
{
    // GameObject reference to Ball prefab
    public GameObject ball;
    // Ints for tracking current number of balls and max total number.
    public int currBalls, maxBalls;
    // List containing all Spawnpoints for balls.
    public GameObject[] spawnpoints;
    // Start is called before the first frame update
    void Start()
    {
        spawnpoints = GameObject.FindGameObjectsWithTag("Spawn");
    }

    // Update is called once per frame
    void Update()
    {
        // If "U" is pressed, next ball spawned will be slow.
        if (Input.GetKeyUp(KeyCode.U))
        {
            ball.GetComponent<BallBehavior>().initialImpulse = new Vector3(Random.Range(2.0f, 3.0f), 0, Random.Range(2.0f, 3.0f));
            Debug.Log("Next ball will spawn at slow speed.");
        }
        // If "I" is pressed, next ball spawned will be medium-speed.
        if (Input.GetKeyUp(KeyCode.I))
        {
            ball.GetComponent<BallBehavior>().initialImpulse = new Vector3(Random.Range(3.0f, 6.0f), 0, Random.Range(3.0f, 6.0f));
            Debug.Log("Next ball will spawn at medium speed.");
        }
        // If "O" is pressed, next ball spawned will be fast.
        if (Input.GetKeyUp(KeyCode.O))
        {
            ball.GetComponent<BallBehavior>().initialImpulse = new Vector3(Random.Range(6.0f, 10.5f), 0, Random.Range(6.0f, 10.5f));
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
            ball.transform.localScale = new Vector3(1, 1, 1);
            Debug.Log("Next ball will spawn at medium size.");
        }
        // If "L" is pressed, next ball spawned will be large.
        if (Input.GetKeyUp(KeyCode.L))
        {
            ball.transform.localScale = new Vector3(2, 2, 2);
            Debug.Log("Next ball will spawn at large size.");
        }
        // Spawns a ball with current specifics and adds it to balls list.
        if (Input.GetKeyUp(KeyCode.Space) && currBalls< maxBalls)
        {
            Vector3 chosenSpawn = spawnpoints[Random.Range(0, 3)].gameObject.transform.position;
            currBalls += 1;
            Debug.Log("Spawned ball at " + chosenSpawn);
            Instantiate(ball, chosenSpawn, Quaternion.identity);
        }
    }
}
