using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {
    [SerializeField] GameObject obstacle0;
    [SerializeField] GameObject obstacle1;
    [SerializeField] GameObject obstacle2;
    [SerializeField] GameObject obstacle3;
    [SerializeField] GameObject obstacle4;
    GameObject[] obstacles;
    int obstacleNum;
    void Start() {
        obstacles = new GameObject[] { obstacle0, obstacle1, obstacle2, obstacle3, obstacle4, };
        obstacleNum = Random.Range(10, 21); // 障害物はランダムで10～20個
        for (int i = 0; i < obstacleNum; i++) {

        }
    }

    // https://soft-rime.com/post-3941/
    void Update() {

    }
}
