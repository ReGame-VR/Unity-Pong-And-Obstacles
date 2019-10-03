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
    // Floats representing the obstacle's Speed, and rotation along each axis
    float speed, rotX, rotY, rotZ;

    // Start is called before the first frame update
    void Start()
    {
        spawnpoints = GameObject.FindGameObjectsWithTag("ObstacleSpawn");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Z))
        {
            Debug.Log("Z");
        }
        if (Input.GetKeyUp(KeyCode.X))
        {
            Debug.Log("X");
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            Debug.Log("C");
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) && currObs < maxObs)
        {
            Vector3 chosenSpawn = spawnpoints[Random.Range(0, spawnpoints.Length)].gameObject.transform.position;
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
            currObs += 1;
            Instantiate(obstacle, chosenSpawn, Quaternion.identity);
        }
    }
}
