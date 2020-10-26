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
        // Locks Camera to playerLook
        playerCamera.transform.position = playerLook.transform.position;
        playerCamera.transform.rotation = playerLook.transform.rotation;
    }

    private void FixedUpdate() {
        // Rotates camera according to Look value
        playerLook.transform.Rotate(Vector3.up, xSpeed * sensitivity * Time.fixedDeltaTime, Space.World);
        playerLook.transform.Rotate(Vector3.left, ySpeed * sensitivity * Time.fixedDeltaTime, Space.Self);
    }

    public void Look(InputAction.CallbackContext context) {
        // Records mouse speed
        xSpeed = context.ReadValue<Vector2>().x;
        ySpeed = context.ReadValue<Vector2>().y;
    }

    public void Use(InputAction.CallbackContext context) {
        // When the use key is pressed:
        if (context.started) {
            // Raycast max 5 units
            RaycastHit useRay;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out useRay, 5f)) {
                //If the hit object is usable
                if (useRay.collider.tag == "Usable Object") {
                    // Call the pressUse method
                    EventHandler.PressUse(useRay.collider.gameObject);
                }
            }
        }
    }
}
