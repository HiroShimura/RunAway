using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour {
    [SerializeField] private float moveSpeed = 3;
    [SerializeField] private float jumpPower = 3;
    [SerializeField] private Animator animator;
    private CharacterController characterController;
    private Transform _transform;
    private Vector3 moveVelocity;

    private bool IsGrounded {
        get {
            var ray = new Ray(_transform.position + new Vector3(0, 0.1f), Vector3.down);
            var raycastHits = new RaycastHit[1];
            var hitCount = Physics.RaycastNonAlloc(ray, raycastHits, 0.2f);
            return hitCount >= 1;
        }
    }

    void Start() {
        characterController = GetComponent<CharacterController>();
        _transform = transform;
    }

    // Update is called once per frame
    void Update() {
        // Debug.Log(IsGrounded ? "地上にいます" : "空中です");
        moveVelocity.x = Input.GetAxis("Mouse X") * moveSpeed;
        moveVelocity.z = Input.GetAxis("Vertical") * moveSpeed;
        _transform.LookAt(_transform.position + new Vector3(moveVelocity.x, 0, moveVelocity.z));
        if (IsGrounded) {
            if (Input.GetButtonDown("Jump")) {
                Debug.Log("ジャンプ！");
                moveVelocity.y = jumpPower;
            }
        }
        else {
            moveVelocity.y += Physics.gravity.y * Time.deltaTime;
        }
        characterController.Move(moveVelocity * Time.deltaTime);
        // animator.SetFloat("MoveSpeed", new Vector3(moveVelocity.x, 0, moveVelocity.z).magnitude);
    }
}
