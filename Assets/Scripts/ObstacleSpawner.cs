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

        }
        if (Input.GetKeyUp(KeyCode.X))
        {

        }
        if (Input.GetKeyUp(KeyCode.C))
        {

        }
        if (Input.GetKeyUp(KeyCode.LeftShift) && currObs < maxObs)
        {
            Vector3 chosenSpawn = spawnpoints[Random.Range(0, 3)].gameObject.transform.position;
            currObs += 1;
            

        }
    }
}
