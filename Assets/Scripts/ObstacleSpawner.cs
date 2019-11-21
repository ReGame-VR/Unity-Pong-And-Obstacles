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
    // enum for choosing obstacle speed, NULL if obstacles do not spawn on this level
    public enum ObstacleSpeed { NULL, Slow, Fast, Random };
    // Floats representing the obstacle's Speed, and rotation along each axis
    float speed, rotX, rotY, rotZ;

    // Start is called before the first frame update
    void Start()
    {
        spawnpoints = GameObject.FindGameObjectsWithTag("ObstacleSpawn");
    }

    // Spawns an obstacle based on provided information from LevelController.cs
    public void SpawnObstacle(ObstacleSpeed obsSpeed)
    {
        // If the level has not reached the maximum number of obstacles and obstacles should be spawned
        if (currObs < maxObs && !obsSpeed.Equals(ObstacleSpeed.NULL))
        {
            Vector3 chosenSpawn = spawnpoints[Random.Range(0, spawnpoints.Length)].gameObject.transform.position;
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
            obstacle.GetComponent<ObstacleBehavior>().rotX = rotX;
            obstacle.GetComponent<ObstacleBehavior>().rotY = rotY;
            obstacle.GetComponent<ObstacleBehavior>().rotZ = rotZ;
            Instantiate(obstacle, chosenSpawn, Quaternion.identity);
            currObs += 1;
        }
    }
}
