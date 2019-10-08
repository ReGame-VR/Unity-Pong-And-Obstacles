using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehavior : MonoBehaviour
{
    // The obstacle's rigidbody to add force to
    private Rigidbody rb;
    // The camera that obstacles will be flying toward (player)
    GameObject camera;
    // float representing obstacle flight speed
    public float speed = 1.0f;
    // floats representing rotation speeds for X, Y, and Z axes of obstacles
    public float rotX = 0;
    public float rotY = 0;
    public float rotZ = 0;
    // boolean representing whether obstacle has been deflected by controller
    private bool deflected;
    // Gameobject reference to obstacle spawner object
    GameObject spawner;

    private float lifetime;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //rb.AddForce((transform.position - camera.transform.position) * speed, ForceMode.VelocityChange);
        lifetime = 3.0f;
        camera = GameObject.Find("Camera");
        spawner = GameObject.Find("ObstacleSpawner");
    }

    // called once per frame, after physics engine updates
    void FixedUpdate()
    {
        //float step = speed * Time.deltaTime;
        //transform.position = new Vector3(transform.position.x, transform.position.y + Time.deltaTime, transform.position.z);
        //rb.velocity = Vector3.MoveTowards(transform.position, camera.transform.position, step);
        //rb.velocity = transform.position - camera.transform.position;
        transform.Rotate(Vector3.right, rotX * Time.deltaTime);
        transform.Rotate(Vector3.up, rotY * Time.deltaTime);
        transform.Rotate(Vector3.forward, rotZ * Time.deltaTime);

        if (!deflected)
        {
            Vector3 direction = (camera.transform.position - transform.position).normalized;
            Vector3 obstVelocity = direction * speed;
            rb.velocity = obstVelocity;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Collided");
        if (collision.gameObject.CompareTag("GameController"))
        {
            Debug.Log("Deflected obstacle!");
            deflected = true;
            Destroy(gameObject, lifetime);
            if (!deflected && spawner.GetComponent<ObstacleSpawner>().currObs > 0)
            {
                spawner.GetComponent<ObstacleSpawner>().currObs -= 1;
            }
        }
        if (collision.gameObject.Equals(camera) && !deflected)
        {
            Debug.Log("Obstacle struck player...");
            Destroy(gameObject);
            if (spawner.GetComponent<ObstacleSpawner>().currObs > 0)
            {
                spawner.GetComponent<ObstacleSpawner>().currObs -= 1;
            }
        }
    }
}
