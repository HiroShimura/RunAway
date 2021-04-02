using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    string text;
    int timeScore = 0;

    void Start() {
        text = GetComponent<Text>().text;
    }

    // Update is called once per frame
    void Update() {
        timeScore++;
        GetComponent<Text>().text = $"{text}{timeScore}";
    }
}
