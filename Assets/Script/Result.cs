using System.Collections;
using UnityEngine;

public class Result : MonoBehaviour {
    [SerializeField] GameObject player;
    [SerializeField] GameObject panel;
    Animator animator;
    public bool CoroutineStarted { get; set; } = false;

    void Start() {
        animator = player.GetComponent<Animator>();
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
        // if (PlayerPrefs.GetInt("HighScoreSwitch") == 1) {
        animator.SetBool("HighScore", true);
        // }
        yield return new WaitForSeconds(3);
        panel.SetActive(true);
    }
}
