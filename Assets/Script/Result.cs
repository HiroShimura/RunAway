using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour {
    [SerializeField] GameObject player;
    [SerializeField] GameObject panel;
    [SerializeField] GameObject score;
    [SerializeField] GameObject highScore;
    Animator animator;
    public bool CoroutineStarted { get; set; } = false;

    void Start() {
        Time.timeScale = 1;
        animator = player.GetComponent<Animator>();
        score.GetComponent<Text>().text += PlayerPrefs.GetInt("Score");
    }

    private void Update() {
        if (Camera.main.transform.rotation.x >= 0) {
            Camera.main.transform.RotateAround(transform.position, Vector3.right, -24 * Time.deltaTime); // position = new Vector3(0, transform.position.y + Time.deltaTime, -2); 
        }
        else if (Camera.main.transform.rotation.x < 0 && !CoroutineStarted) {
            StartCoroutine(ResultCroutine());
        }
    }

    IEnumerator ResultCroutine() {
        CoroutineStarted = true;
        yield return new WaitForSeconds(1);
        score.SetActive(true);
        if (PlayerPrefs.GetInt("HighScoreSwitch") == 1) {
            animator.SetBool("HighScore", true);
            yield return new WaitForSeconds(2);
            highScore.SetActive(true);
        }
        else {
            animator.SetTrigger("Result");
        }
        yield return new WaitForSeconds(3);
        panel.SetActive(true);
    }
}
