using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UIManager uIManager;

    public enum GameState
    {
        Idle = 0,
        OnTheRun = 1,
        Bumped = 2,
        WaitingForDice = 3,
        FeverMode = 4,
        Finished = 5
    }

    private GameState state;
    public GameState State
    {
        get { return state; }
        set { state = value; }
    }

    public GameObject player;
    public GameObject diceScenePrefab;

    private bool isStartTapped = false;
    private GameObject diceScene;

    private AnimationController animationController;

    //Game is waiting the first start at Idle state
    void Start()
    {
        state = GameState.Idle;
        animationController = GetComponent<AnimationController>();
    }

    void FixedUpdate()
    {
        StartGame();
    }


    //Wait for first tap to start game
    public void StartGame()
    {
        if (!isStartTapped && Input.GetMouseButton(0))
        {
            isStartTapped = true;
            state = GameState.OnTheRun;
            animationController.Run();
            uIManager.StartScene();
        }
    }

    public void Bumped()
    {
        state = GameState.Bumped;
        animationController.Bumped();
        Invoke("Run", 2.0f);
    }

    public void Run()
    {
        state = GameState.OnTheRun;
        animationController.Run();
    }
    public void Finished()
    {
        state = GameState.Finished;
        animationController.Dance();
    }
    public void Defeat()
    {
        state = GameState.Finished;
        animationController.Defeat();
    }

    public void RollDice()
    {
        state = GameState.WaitingForDice;
        animationController.Idle();
        diceScene = Instantiate(diceScenePrefab);
    }

    public void DestroyDiceScene()
    {
        if (diceScene != null)
        {
            Destroy(diceScene);
        }

        Run();
    }

    public void Retry()
    {
        Application.LoadLevel(0);
    }

    public void NextLevel()
    {
        Application.LoadLevel(0);
    } 

}
