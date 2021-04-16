using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Spawner : MonoBehaviour {
    [SerializeField] Status playerStatus;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Score scoreManager;

    public int Counter { get; set; } = 0;
    int spawnRate;
    int[] spawnRateArray;

    private void Awake() {
        spawnRateArray = new int[] { 11, 9, 7, 5, 3 };
    }

    void OnEnable() {
        spawnRate = spawnRateArray[PlayerPrefs.GetInt("SpawnRate", 2)];
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop() {
        while (true) {
            var distanceVector = new Vector3(Random.Range(10, 16), 0);
            var spawnPos = Quaternion.Euler(0, Random.Range(0f, 360f), 0) * distanceVector;
            if (NavMesh.SamplePosition(spawnPos, out NavMeshHit navMeshHit, distanceVector.x, NavMesh.AllAreas)) {
                Instantiate(enemyPrefab, navMeshHit.position, Quaternion.identity);
                Counter++;
                scoreManager.TimeScore += 500;
                yield return new WaitForSeconds(spawnRate);
            }
            if (playerStatus.Hp <= 0) {
                break;
            }
        }
    }
}
