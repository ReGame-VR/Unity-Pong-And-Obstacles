using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePaddle : MonoBehaviour
{
    // Vector2 representing input from the Wii Balance Board
    Vector2 wiiBB;
    // float to allow adjustment to the paddle's sensitivity
    //public static float paddleSens;
    // Gameobjects representing the walls of the game screen
    public GameObject eastWall, westWall;
    // Vector3s to represent the inner edges of the game screen walls
    Vector3 eastEdge, westEdge;
    // float to manage paddle's x-position and bind it within game screen
    float paddleX;
    // floats to manage left and right bounds for paddle.
    float leftBound, rightBound;
    // Start is called before the first frame update
    void Start()
    {
        eastEdge = eastWall.GetComponent<BoxCollider>().center - eastWall.GetComponent<BoxCollider>().size;
        westEdge = westWall.GetComponent<BoxCollider>().center + westWall.GetComponent<BoxCollider>().size;
        //Debug.Log("Bounds are " + westEdge + " and " + eastEdge + ".");
        leftBound = -15.1f;
        rightBound = 15.06f;
    }

    // Update is called once per frame
    void Update()
    {
        wiiBB = CoPtoCM(Wii.GetCenterOfBalance(0));
        //Debug.Log(CoPtoCM(Wii.GetCenterOfBalance(0)));
        //paddleX = Mathf.Clamp(wiiBB.x, transform.TransformPoint(westEdge).x, transform.TransformPoint(eastEdge).x);
        paddleX = Mathf.Clamp(wiiBB.x, leftBound, rightBound);
        transform.position = new Vector3(paddleX, wiiBB.y);
        // If "Q" is pressed, paddle is large.
        if (Input.GetKeyUp(KeyCode.Q)) {
            leftBound = -15.1f;
            rightBound = 15.06f;
            this.transform.localScale = new Vector3(16.67462f, 0.6537052f, 2.623191f);
        }
        // If "W" is pressed, paddle is medium-sized.
        if (Input.GetKeyUp(KeyCode.W)) {
            leftBound = -17.6f;
            rightBound = 17.59f;
            this.transform.localScale = new Vector3(11.67462f, 0.6537052f, 2.623191f);
        }
        // If "E" is pressed, paddle is small.
        if (Input.GetKeyUp(KeyCode.E)) {
            leftBound = -20.08f;
            rightBound = 20.08f;
            this.transform.localScale = new Vector3(6.67462f, 0.6537052f, 2.623191f);
        }
    }

    // Method to return Wii Balance Board's balance point input as a Vector2
    public static Vector2 CoPtoCM(Vector2 posn)
    {
        //return new Vector2(posn.x * 43.3f / 2f, posn.y * 23.6f / 2f);
        return new Vector2(posn.x * 43.3f / 1.4f, 0);
    }
}
