using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public TMP_Dropdown chooseMode;
    // Start is called before the first frame update
    void Start()
    {
        // disable VR settings for menu scene
        UnityEngine.XR.XRSettings.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Processes Difficulty dropdown to a specific difficulty enum
    GlobalControl.Difficulty DifficultyConvert(int value)
    {
        if (value == 0)
        {
            return GlobalControl.Difficulty.One;
        }
        if (value == 1)
        {
            return GlobalControl.Difficulty.Two;
        }
        if (value == 2)
        {
            return GlobalControl.Difficulty.Three;
        }
        if (value == 3)
        {
            return GlobalControl.Difficulty.Four;
        }
        if (value == 4)
        {
            return GlobalControl.Difficulty.Five;
        }
        if (value == 5)
        {
            return GlobalControl.Difficulty.Six;
        }
        if (value == 6)
        {
            return GlobalControl.Difficulty.Seven;
        }
        if (value == 7)
        {
            return GlobalControl.Difficulty.Eight;
        }
        if (value == 8)
        {
            return GlobalControl.Difficulty.Nine;
        }
        else
        {
            return GlobalControl.Difficulty.Ten;
        }
    }

    // Progresses to next scene, setting values in GlobalControl
    public void NextScene()
    {
        GlobalControl.Instance.difficulty = DifficultyConvert(chooseMode.value);
        //SceneManager.LoadScene("Calibration");
        SceneManager.LoadScene("GameplayEnvironment");
    }
}
