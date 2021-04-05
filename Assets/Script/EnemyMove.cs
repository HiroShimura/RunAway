using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMove : MonoBehaviour {
    RaycastHit[] raycastHits = new RaycastHit[10];
    EnemyStatus enemyStatus;
    NavMeshAgent agent;
    public bool usuallyMove = true;
    Vector3 destination;
    float distance = 0;

    void Start() {
        enemyStatus = GetComponent<EnemyStatus>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update() {
        if (usuallyMove) {
            Debug.Log("UsuallyMove");
            if (distance <= 1) {
                destination.x = Random.Range(-8f * enemyStatus.Scale, 8f * enemyStatus.Scale);
                destination.z = Random.Range(-8f * enemyStatus.Scale, 8f * enemyStatus.Scale);
            }
            agent.destination = destination;
            distance = (destination - transform.position).magnitude;
            // Debug.Log(distance);
        }
        else if (!usuallyMove) {
            Debug.Log("ChasePlayer");
        }
    }

    public void OnDetectObject(Collider collider) {
        usuallyMove = false;
        if (collider.CompareTag("Player")) {
            var posDiff = collider.transform.position - transform.position;
            var distance = posDiff.magnitude;
            var direction = posDiff.normalized;
            var hitCount = Physics.RaycastNonAlloc(transform.position, direction, raycastHits, distance);
            if (hitCount == 0) {
                agent.destination = collider.transform.position;
            }
            else {
                this.distance = 0;
                usuallyMove = true;
            }
        }
    }
}
