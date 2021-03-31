using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] Animator animator;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.W)) {
            animator.SetFloat("MoveSpeed", 0.5f);
        }
    }
}
