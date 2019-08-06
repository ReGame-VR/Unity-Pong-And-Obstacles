using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePaddle : MonoBehaviour
{
    Vector2 wiiBB;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        wiiBB = CoPtoCM(Wii.GetCenterOfBalance(0));
        Debug.Log(CoPtoCM(Wii.GetCenterOfBalance(0)));
        transform.position = wiiBB;
    }

    public static Vector2 CoPtoCM(Vector2 posn)
    {
        //return new Vector2(posn.x * 43.3f / 2f, posn.y * 23.6f / 2f);
        return new Vector2(posn.x * 43.3f / 2f, 0);
    }
}
