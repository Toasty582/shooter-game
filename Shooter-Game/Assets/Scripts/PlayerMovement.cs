using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody playerRigid;
    public GameObject playerLook;
    GameObject player;

    float forceApplied = 500f;
    float topSpeed = 4f;

    float distToGround;

    Vector2 direction;

    private void Start() {
        player = playerRigid.gameObject;
        distToGround = player.GetComponent<BoxCollider>().bounds.extents.y;
    }

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

    public void Jump(InputAction.CallbackContext context) {
        if (Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f)) {
            playerRigid.AddForce(Vector3.up * 250f);
        }
    }
}
