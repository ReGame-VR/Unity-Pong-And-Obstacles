using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// Class to handle background processes of level, like measuring success and score-keeping.
public class LevelController : MonoBehaviour
{
    // bool to track when game is complete
    bool gameComplete;
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
    public ObstacleSpawner.ObstacleSpeed obsSpeed;
    public float obstacleSpawnRate;
    public ScoringMetric scoringMetric;
    // References to related gameObjects to affect, implementing these difficulty elements
    public GameObject ballSpawn;
    public GameObject paddle;
    public TextMeshProUGUI scoreText;
    public GameObject obstacleSpawn;
    public GameObject levelGeometryBasic, levelGeometryAdv1, levelGeometryAdv2;
    
    // Start is called before the first frame update
    void Start()
    {
        // Turns VR visuals back on
        UnityEngine.XR.XRSettings.enabled = true;
        // Sets gameComplete flag to false
        gameComplete = false;
        // Sets up the level to properly mirror the current difficulty
        StartDifficulty();
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

    // Sets up all paramters within the level to match the current difficulty selected
    void StartDifficulty()
    {
        // Difficulty implementations can be found on the spreadsheet
        if (GlobalControl.Instance.difficulty.Equals(GlobalControl.Difficulty.One))
        {
            paddleSize = MovePaddle.PaddleSize.Large;
            numBalls = 1;
            ballSize = BallSpawner.BallSize.Large;
            ballSpeed = BallSpawner.BallSpeed.Slow;
            initAngle = BallSpawner.BallInitAngle.Shallow;
            hDirect = BallSpawner.BallHorizDirection.Left;
            scoringMetric = ScoringMetric.Bounce;
            obstacleSpawn.GetComponent<ObstacleSpawner>().maxObs = 0;
            obsSpeed = ObstacleSpawner.ObstacleSpeed.NULL;
            obstacleSpawnRate = 0;
            levelGeometryBasic.gameObject.SetActive(false);
            levelGeometryAdv1.gameObject.SetActive(false);
            levelGeometryAdv2.gameObject.SetActive(false);
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
            obstacleSpawn.GetComponent<ObstacleSpawner>().maxObs = 0;
            obsSpeed = ObstacleSpawner.ObstacleSpeed.NULL;
            obstacleSpawnRate = 0;
            levelGeometryBasic.gameObject.SetActive(false);
            levelGeometryAdv1.gameObject.SetActive(false);
            levelGeometryAdv2.gameObject.SetActive(false);
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
            obstacleSpawn.GetComponent<ObstacleSpawner>().maxObs = 0;
            obsSpeed = ObstacleSpawner.ObstacleSpeed.NULL;
            obstacleSpawnRate = 0;
            levelGeometryBasic.gameObject.SetActive(false);
            levelGeometryAdv1.gameObject.SetActive(false);
            levelGeometryAdv2.gameObject.SetActive(false);
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
            obstacleSpawn.GetComponent<ObstacleSpawner>().maxObs = 0;
            obsSpeed = ObstacleSpawner.ObstacleSpeed.NULL;
            obstacleSpawnRate = 0;
            levelGeometryBasic.gameObject.SetActive(false);
            levelGeometryAdv1.gameObject.SetActive(false);
            levelGeometryAdv2.gameObject.SetActive(false);
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
            obstacleSpawn.GetComponent<ObstacleSpawner>().maxObs = 0;
            obsSpeed = ObstacleSpawner.ObstacleSpeed.NULL;
            obstacleSpawnRate = 0;
            levelGeometryBasic.gameObject.SetActive(true);
            levelGeometryAdv1.gameObject.SetActive(false);
            levelGeometryAdv2.gameObject.SetActive(false);
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
            obstacleSpawn.GetComponent<ObstacleSpawner>().maxObs = 0;
            obsSpeed = ObstacleSpawner.ObstacleSpeed.NULL;
            obstacleSpawnRate = 0;
            levelGeometryBasic.gameObject.SetActive(true);
            levelGeometryAdv1.gameObject.SetActive(false);
            levelGeometryAdv2.gameObject.SetActive(false);
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
            obstacleSpawn.GetComponent<ObstacleSpawner>().maxObs = 2;
            obsSpeed = ObstacleSpawner.ObstacleSpeed.Slow;
            obstacleSpawnRate = 2.5f;
            levelGeometryBasic.gameObject.SetActive(true);
            levelGeometryAdv1.gameObject.SetActive(false);
            levelGeometryAdv2.gameObject.SetActive(false);
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
            obstacleSpawn.GetComponent<ObstacleSpawner>().maxObs = 4;
            obsSpeed = ObstacleSpawner.ObstacleSpeed.Slow;
            obstacleSpawnRate = 2.5f;
            levelGeometryBasic.gameObject.SetActive(true);
            levelGeometryAdv1.gameObject.SetActive(false);
            levelGeometryAdv2.gameObject.SetActive(false);
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
            obstacleSpawn.GetComponent<ObstacleSpawner>().maxObs = 6;
            obsSpeed = ObstacleSpawner.ObstacleSpeed.Fast;
            obstacleSpawnRate = 1.5f;
            levelGeometryBasic.gameObject.SetActive(true);
            levelGeometryAdv1.gameObject.SetActive(true);
            levelGeometryAdv2.gameObject.SetActive(true);
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
            obstacleSpawn.GetComponent<ObstacleSpawner>().maxObs = 8;
            obsSpeed = ObstacleSpawner.ObstacleSpeed.Random;
            obstacleSpawnRate = 0.7f;
            levelGeometryBasic.gameObject.SetActive(true);
            levelGeometryAdv1.gameObject.SetActive(true);
            levelGeometryAdv2.gameObject.SetActive(true);
        }

        // Begins the level with the set-up parameters
        paddle.GetComponent<MovePaddle>().ResizePaddle(paddleSize);
        for (int i = 0; i < numBalls; i++)
        {
            ballSpawn.GetComponent<BallSpawner>().SpawnBall(ballSize, ballSpeed, initAngle, hDirect);
        }
        for (int i = 0; i < obstacleSpawn.GetComponent<ObstacleSpawner>().maxObs; i++)
        {
            obstacleSpawn.GetComponent<ObstacleSpawner>().SpawnObstacle(obsSpeed);
            //WaitToSpawnObstacle();
        }

        // THIS IS CAUSING PROBLEMS, TRY UPDATE() LOOP INSTEAD???
        // Run game as long as gameComplete is false
        //while (!gameComplete)
        //{
            // Begins playing the level
            //PlayGame();
        //}
        // Once it is true, end the game
        //EndGame();
    }

    // Method to handle game processes while running
    // Originally was its own method, crashed game. Trying update loop now
    void Update() {
        // Update the GUI
        DisplayGUI();

        if (obstacleSpawn.GetComponent<ObstacleSpawner>().currObs < 
            obstacleSpawn.GetComponent<ObstacleSpawner>().maxObs)
        {
            WaitToSpawnObstacle();
            obstacleSpawn.GetComponent<ObstacleSpawner>().SpawnObstacle(obsSpeed);
        }
    }

    // Update the GUI to reflect current game stats
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

    IEnumerator WaitToSpawnObstacle()
    {
        yield return new WaitForSeconds(obstacleSpawnRate);
    }

    // Method to run upon game completion
    void EndGame()
    {

    }
}
