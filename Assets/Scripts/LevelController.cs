using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class to handle background processes of level, like measuring success and score-keeping.
public class LevelController : MonoBehaviour
{
    public int numBounces, numMisses;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BallBounce()
    {
        numBounces++;
    }
}
