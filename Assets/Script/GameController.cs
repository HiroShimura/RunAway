using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    [SerializeField] GameObject virtualCamera;
    [SerializeField] GameObject enemySpawner;
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] Score scoreManager;

    private void Awake() {
        PlayerPrefs.SetInt("HighScoreSwitch", 0);
        Cursor.visible = false;
        Time.timeScale = 1;
        for (int i = 0; i < 8; i++) {
            transform.GetChild(i).GetComponent<MeshRenderer>().enabled = false;
        }
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (pausePanel.activeSelf) {
                Time.timeScale = 1;
                scoreManager.Stop = false;
                Cursor.visible = false;
                virtualCamera.SetActive(true);
                pausePanel.SetActive(false);
            }
            else if (!pausePanel.activeSelf) {
                Time.timeScale = 0;
                scoreManager.Stop = true;
                Cursor.visible = true;
                virtualCamera.SetActive(false);
                pausePanel.SetActive(true);
            }
        }
    }

    public void EnemyDestroy() {
        scoreManager.TimeScore += 5000;
    }

    public void GameOver() {
        // Debug.Log("Game Over");
        scoreManager.Stop = true;
        virtualCamera.SetActive(false);
        Cursor.visible = true;
        int score = scoreManager.TimeScore;
        PlayerPrefs.SetInt("Score", score);
        int highScore = PlayerPrefs.GetInt("HighScore");
        if (score > highScore) {
            PlayerPrefs.SetInt("HighScoreSwitch", 1);
            PlayerPrefs.SetInt("HighScore", score);
        }
        StartCoroutine(GameOverCroutine());
    }

    IEnumerator GameOverCroutine() {
        yield return new WaitForSeconds(0.2f);
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
        DOVirtual.DelayedCall(4, () => SceneManager.LoadScene("ResultScene"));
    }
}
