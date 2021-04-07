using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Spawner : MonoBehaviour {
    [SerializeField] Status playerStatus;
    [SerializeField] GameObject enemyPrefab;
    public int Counter { get; set; } = 0;

    void Start() {
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop() {
        while (true) {
            var distanceVector = new Vector3(10, 0);
            var spawnPosFromPlayer = Quaternion.Euler(0, Random.Range(0f, 360f), 0) * distanceVector;
            var spawnPos = playerStatus.transform.position + spawnPosFromPlayer;
            if (NavMesh.SamplePosition(spawnPos, out NavMeshHit navMeshHit, 10, NavMesh.AllAreas)) {
                Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
                Counter++;
            }
            yield return new WaitForSeconds(10);
            if (playerStatus.Hp <= 0) {
                break;
            }
        }
    }
}
