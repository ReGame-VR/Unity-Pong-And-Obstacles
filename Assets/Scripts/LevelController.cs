using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class to handle background processes of level, like measuring success and score-keeping.
public class LevelController : MonoBehaviour
{
    // Ints to keep track of scoring values
    public int numBounces, numMisses;
    // Values to determine what each level should do to level elements
    public MovePaddle.PaddleSize paddleSize; 
    public int numBalls;
    public BallSpawner.BallSize ballSize;
    public BallSpawner.BallSpeed ballSpeed;
    public float initialAngle;
    // References to related gameObjects to affect, implementing these difficulty elements

    
    // Start is called before the first frame update
    void Start()
    {
        // Sets up the level to properly mirror the current difficulty
        StartDifficulty();
    }

    // Increments the number of ball bounces
    public void BallBounce()
    {
        numBounces += 1;
    }

    // Increments the number of ball misses
    public void BallMiss()
    {
        numMisses += 1;
    }

    void StartDifficulty()
    {
        // Sets up difficulty 1
        if (GlobalControl.Instance.difficulty.Equals(GlobalControl.Difficulty.One))
        {
            paddleSize = MovePaddle.PaddleSize.Large;
            numBalls = 1;
            ballSize = BallSpawner.BallSize.Large;
            ballSpeed = BallSpawner.BallSpeed.Slow;
        }

        if (GlobalControl.Instance.difficulty.Equals(GlobalControl.Difficulty.Two))
        {
            paddleSize = MovePaddle.PaddleSize.Large;
            numBalls = 1;
            ballSize = BallSpawner.BallSize.Large;
            ballSpeed = BallSpawner.BallSpeed.Slow;
        }

        if (GlobalControl.Instance.difficulty.Equals(GlobalControl.Difficulty.Three))
        {
            paddleSize = MovePaddle.PaddleSize.Large;
            numBalls = 1;
            ballSize = BallSpawner.BallSize.Medium;
            ballSpeed = BallSpawner.BallSpeed.Slow;
        }

        if (GlobalControl.Instance.difficulty.Equals(GlobalControl.Difficulty.Four))
        {
            paddleSize = MovePaddle.PaddleSize.Large;
            numBalls = 1;
            ballSize = BallSpawner.BallSize.Medium;
            ballSpeed = BallSpawner.BallSpeed.Medium;
        }

        if (GlobalControl.Instance.difficulty.Equals(GlobalControl.Difficulty.Five))
        {
            paddleSize = MovePaddle.PaddleSize.Medium;
            numBalls = 1;
            ballSize = BallSpawner.BallSize.Small;
            ballSpeed = BallSpawner.BallSpeed.Medium;
        }

        if (GlobalControl.Instance.difficulty.Equals(GlobalControl.Difficulty.Six))
        {
            paddleSize = MovePaddle.PaddleSize.Medium;
            numBalls = 2;
            ballSize = BallSpawner.BallSize.Small;
            ballSpeed = BallSpawner.BallSpeed.Medium;
        }

        if (GlobalControl.Instance.difficulty.Equals(GlobalControl.Difficulty.Seven))
        {
            paddleSize = MovePaddle.PaddleSize.Medium;
            numBalls = 2;
            ballSize = BallSpawner.BallSize.Large;
            ballSpeed = BallSpawner.BallSpeed.Medium;
        }

        if (GlobalControl.Instance.difficulty.Equals(GlobalControl.Difficulty.Eight))
        {
            paddleSize = MovePaddle.PaddleSize.Large;
            numBalls = 2;
            ballSize = BallSpawner.BallSize.Medium;
            ballSpeed = BallSpawner.BallSpeed.Fast;
        }

        if (GlobalControl.Instance.difficulty.Equals(GlobalControl.Difficulty.Nine))
        {
            paddleSize = MovePaddle.PaddleSize.Large;
            numBalls = 2;
            ballSize = BallSpawner.BallSize.Medium;
            ballSpeed = BallSpawner.BallSpeed.Fast;
        }

        if (GlobalControl.Instance.difficulty.Equals(GlobalControl.Difficulty.Ten))
        {
            paddleSize = MovePaddle.PaddleSize.Large;
            numBalls = 2;
            ballSize = BallSpawner.BallSize.Small;
            ballSpeed = BallSpawner.BallSpeed.Fast;
        }
    }
}
