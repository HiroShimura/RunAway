using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour {
    [SerializeField] Animator animator;

    Status status;
    CharacterController characterController;
    Transform _transform;
    Vector3 moveVelocity;
    float moveSpeed;
    float walkSpeed = 1f;
    float topSpeed = 2f;

    // Start is called before the first frame update
    void Start() {
        status = GetComponent<Status>();
        characterController = GetComponent<CharacterController>();
        _transform = transform;
    }

    void Update() {
        if (Input.GetKey(KeyCode.LeftShift)) {
            if (status.Stamina <= 0) {
                status.StaminaEmpty = true;
                moveSpeed = walkSpeed;
                status.Stamina += 0.2f;
            }
            else if (status.StaminaEmpty) {
                moveSpeed = walkSpeed;
                status.Stamina += 0.2f;
                if (status.Stamina >= 200) {
                    status.StaminaEmpty = false;
                }
            }
            else {
                moveSpeed = topSpeed;
                status.Stamina -= 0.3f;
            }
        }
        else {
            moveSpeed = walkSpeed;
            if (status.StaminaEmpty) {
                status.Stamina += 0.2f;
            }
            else {
                status.Stamina += 0.3f;
            }
        }
        moveVelocity.x = Input.GetAxis("Horizontal") * moveSpeed;
        moveVelocity.z = Input.GetAxis("Vertical") * moveSpeed;
        if (Input.GetButtonDown("Jump")) {
            animator.SetTrigger("Jump");
        }
        _transform.LookAt(transform.position + new Vector3(moveVelocity.x, 0, moveVelocity.z));
        characterController.Move(moveVelocity * Time.deltaTime);
        animator.SetFloat("MoveSpeed", new Vector3(moveVelocity.x, 0, moveVelocity.z).magnitude);
    }
}
