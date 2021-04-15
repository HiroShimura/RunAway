using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    Text text;
    string score;
    public bool Stop { get; set; } = false;

    public int TimeScore { get; set; } = 0;

    void Start() {
        text = GetComponent<Text>();
        score = text.text;
    }

    void Update() {
        if (Stop) {
            text.text = $"{score}{TimeScore}";
        }
        else {
            TimeScore++;
            text.text = $"{score}{TimeScore}";
        }
    }
}
