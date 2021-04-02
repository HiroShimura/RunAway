﻿using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour {
    [SerializeField] Animator animator;

    Status status;
    CharacterController characterController;
    Transform _transform;
    Vector3 moveVelocity;
    float moveSpeed;
    float walkSpeed = 1.7f;
    float topSpeed = 3.4f;

    // Start is called before the first frame update
    void Start() {
        status = GetComponent<Status>();
        characterController = GetComponent<CharacterController>();
        _transform = transform;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.LeftShift)) {
            moveSpeed = topSpeed;
            status.Stamina -= 0.5f;
        }
        else {
            moveSpeed = walkSpeed;
            status.Stamina += 0.2f;
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
