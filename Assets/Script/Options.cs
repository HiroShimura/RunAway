using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour {
    [SerializeField] Slider camSensSlider;
    [SerializeField] Slider enemySpawnRateSlider;
    [SerializeField] Text highScore;
    string highScoreText;

    void Start() {
        highScoreText = highScore.text; // インスペクターのテキストを取得
        highScore.text = $"{highScoreText}{PlayerPrefs.GetInt("HighScore")}";
        // camSensSlider.value = PlayerPrefs.GetInt("CamSens");
        enemySpawnRateSlider.value = PlayerPrefs.GetInt("SpawnRate");
    }

    public void CamSensChanged() {
        // PlayerPrefs.SetInt("CamSens", (int)camSensSlider.value);
    }

    public void EnemySpawnRateChanged() {
        PlayerPrefs.SetInt("SpawnRate", (int)enemySpawnRateSlider.value);
    }
}
