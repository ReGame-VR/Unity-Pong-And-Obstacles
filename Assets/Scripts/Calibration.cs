using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Calibration : MonoBehaviour
{
    public float leftMax, rightMax;
    public TextMeshProUGUI leftImg, rightImg, forwardImg, backwardsImg;
    public GameObject paddle;
    // Start is called before the first frame update
    void Start()
    {
        //re-enable VR settings for rest of the game
        UnityEngine.XR.XRSettings.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (paddle.GetComponent<MovePaddle>().CoPtoCMRaw(Wii.GetCenterOfBalance(0)).x < leftMax)
        {
            leftMax = paddle.GetComponent<MovePaddle>().CoPtoCMRaw(Wii.GetCenterOfBalance(0)).x;
        }

        if (paddle.GetComponent<MovePaddle>().CoPtoCMRaw(Wii.GetCenterOfBalance(0)).x > rightMax)
        {
            rightMax = paddle.GetComponent<MovePaddle>().CoPtoCMRaw(Wii.GetCenterOfBalance(0)).x;
        }
    }

    public void SaveData()
    {

    }
}
