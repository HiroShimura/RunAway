using UnityEngine;

public class GameController : MonoBehaviour {
    [SerializeField] Score score;

    void Start() {

    }

    void Update() {

    }

    public void EnemyDestroy() {
        score.TimeScore += 100000;
    }
}
