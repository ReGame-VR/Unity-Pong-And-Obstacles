using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehavior : MonoBehaviour
{
    // The obstacle's rigidbody to add force to
    private Rigidbody rb;
    // The camera that obstacles will be flying toward (player)
    public GameObject camera;
    // float representing obstacle flight speed
    public float speed = 1.0f;
    // floats representing rotation speeds for X, Y, and Z axes of obstacles
    public float rotX = 0;
    public float rotY = 0;
    public float rotZ = 0;
    // Start is called before the first frame update
    void Start()
    {
        //camera = GameObject.Find("Camera");
        rb = GetComponent<Rigidbody>();
        rb.AddForce((transform.position - camera.transform.position) * speed, ForceMode.VelocityChange);
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        //transform.position = new Vector3(transform.position.x, transform.position.y + Time.deltaTime, transform.position.z);
        //transform.position = Vector3.MoveTowards(transform.position, camera.transform.position, step);
        transform.Rotate(Vector3.right, rotX * Time.deltaTime);
        transform.Rotate(Vector3.up, rotY * Time.deltaTime);
        transform.Rotate(Vector3.forward, rotZ * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided");
        if (collision.gameObject.CompareTag("GameController"))
        {
            Debug.Log("Deflected obstacle!");
        }
        if (collision.gameObject == camera)
        {
            Debug.Log("Obstacle struck player...");
        }
        Destroy(this);
    }
}
