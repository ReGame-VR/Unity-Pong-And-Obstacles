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
    //Vector3 eastEdge, westEdge;
    // float to manage paddle's x-position and bind it within game screen
    float paddleX;
    // floats to manage left and right bounds for paddle.
    float leftBound, rightBound;
    // enum
    public enum PaddleSize { Small, Medium, Large };
    PaddleSize size;
    // float modifiers to affect sensitivity of paddle
    public float smallModifier, mediumModifier, largeModifier;

    // Start is called before the first frame update
    void Start()
    {
        //eastEdge = eastWall.GetComponent<BoxCollider>().center - eastWall.GetComponent<BoxCollider>().size;
        //westEdge = westWall.GetComponent<BoxCollider>().center + westWall.GetComponent<BoxCollider>().size;
        //Debug.Log("Bounds are " + westEdge + " and " + eastEdge + ".");
        leftBound = -2.24f;
        rightBound = 2.23f;
        size = PaddleSize.Large;
    }

    // Update is called once per frame
    void Update()
    {
        wiiBB = CoPtoCM(Wii.GetCenterOfBalance(0));
        //Debug.Log(CoPtoCM(Wii.GetCenterOfBalance(0)));
        //paddleX = Mathf.Clamp(wiiBB.x, transform.TransformPoint(westEdge).x, transform.TransformPoint(eastEdge).x);
        paddleX = Mathf.Clamp(wiiBB.x, leftBound, rightBound);
        transform.position = new Vector3(paddleX, 22.04f, -3.81f);
        // If "Q" is pressed, paddle is large.
        if (Input.GetKeyUp(KeyCode.Q)) {
            size = PaddleSize.Large;
        }
        // If "W" is pressed, paddle is medium-sized.
        if (Input.GetKeyUp(KeyCode.W)) {
            size = PaddleSize.Medium;
        }
        // If "E" is pressed, paddle is small.
        if (Input.GetKeyUp(KeyCode.E)) {
            size = PaddleSize.Small;
        }
    }

    // Method to return Wii Balance Board's balance point input as a Vector2
    public Vector2 CoPtoCM(Vector2 posn)
    {
        if (size.Equals(PaddleSize.Small))
        {
            return new Vector2(posn.x * 43.3f / smallModifier, 0);
        }
        else if (size.Equals(PaddleSize.Medium))
        {
            //return new Vector2(posn.x * 43.3f / 2f, posn.y * 23.6f / 2f);
            return new Vector2(posn.x * 43.3f / mediumModifier, 0);
        }
        else
        {
            return new Vector2(posn.x * 43.3f / largeModifier, 0);
        }
    }

    public Vector2 CoPtoCMRaw(Vector2 posn)
    {
        return new Vector2(posn.x, 0);
    }

    public void ResizePaddle(PaddleSize pSize)
    {
        if (pSize.Equals(PaddleSize.Large))
        {
            leftBound = -2.24f;
            rightBound = 2.23f;
            this.transform.localScale = new Vector3(6.210636f, 0.1491342f, 0.5984464f);
        }
        if (pSize.Equals(PaddleSize.Medium))
        {
            leftBound = -3.57f;
            rightBound = 3.56f;
            this.transform.localScale = new Vector3(3.530974f, 0.1491342f, 0.5984464f);
        }
        if (pSize.Equals(PaddleSize.Small))
        {
            leftBound = -4.38f;
            rightBound = 4.39f;
            this.transform.localScale = new Vector3(1.92535f, 0.1491342f, 0.5984464f);
        }
    }
}
