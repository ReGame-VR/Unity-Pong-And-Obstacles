using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// Class to handle background processes of level, like measuring success and score-keeping.
public class LevelController : MonoBehaviour
{
    // Ints to keep track of scoring values
    public int numBounces, numMisses, totalScore;
    // enum to gauge different ways of scoring
    public enum ScoringMetric { Bounce, BounceAndObstacle }
    // Values to determine what each level should do to level elements
    public MovePaddle.PaddleSize paddleSize; 
    public int numBalls;
    public BallSpawner.BallSize ballSize;
    public BallSpawner.BallSpeed ballSpeed;
    public BallSpawner.BallInitAngle initAngle;
    public BallSpawner.BallHorizDirection hDirect;
    public BallSpawner.BallInitAngle initialAngle;
    public ScoringMetric scoringMetric;
    // References to related gameObjects to affect, implementing these difficulty elements
    public GameObject ballSpawn;
    public GameObject paddle;
    public TextMeshProUGUI scoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.XR.XRSettings.enabled = true;
        // Sets up the level to properly mirror the current difficulty
        StartDifficulty();
        // Begins playing the level
        PlayGame();
    }

    // Increments the number of ball bounces
    public void BallBounce()
    {
        numBounces += 1;
        EarnPoint();
    }

    // Increments the number of ball misses
    public void BallMiss()
    {
        numMisses += 1;
    }

    private void Update()
    {
        DisplayGUI();
    }

    // Sets up all paramters within the level to match the current difficulty selected
    void StartDifficulty()
    {
        // Sets up difficulty 1
        if (GlobalControl.Instance.difficulty.Equals(GlobalControl.Difficulty.One))
        {
            paddleSize = MovePaddle.PaddleSize.Large;
            numBalls = 1;
            ballSize = BallSpawner.BallSize.Large;
            ballSpeed = BallSpawner.BallSpeed.Slow;
            initAngle = BallSpawner.BallInitAngle.Shallow;
            hDirect = BallSpawner.BallHorizDirection.Left;
            scoringMetric = ScoringMetric.Bounce;
        }

        if (GlobalControl.Instance.difficulty.Equals(GlobalControl.Difficulty.Two))
        {
            paddleSize = MovePaddle.PaddleSize.Large;
            numBalls = 1;
            ballSize = BallSpawner.BallSize.Large;
            ballSpeed = BallSpawner.BallSpeed.Slow;
            initAngle = BallSpawner.BallInitAngle.Shallow;
            hDirect = BallSpawner.BallHorizDirection.Left;
            scoringMetric = ScoringMetric.Bounce;
        }

        if (GlobalControl.Instance.difficulty.Equals(GlobalControl.Difficulty.Three))
        {
            paddleSize = MovePaddle.PaddleSize.Large;
            numBalls = 1;
            ballSize = BallSpawner.BallSize.Medium;
            ballSpeed = BallSpawner.BallSpeed.Slow;
            initAngle = BallSpawner.BallInitAngle.Medium;
            hDirect = BallSpawner.BallHorizDirection.Left;
            scoringMetric = ScoringMetric.Bounce;
        }

        if (GlobalControl.Instance.difficulty.Equals(GlobalControl.Difficulty.Four))
        {
            paddleSize = MovePaddle.PaddleSize.Large;
            numBalls = 1;
            ballSize = BallSpawner.BallSize.Medium;
            ballSpeed = BallSpawner.BallSpeed.Medium;
            initAngle = BallSpawner.BallInitAngle.Medium;
            hDirect = BallSpawner.BallHorizDirection.Left;
            scoringMetric = ScoringMetric.Bounce;
        }

        if (GlobalControl.Instance.difficulty.Equals(GlobalControl.Difficulty.Five))
        {
            paddleSize = MovePaddle.PaddleSize.Medium;
            numBalls = 1;
            ballSize = BallSpawner.BallSize.Small;
            ballSpeed = BallSpawner.BallSpeed.Medium;
            initAngle = BallSpawner.BallInitAngle.Wide;
            hDirect = BallSpawner.BallHorizDirection.Left;
            scoringMetric = ScoringMetric.Bounce;
        }

        if (GlobalControl.Instance.difficulty.Equals(GlobalControl.Difficulty.Six))
        {
            paddleSize = MovePaddle.PaddleSize.Medium;
            numBalls = 2;
            ballSize = BallSpawner.BallSize.Small;
            ballSpeed = BallSpawner.BallSpeed.Medium;
            initAngle = BallSpawner.BallInitAngle.Wide;
            hDirect = BallSpawner.BallHorizDirection.Random;
            scoringMetric = ScoringMetric.Bounce;
        }

        if (GlobalControl.Instance.difficulty.Equals(GlobalControl.Difficulty.Seven))
        {
            paddleSize = MovePaddle.PaddleSize.Medium;
            numBalls = 2;
            ballSize = BallSpawner.BallSize.Large;
            ballSpeed = BallSpawner.BallSpeed.Medium;
            initAngle = BallSpawner.BallInitAngle.Random;
            hDirect = BallSpawner.BallHorizDirection.Random;
            scoringMetric = ScoringMetric.Bounce;
        }

        if (GlobalControl.Instance.difficulty.Equals(GlobalControl.Difficulty.Eight))
        {
            paddleSize = MovePaddle.PaddleSize.Small;
            numBalls = 2;
            ballSize = BallSpawner.BallSize.Medium;
            ballSpeed = BallSpawner.BallSpeed.Fast;
            initAngle = BallSpawner.BallInitAngle.Random;
            hDirect = BallSpawner.BallHorizDirection.Random;
            scoringMetric = ScoringMetric.BounceAndObstacle;
        }

        if (GlobalControl.Instance.difficulty.Equals(GlobalControl.Difficulty.Nine))
        {
            paddleSize = MovePaddle.PaddleSize.Small;
            numBalls = 2;
            ballSize = BallSpawner.BallSize.Medium;
            ballSpeed = BallSpawner.BallSpeed.Fast;
            initAngle = BallSpawner.BallInitAngle.Random;
            hDirect = BallSpawner.BallHorizDirection.Random;
            scoringMetric = ScoringMetric.BounceAndObstacle;
        }

        if (GlobalControl.Instance.difficulty.Equals(GlobalControl.Difficulty.Ten))
        {
            paddleSize = MovePaddle.PaddleSize.Small;
            numBalls = 2;
            ballSize = BallSpawner.BallSize.Small;
            ballSpeed = BallSpawner.BallSpeed.Fast;
            initAngle = BallSpawner.BallInitAngle.Random;
            hDirect = BallSpawner.BallHorizDirection.Random;
            scoringMetric = ScoringMetric.BounceAndObstacle;
        }
    }

    void PlayGame()
    {
        paddle.GetComponent<MovePaddle>().ResizePaddle(paddleSize);
        for (int i = 0; i < numBalls; i++)
        {
            ballSpawn.GetComponent<BallSpawner>().SpawnBall(ballSize, ballSpeed, initAngle, hDirect);
        }
    }

    public void DisplayGUI()
    {
        scoreText.text = "Score = " + totalScore;
    }

    public void EarnPoint()
    {
        totalScore += 1;
    }

    void LosePoint()
    {
        if (scoringMetric.Equals(ScoringMetric.BounceAndObstacle))
        {
            totalScore -= 1;
        }
    }
}
