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
    // Start is called before the first frame update
    void Start()
    {
        eastEdge = eastWall.GetComponent<BoxCollider>().center - eastWall.GetComponent<BoxCollider>().size;
        westEdge = westWall.GetComponent<BoxCollider>().center + westWall.GetComponent<BoxCollider>().size;
        //Debug.Log("Bounds are " + westEdge + " and " + eastEdge + ".");
    }

    // Update is called once per frame
    void Update()
    {
        wiiBB = CoPtoCM(Wii.GetCenterOfBalance(0));
        //Debug.Log(CoPtoCM(Wii.GetCenterOfBalance(0)));
        //paddleX = Mathf.Clamp(wiiBB.x, transform.TransformPoint(westEdge).x, transform.TransformPoint(eastEdge).x);
        paddleX = Mathf.Clamp(wiiBB.x, -15.1f, 15.06f);
        transform.position = new Vector3(paddleX, wiiBB.y);
    }

    // Method to return Wii Balance Board's balance point input as a Vector2
    public static Vector2 CoPtoCM(Vector2 posn)
    {
        //return new Vector2(posn.x * 43.3f / 2f, posn.y * 23.6f / 2f);
        return new Vector2(posn.x * 43.3f / 1.4f, 0);
    }
}
