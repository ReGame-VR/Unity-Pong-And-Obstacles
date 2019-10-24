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
        levelController = GameObject.Find("LevelController")
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.y > 22.196f)
        {
            transform.position = new Vector3(transform.position.x, 22.196f, transform.position.z);
            
        }

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
        if (collision.gameObject.name.Equals("ScreenBottomWall"))
        {
            if (spawner.GetComponent<BallSpawner>().currBalls > 0)
            {
                spawner.GetComponent<BallSpawner>().currBalls -= 1;
            }
            Destroy(this.gameObject);
        }
        if (collision.gameObject.name .Equals("Paddle")) {
            
        }
    }
}
