using UnityEngine;

public class GameController : MonoBehaviour {
    [SerializeField] Score score;

    public void EnemyDestroy() {
        score.TimeScore += 5000;
    }
}
