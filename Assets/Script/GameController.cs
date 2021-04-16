using UnityEngine;

public class GameController : MonoBehaviour {
    [SerializeField] GameObject enemySpawner;
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] Score scoreManager;

    private void Awake() {
        Cursor.visible = false;
        Time.timeScale = 1;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (pausePanel.activeSelf) {
                Time.timeScale = 1;
                enemySpawner.SetActive(true);
                scoreManager.Stop = false;
                Cursor.visible = false;
                pausePanel.SetActive(false);
            }
            else if (!pausePanel.activeSelf) {
                Time.timeScale = 0;
                enemySpawner.SetActive(false);
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
        gameOverPanel.SetActive(true);
        Debug.Log("aaa");
        int score = scoreManager.TimeScore;
        Debug.Log("bbb");
        PlayerPrefs.SetInt("HighScore", score);
        Debug.Log("ccc");

    }
}
