using UnityEngine;

public class GameController : MonoBehaviour {
    [SerializeField] GameObject pausePanel;
    [SerializeField] Score score;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (pausePanel.activeSelf) {
                Time.timeScale = 1;
                score.Stop = false;
                pausePanel.SetActive(false);
            }
            else if (!pausePanel.activeSelf) {
                Time.timeScale = 0;
                score.Stop = true;
                pausePanel.SetActive(true);
            }
        }
    }

    public void EnemyDestroy() {
        score.TimeScore += 5000;
    }

    public void GameOver() {
        Debug.Log("Game Over");
    }
}
