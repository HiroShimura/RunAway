using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] Animator animator;

    Status status;
    CharacterController characterController;
    Vector3 moveVelocity;
    float moveSpeed;
    int walkSpeed = 1;
    int topSpeed = 2;
    Quaternion targetRotation;
    float rotationSpeed;

    void Awake() {
        status = GetComponent<Status>();
        characterController = GetComponent<CharacterController>();
        targetRotation = transform.rotation;
    }

    void Update() {
        if (status.Hp <= 0) {
            status.OnDie();
        }
        // LShiftでダッシュ
        if (Input.GetKey(KeyCode.LeftShift)) {
            // スタミナ管理
            // スタミナが0になると自動的にwalkSpeedへ変更、Emptyフラグをtrueに変更
            if (status.Stamina <= 0) {
                status.SetStaminaIsEmpty(true);
                moveSpeed = walkSpeed;
                status.Stamina += 0.2f;
            }
            // Emptyフラグがtrueの間はLShiftを押してもwalkSpeedがセットされる
            // スタミナが回復し切ったらフラグをfalseへ変更
            else if (status.GetStaminaIsEmpty()) {
                moveSpeed = walkSpeed;
                status.Stamina += 0.2f;
                if (status.Stamina >= status.StaminaMax) {
                    status.SetStaminaIsEmpty(false);
                }
            }
            // スタミナが空になっていない状態
            else {
                moveSpeed = topSpeed;
                status.Stamina -= 0.5f;
            }
        }
        else {
            moveSpeed = walkSpeed;
            // Emptyフラグがtrueの時は回復速度が少し遅い
            if (status.GetStaminaIsEmpty()) {
                status.Stamina += 0.2f;
            }
            else {
                status.Stamina += 0.3f;
            }
        }
        var horizontal = Input.GetAxis("Horizontal");
        var horizontalRotation = Quaternion.AngleAxis(Camera.main.transform.eulerAngles.y, Vector3.up);
        var vertical = Input.GetAxis("Vertical");
        moveVelocity = horizontalRotation * new Vector3(horizontal, 0, vertical).normalized;
        rotationSpeed = 550 * Time.deltaTime;
        if (Input.GetButtonDown("Jump")) {
            animator.SetTrigger("Jump");
        }
        if (moveVelocity.magnitude > 0.5f) {
            targetRotation = Quaternion.LookRotation(moveVelocity, Vector3.up);
        }
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed);
        characterController.Move(moveVelocity * moveSpeed * Time.deltaTime);

        animator.SetFloat("MoveSpeed", moveVelocity.magnitude * moveSpeed);

    }
}
