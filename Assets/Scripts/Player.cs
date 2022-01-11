using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int luckValue;
    public int coinValue;
    public float bumpValue;
    public GameManager gameManager;
    public PlayerController playerController;
    public ScoreBar scoreBar;
    public UIManager uIManager;
    private bool isBumped = false;
    private Vector3 targetPositionForBump;

    // Update is called once per frame
    void Update()
    {
        //Debug.LogFormat("Luck Value -> {0}", luckValue);

        if (isBumped)
        {
            BumpBack(targetPositionForBump);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("LuckObject"))
        {
            luckValue += 10;
            coinValue += 100;
            Destroy(other.gameObject); 
        }
        else if (other.gameObject.tag.Equals("Obstacle"))
        {

            luckValue -= 10;
            coinValue -= 100;
            gameManager.Bumped();

            targetPositionForBump = new Vector3(transform.position.x, transform.position.y, other.gameObject.transform.position.z - bumpValue);
            isBumped = true;
        }
        else if (other.gameObject.tag.Equals("LuckyGate"))
        {
            gameManager.RollDice();
        }

        uIManager.MainScene(coinValue);
        scoreBar.setScore(luckValue);
        scoreBar.setScoreText(luckValue);
    }

    private void OnTriggerExit(Collider other)
    {
         if (other.gameObject.tag.Equals("Finish"))
        {

            if (luckValue <= 0)
            {
                uIManager.FailScene(luckValue, coinValue);
                gameManager.Defeat();
                playerController.forwardMovementSpeed = 0;
            }
            else
            {
                uIManager.WinScene(luckValue, coinValue);
                gameManager.Finished();
                playerController.forwardMovementSpeed = 0;
                gameObject.transform.Rotate(0.0f, 180.0f, 0.0f, Space.Self);
            }

        }
    }

    private void BumpBack(Vector3 targetPosition)
    {
        if (Mathf.Abs(targetPosition.z - transform.position.z) < 0.2f)
        {
            isBumped = false;
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, 0.1f);
        }
    }
}

