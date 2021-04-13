using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ObstacleSpawner : MonoBehaviour {
    [SerializeField] GameObject[] obstacles;
    List<int> angles;
    Vector3 offset;
    int obstacleNum;
    int num = 0; // 置かれている障害物の総数
    void Start() {
        obstacleNum = Random.Range(20, 31); // 配置する障害物の数を決定(下のfor文の構造上、最大値+1～2個配置される可能性あり)
        int distance = Random.Range(5, 8); // 障害物を出現させる円の半径を決定
        offset = new Vector3(distance, 0); // 決定した半径をVector3に格納

        while (true) {
            // 置かれている障害物が最初に決めた総数以上なら終了
            if (num >= obstacleNum) {
                break;
            }
            // 二周目以降は更新したdistanceを足して半径を広げていく
            if (num != 0) {
                distance = Random.Range(5, 8);
                offset += new Vector3(distance, 0);
            }
            angles = new List<int> { 0, 30, 60, 90, 120, 150, 180, 210, 240, 270, 300, 330 }; // 障害物を配置する円の角度リストの初期化

            int obstacleNumInCircle = Random.Range(1, 4); // 一つの円に配置する障害物の数(1～3個)
            for (int i = 0; i < obstacleNumInCircle; i++) {
                int obstacleIndex = Random.Range(0, obstacles.Length); // 障害物を格納した配列のインデックスをランダムで選択
                int angleIndex = Random.Range(0, angles.Count); // 配置する角度のリストのインデックスをランダムで選択
                var rotate = Quaternion.Euler(0, angles[angleIndex], 0) * offset; // 選択された角度と半径を掛け合わせる
                var spawnPos = Vector3.zero + rotate; // 配置するポジションを決定
                if (NavMesh.SamplePosition(spawnPos, out NavMeshHit navMeshHit, distance, NavMesh.AllAreas)) {
                    Instantiate(obstacles[obstacleIndex], navMeshHit.position, Quaternion.identity);
                    Debug.Log("障害物を置ける");
                    angles.RemoveAt(angleIndex); // 一つの円で角度が被らないようにリストから除去
                    num++; // 障害物の総数を記録
                }
            }
        }

        // https://soft-rime.com/post-3941/
    }
}
