using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    Text text;
    string score;

    public int TimeScore { get; set; } = 0;

    void Start() {
        text = GetComponent<Text>();
        score = text.text;
    }

    void Update() {
        TimeScore++;
        text.text = $"{score}{TimeScore}";
    }
}
