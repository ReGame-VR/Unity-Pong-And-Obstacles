using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehavior : MonoBehaviour
{
    
    GameObject camera;
    public float speed = 1.0f;
    public float rotX = 0;
    public float rotY = 0;
    public float rotZ = 0;
    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("Camera");
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        //transform.position = new Vector3(transform.position.x, transform.position.y + Time.deltaTime, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, camera.transform.position, step);
        transform.Rotate(Vector3.right, rotX * Time.deltaTime);
        transform.Rotate(Vector3.up, rotY * Time.deltaTime);
        transform.Rotate(Vector3.forward, rotZ * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided");
        if (collision.gameObject.CompareTag("Controller"))
        {
            Debug.Log("Deflected obstacle!");
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Obstacle struck player...");
        }
        Destroy(this.gameObject);
    }
}
