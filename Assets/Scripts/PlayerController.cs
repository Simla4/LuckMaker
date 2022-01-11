using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform playerRoot;
    public GameObject gameManager;

    public float forwardMovementSpeed = 1.0f;
    public float sidewaysMovementSensivity = 1.0f;
    public float leftMovementLimitPos = -3.0f;
    public float rightMovementLimitPos = 3.0f;

    private Vector2 inputDrag;
    private Vector2 prevMousePos;

    void Update()
    {
        CheckGameStateFirstThenRun();
    }

    private void MoveForward()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * forwardMovementSpeed);
    }

    private void MoveSideways()
    {
        var currentPos = playerRoot.localPosition;
        var dragPos = Vector3.right * inputDrag.x * sidewaysMovementSensivity;

        if (currentPos.x + dragPos.x < rightMovementLimitPos && currentPos.x + dragPos.x > leftMovementLimitPos)
        {
            playerRoot.localPosition += dragPos;
        }
    }

    private void GetInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            prevMousePos = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            var deltaMouse = (Vector2)Input.mousePosition - prevMousePos;
            inputDrag = deltaMouse;
            prevMousePos = Input.mousePosition;
        }
        else
        {
            inputDrag = Vector2.zero;
        }
    }

    private void CheckGameStateFirstThenRun()
    {
        if (gameManager.GetComponent<GameManager>().State == GameManager.GameState.OnTheRun)
        {
            MoveForward();
            GetInput();
            MoveSideways();
        }
    }
}
