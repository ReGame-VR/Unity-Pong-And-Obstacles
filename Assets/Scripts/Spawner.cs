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
            Instantiate(ball, new Vector3(0, 0, 6), Quaternion.identity);
        }
        if (Input.GetKeyUp(KeyCode.I))
        {
            ball.GetComponent<BallBehavior>().initialImpulse = new Vector3(5, 0, 5);
            Instantiate(ball, new Vector3(0, 0, 6), Quaternion.identity);
        }
        if (Input.GetKeyUp(KeyCode.O))
        {
            ball.GetComponent<BallBehavior>().initialImpulse = new Vector3(7, 0, 9);
            Instantiate(ball, new Vector3(0, 0, 6), Quaternion.identity);
        }
    }

    void Spawn(string speed)
    {
        var newBall = Instantiate(ball) as GameObject;
        ball.GetComponent<BallBehavior>().initialImpulse = new Vector3(2.5f, 0, 3);
    }
}
