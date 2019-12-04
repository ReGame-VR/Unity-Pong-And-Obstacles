using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControl : MonoBehaviour
{
    // floats to store the furthest left and right the participant can lean
    public float leftMax, rightMax;
    // 
    //public enum ProgressionType { };
    // Enum to track current game difficulty level
    public enum Difficulty {One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten};
    public Difficulty difficulty;

    // participant ID to differentiate logs
    public string participantID;

    // Single instance of this class
    public static GlobalControl Instance;

    // Runs on startup
    private void Awake()
    {
        // If there is no Instance, makes this the Instance
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        // If an instance already exists, destroy this
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
}
