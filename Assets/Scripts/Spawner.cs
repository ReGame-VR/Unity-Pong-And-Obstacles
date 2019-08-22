using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject ball;
    private int numBalls;
    // Start is called before the first frame update
    void Start()
    {
        numBalls = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.U))
        {
            ball.GetComponent<BallBehavior>().initialImpulse = new Vector3(2.5f, 0, 3);
            Debug.Log("Next ball will spawn at slow speed.");
        }
        if (Input.GetKeyUp(KeyCode.I))
        {
            ball.GetComponent<BallBehavior>().initialImpulse = new Vector3(5, 0, 5);
            Debug.Log("Next ball will spawn at medium speed.");
        }
        if (Input.GetKeyUp(KeyCode.O))
        {
            ball.GetComponent<BallBehavior>().initialImpulse = new Vector3(7, 0, 9);
            Debug.Log("Next ball will spawn at fast speed.");
        }
        if (Input.GetKeyUp(KeyCode.J))
        {
            ball.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            Debug.Log("Next ball will spawn at small size.");
        }
        if (Input.GetKeyUp(KeyCode.K))
        {
            ball.transform.localScale = new Vector3(1, 1, 1);
            Debug.Log("Next ball will spawn at medium size.");
        }
        if (Input.GetKeyUp(KeyCode.L))
        {
            ball.transform.localScale = new Vector3(2, 2, 2);
            Debug.Log("Next ball will spawn at large size.");
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Instantiate(ball, new Vector3(0, 0, 6), Quaternion.identity);
            Debug.Log("Spawned ball.");
        }
    }

    void Spawn(string speed)
    {
        var newBall = Instantiate(ball) as GameObject;
        ball.GetComponent<BallBehavior>().initialImpulse = new Vector3(2.5f, 0, 3);
    }
}
