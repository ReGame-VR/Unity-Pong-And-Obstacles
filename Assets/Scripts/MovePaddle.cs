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
        leftBound = -3.45f;
        rightBound = 3.44f;
    }

    // Update is called once per frame
    void Update()
    {
        wiiBB = CoPtoCM(Wii.GetCenterOfBalance(0));
        //Debug.Log(CoPtoCM(Wii.GetCenterOfBalance(0)));
        //paddleX = Mathf.Clamp(wiiBB.x, transform.TransformPoint(westEdge).x, transform.TransformPoint(eastEdge).x);
        paddleX = Mathf.Clamp(wiiBB.x, leftBound, rightBound);
        transform.position = new Vector3(paddleX, 22.04f, wiiBB.y);
        // If "Q" is pressed, paddle is large.
        if (Input.GetKeyUp(KeyCode.Q)) {
            leftBound = -3.45f;
            rightBound = 3.44f;
            this.transform.localScale = new Vector3(5.231771f, 0.1491342f, 0.5984464f);
        }
        // If "W" is pressed, paddle is medium-sized.
        if (Input.GetKeyUp(KeyCode.W)) {
            leftBound = -3.57f;
            rightBound = 3.56f;
            this.transform.localScale = new Vector3(3.530974f, 0.1491342f, 0.5984464f);
        }
        // If "E" is pressed, paddle is small.
        if (Input.GetKeyUp(KeyCode.E)) {
            leftBound = -4.38f;
            rightBound = 4.39f;
            this.transform.localScale = new Vector3(1.92535f, 0.1491342f, 0.5984464f);
        }
    }

    // Method to return Wii Balance Board's balance point input as a Vector2
    public static Vector2 CoPtoCM(Vector2 posn)
    {
        //return new Vector2(posn.x * 43.3f / 2f, posn.y * 23.6f / 2f);
        return new Vector2(posn.x * 43.3f / 1.4f, 0);
    }
}
