using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField] GameObject playerObject;

    private Vector3 offset;

    void Start() {
        offset = transform.position - playerObject.transform.position;
    }

    void Update() {
        transform.position = playerObject.transform.position + offset;
    }
}
