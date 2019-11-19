using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    public Vector3 initialImpulse;
    private Rigidbody rb;
    private GameObject spawner;
    private GameObject levelController;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(initialImpulse, ForceMode.Impulse);
        spawner = GameObject.Find("BallSpawner");
        levelController = GameObject.Find("LevelController");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Return))
        {
            Destroy(gameObject);
            if (spawner.GetComponent<BallSpawner>().currBalls > 0)
            {
                spawner.GetComponent<BallSpawner>().currBalls -= 1;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // If colliding with bottom wall, destroy ball
        if (collision.gameObject.name.Equals("ScreenBottomWall"))
        {
            if (spawner.GetComponent<BallSpawner>().currBalls > 0)
            {
                spawner.GetComponent<BallSpawner>().currBalls -= 1;
            }
            Destroy(this.gameObject);
        }
        // If colliding with paddle, call LevelController's BallBounce() method
        if (collision.gameObject.name.Equals("Paddle")) {
            levelController.GetComponent<LevelController>().BallBounce();
        }
    }
}
