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
    public enum BallSize { Small, Medium, Large };
    // public floats for easily changing each BallSize's actual scale modifier
    public float smallScale, medScale, largeScale;
    // enum to decide the speed of each new spawned ball
    public enum BallSpeed { Slow, Medium, Fast };
    // public floats for easily changing each BallSpeed's actual speed modifier,
    // with max and min because there is some randomization each time
    public float slowSpeedMin, slowSpeedMax, medSpeedMin, medSpeedMax, fastSpeedMin, fastSpeedMax;
    // enum for choosing angle of intial flight
    public enum BallInitAngle { Shallow, Medium, Wide, Random };
    // public floats for min and max possible angles of initial flight angle
    public float shallowMin, shallowMax, medAngMin, medAngMax, wideMin, wideMax;
    // enum for choosing where ball spawns
    public enum Spawn { };
    // Ints for tracking current number of balls and max total number.
    public int currBalls, maxBalls;
    // enum to choose horizontal direction of initial flight
    public enum BallHorizDirection { Left, Right, Random };
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
        ball.transform.eulerAngles = new Vector3(0, 0, 0);
    }

    // Spawns ball with given difficulty parameters
    public void SpawnBall(BallSize size, BallSpeed speed, BallInitAngle initAngle, BallHorizDirection hDirect)
    {
        SetSpeed(speed);
        SetAngle(initAngle);
        SetSize(size);
        SetDirection(hDirect);
        ChooseSpawn();
        Vector3 chosenSpawn = spawnpoints[Random.Range(0, spawnpoints.Length)].gameObject.transform.position;
        currBalls += 1;
        //vertDirection = Random.Range(0, 2) * 2 - 1;
        //initialImpulse = new Vector3(initialImpulse.x * horizDirection, initialImpulse.y, initialImpulse.z * vertDirection);
        ball.GetComponent<BallBehavior>().initialImpulse = initialImpulse;
        Instantiate(ball, chosenSpawn, Quaternion.identity);
        Debug.Log("Spawned ball.");
        ResetBallPrefab();
    }

    // Sets up initialImpulse to properly reflect the selected BallSpeed
    void SetSpeed(BallSpeed speed)
    {
        if (speed.Equals(BallSpeed.Slow))
        {
            initialImpulse = new Vector3(0, 0, Random.Range(slowSpeedMin, slowSpeedMax));
        }
        if (speed.Equals(BallSpeed.Medium))
        {
            initialImpulse = transform.forward * Random.Range(medSpeedMin, medSpeedMax);
        }
        if (speed.Equals(BallSpeed.Fast))
        {
            initialImpulse = transform.forward * Random.Range(fastSpeedMin, fastSpeedMax);
        }
    }

    // Sets up ball's rotation to properly reflect the selected BallInitAngle
    void SetAngle(BallInitAngle initAngle)
    {
        Vector3 turn = new Vector3();
        if (initAngle.Equals(BallInitAngle.Shallow))
        {
            //ball.transform.eulerAngles = new Vector3(0, Random.Range(shallowMin, shallowMax), 0);
            turn = new Vector3(0, 0, Random.Range(shallowMin, shallowMax));
        }
        if (initAngle.Equals(BallInitAngle.Medium))
        {
            //ball.transform.eulerAngles = new Vector3(0, Random.Range(medAngMin, medAngMax), 0);
            turn = new Vector3(0, Random.Range(medAngMin, medAngMax), 0);
        }
        if (initAngle.Equals(BallInitAngle.Wide))
        {
            //ball.transform.eulerAngles = new Vector3(0, Random.Range(wideMin, wideMax), 0);
            turn = new Vector3(0, Random.Range(wideMin, wideMax), 0);
        }
        if (initAngle.Equals(BallInitAngle.Random))
        {
            //ball.transform.eulerAngles = new Vector3(0, Random.Range(shallowMin, wideMax), 0);
            turn = new Vector3(0, Random.Range(shallowMin, wideMax), 0);
        }
        Quaternion q = Quaternion.FromToRotation(Vector3.forward, turn);
        initialImpulse = q * initialImpulse;
    }

    // Sets up intialImpulse to properly reflect the selected initial horizontal direction
    void SetDirection(BallHorizDirection hDirect)
    {
        if (hDirect.Equals(BallHorizDirection.Left))
        {
            initialImpulse = new Vector3(initialImpulse.x * -1, initialImpulse.y, initialImpulse.z);
        }
        if (hDirect.Equals(BallHorizDirection.Right))
        {
            // Do nothing, as ball will default to right
        }
        if (hDirect.Equals(BallHorizDirection.Random))
        {
            int direct = Random.Range(0, 2) * 2 - 1;
            initialImpulse = new Vector3(initialImpulse.x * direct, initialImpulse.y, initialImpulse.z);
        }
    }

    // Sets up ball's localScale to reflect the selected BallSize
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
            ball.transform.localScale = new Vector3(largeScale, largeScale, largeScale);
        }
    }

    void ChooseSpawn()
    {

    }
}
