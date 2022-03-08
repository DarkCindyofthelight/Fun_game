using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    public GameObject ball;

    public Starter starter;
    public Text scoreTextLeft;
    public Text scoreTextRight;

    private int scoreLeft = 0;
    private int scoreRight = 0;
    private bool started = false;
    private Vector3 startingPosition;

    private BallController ballController;
    

    void Start()
    {
        this.ballController = this.ball.GetComponent<BallController>();
        this.startingPosition = this.ball.transform.position;
    }
        
    void Update()
    {
        if (this.started)
            return;



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
        this.scoreTextLeft.text = this.scoreLeft.ToString();
        this.scoreTextRight.text = this.scoreRight.ToString();
        ResetBall();

    }
   private void ResetBall()
    {
        this.ballController.Stop();
        this.ball.transform.position = this.startingPosition;
        this.ballController.Go();
        this.starter.StartCountdown();

    }



}
