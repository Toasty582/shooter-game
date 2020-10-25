using UnityEngine;

public class PlayerCameraBehavior : MonoBehaviour
{
    public Camera playerCamera;
    public GameObject player;
    Vector3 cameraOffset = new Vector3(0f, 0.5f, 0f);

    // Update is called once per frame
    void Update()
    {
        playerCamera.transform.position = player.transform.position + cameraOffset;
    }
}
