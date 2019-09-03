using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehavior : MonoBehaviour
{
    //public GameObject startingPoint;
    GameObject camera;
    public float speed = 1.0f;
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
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Controller"))
        {
            Destroy(this.gameObject);
        }
    }
}
