using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject ball;

    public Text ScoreTextLeft;
    public Text ScoreTextRight;

    public Starter starter;

    private bool started = false;

    private int scoreLeft = 0;
    private int scoreRight = 0;

    private BallController ballController;

    private Vector3 startingPosition;

    void Start()
    {
        this.ballController = this.ball.GetComponent<BallController>();
        this.startingPosition = this.ball.transform.position;
    }

    
    void Update()
    {
        if (this.started)
        {
            return;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            this.started = true;
            this.starter.StartCountdown();
        }
    }

    public void StartGame()
    {
        this.ballController.Go();
    }

    public void ScoreGoalLeft()
    {
        Debug.Log("ScoreGoalLeft");
        this.scoreRight += 1;
        UpdateUI();
        ResetBall();
    }

    public void ScoreGoalRight()
    {
        Debug.Log("ScoreGoalRight");
        this.scoreLeft += 1;
        UpdateUI();
        ResetBall();
    }

    private void UpdateUI()
    {
        this.ScoreTextLeft.text = this.scoreLeft.ToString();
        this.ScoreTextRight.text = this.scoreRight.ToString();
    }

    private void ResetBall()
    {
        this.ballController.Stop();
        this.ball.transform.position = this.startingPosition;
        this.starter.StartCountdown();
    }

}
