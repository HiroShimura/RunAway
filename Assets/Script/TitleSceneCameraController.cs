using UnityEngine;

public class TitleSceneCameraController : MonoBehaviour {
    [SerializeField] Camera mainCamera;
    void Update() {
        mainCamera.transform.Rotate(new Vector3(0, 0.05f, 0));
    }
}
