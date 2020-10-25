using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody playerRigid;
    public float forceApplied;
    public float topSpeed;

    Vector2 direction;

    private void FixedUpdate() {
        Debug.Log(direction);

        playerRigid.AddRelativeForce(direction.x * forceApplied * Time.deltaTime, 0f, direction.y * forceApplied * Time.deltaTime);

        if (playerRigid.velocity.magnitude > topSpeed) {
            playerRigid.velocity = playerRigid.velocity.normalized * topSpeed;
        }
    }
    public void Move(InputAction.CallbackContext context) {
        direction = context.ReadValue<Vector2>();
    }
}
