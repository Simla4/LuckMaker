using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerRoot;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = GetComponent<Camera>();
    }

    void Update()
    {
        SetCameraPosition();
    }

    //Camera will follow the player from behind 15 units on Z axis
    private void SetCameraPosition()
    {
        var playerPos = playerRoot.transform.position;
        mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y, playerPos.z - 15.0f);
    }
}
