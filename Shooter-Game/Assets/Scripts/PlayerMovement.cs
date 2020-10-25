using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody playerRigid;
    public GameObject playerLook;
    public float forceApplied;
    public float topSpeed;

    Vector2 direction;

    private void Update() {
        playerLook.transform.position = playerRigid.gameObject.transform.position + new Vector3(0f, 1f, 0f);

        playerRigid.gameObject.transform.eulerAngles = new Vector3(
            playerRigid.gameObject.transform.eulerAngles.x,
            playerLook.transform.eulerAngles.y,
            playerRigid.gameObject.transform.eulerAngles.z
        );
    }

    private void FixedUpdate() {
        playerRigid.AddRelativeForce(direction.x * forceApplied * Time.fixedDeltaTime, 0f, direction.y * forceApplied * Time.fixedDeltaTime);

        if (playerRigid.velocity.magnitude > topSpeed) {
            playerRigid.velocity = playerRigid.velocity.normalized * topSpeed;
        }
    }
    public void Move(InputAction.CallbackContext context) {
        direction = context.ReadValue<Vector2>();
    }
}
