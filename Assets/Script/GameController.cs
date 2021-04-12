using UnityEngine;

public class GameController : MonoBehaviour {
    [SerializeField] Score score;

    void Start() {

    }

    void Update() {

    }

    private void OnDestroy() {
        score.TimeScore += 100000;
    }
}
