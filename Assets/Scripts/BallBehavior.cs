using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    public Vector3 initialImpulse;
    private Rigidbody rb;
    private GameObject spawner;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(initialImpulse, ForceMode.Impulse);
        spawner = GameObject.Find("BallSpawner");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "ScreenBottomWall")
        {
            spawner.GetComponent<Spawner>().balls.Remove(this.gameObject);
            Destroy(this.gameObject);
        }
    }
}
