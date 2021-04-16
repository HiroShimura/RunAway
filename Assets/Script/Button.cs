using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour {
    public void LoadTitleScene() => SceneManager.LoadScene("TitleScene");
    public void LoadGameScene() => SceneManager.LoadScene("GameScene");
    public void LoadOptionScene() => SceneManager.LoadScene("OptionScene");
}
