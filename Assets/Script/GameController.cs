using UnityEngine;

public class GameController : MonoBehaviour {
    [SerializeField] GameObject enemySpawner;
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] Score scoreManager;

    private void Awake() {
        Cursor.visible = false;
        Time.timeScale = 1;
        for (int i = 0; i < 8; i++) {
            transform.GetChild(i).GetComponent<MeshRenderer>().enabled = false;
        }
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (gameOverPanel.activeSelf) {
                return;
            }
            if (pausePanel.activeSelf) {
                Time.timeScale = 1;
                scoreManager.Stop = false;
                Cursor.visible = false;
                pausePanel.SetActive(false);
            }
            else if (!pausePanel.activeSelf) {
                Time.timeScale = 0;
                scoreManager.Stop = true;
                Cursor.visible = true;
                pausePanel.SetActive(true);
            }
        }
    }

    public void EnemyDestroy() {
        scoreManager.TimeScore += 5000;
    }

    public void GameOver() {
        Debug.Log("Game Over");
        scoreManager.Stop = true;
        Time.timeScale = 0;
        Cursor.visible = true;
        gameOverPanel.SetActive(true);
        int score = scoreManager.TimeScore;
        int highScore = PlayerPrefs.GetInt("HighScore");
        if (score > highScore) {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
}
