using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    // Gameobject reference to Obstacle prefab
    public GameObject obstacle;
    // Ints for tracking current number of obstacles and max total number
    public int currObs, maxObs;
    // array of GameObjects containing all Spawnpoints for obstacles
    public GameObject[] spawnpoints;
    // Vector3 denoting position of the chosen spawnpoint for the newest obstacle
    private Vector3 chosenSpawn;
    // enum for choosing obstacle speed, NULL if obstacles do not spawn on this level
    public enum ObstacleSpeed { NULL, Slow, Fast, Random };
    // Floats representing the obstacle's Speed, and its rotation along each axis
    private float speed, rotX, rotY, rotZ;
    // Floats for randomization of speed value
    public float speedSlowMin, speedSlowMax, speedFastMin, speedFastMax;

    // Start is called before the first frame update
    void Start()
    {
        spawnpoints = GameObject.FindGameObjectsWithTag("ObstacleSpawn");
    }

    // Resets obstacle prefab values
    void ResetObstacle()
    {
        obstacle.GetComponent<ObstacleBehavior>().rotX = 0;
        obstacle.GetComponent<ObstacleBehavior>().rotY = 0;
        obstacle.GetComponent<ObstacleBehavior>().rotZ = 0;
        obstacle.GetComponent<ObstacleBehavior>().speed = 0;
    }

    // Spawns an obstacle based on provided information from LevelController.cs
    public void SpawnObstacle(ObstacleSpeed obsSpeed)
    {
        // If the level has not reached the maximum number of obstacles and obstacles should be spawned
        if (currObs < maxObs && !obsSpeed.Equals(ObstacleSpeed.NULL))
        {
            SpawnPointAndRotation();
            obstacle.GetComponent<ObstacleBehavior>().rotX = rotX;
            obstacle.GetComponent<ObstacleBehavior>().rotY = rotY;
            obstacle.GetComponent<ObstacleBehavior>().rotZ = rotZ;
            obstacle.GetComponent<ObstacleBehavior>().speed = speed;
            Instantiate(obstacle, chosenSpawn, Quaternion.identity);
            currObs += 1;
        }
    }

    void SpawnPointAndRotation()
    {
        int choice = Random.Range(0, spawnpoints.Length - 1);
        Debug.Log(choice);
        chosenSpawn = spawnpoints[choice].gameObject.transform.position;
        // Makes the obstacle rotate toward the player as it flies through the air
        if (chosenSpawn.x < 0)
        {
            rotY = Random.Range(5f, 40f);
            rotZ = Random.Range(5f, 40f);
        }
        else
        {
            rotY = Random.Range(-40f, -5f);
            rotZ = Random.Range(-40f, -5f);
        }
        rotX = Random.Range(5f, 40f);
    }

    void SetSpeed(ObstacleSpeed obsSpeed)
    {
        if (obsSpeed.Equals(ObstacleSpeed.Slow))
        {
            speed = Random.Range(speedSlowMin, speedSlowMax);
        }
        if (obsSpeed.Equals(ObstacleSpeed.Fast))
        {
            speed = Random.Range(speedFastMin, speedFastMax);
        }
        if (obsSpeed.Equals(ObstacleSpeed.Random))
        {
            speed = Random.Range(speedSlowMin, speedFastMax);
        }
    }
}
