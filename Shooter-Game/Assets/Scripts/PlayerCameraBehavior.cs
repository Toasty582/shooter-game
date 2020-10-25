using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCameraBehavior : MonoBehaviour
{
    public Camera playerCamera;
    public GameObject playerLook;

    public float sensitivity;

    float xSpeed;
    float ySpeed;

    void Update()
    {
        playerCamera.transform.position = playerLook.transform.position;
        playerCamera.transform.rotation = playerLook.transform.rotation;
    }

    private void FixedUpdate() {
        playerLook.transform.Rotate(Vector3.up, xSpeed * sensitivity * Time.fixedDeltaTime, Space.World);
        playerLook.transform.Rotate(Vector3.left, ySpeed * sensitivity * Time.fixedDeltaTime, Space.Self);
    }

    public void Look(InputAction.CallbackContext context) {
        xSpeed = context.ReadValue<Vector2>().x;
        ySpeed = context.ReadValue<Vector2>().y;
    }
}
