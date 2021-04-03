using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMove : MonoBehaviour {
    RaycastHit[] raycastHits = new RaycastHit[10];
    EnemyStatus status;
    NavMeshAgent agent;

    void Start() {
        status = GetComponent<EnemyStatus>();
        agent = GetComponent<NavMeshAgent>();
    }

    public void OnDetectObject(Collider collider) {
        if (collider.CompareTag("Player")) {
            var posDiff = collider.transform.position - transform.position;
            var distance = posDiff.magnitude;
            var direction = posDiff.normalized;
            var hitCount = Physics.RaycastNonAlloc(transform.position, direction, raycastHits, distance);
            if (hitCount == 0) {
                agent.isStopped = false;
                agent.destination = collider.transform.position;
            }
            else {
                agent.isStopped = true;
            }
        }
    }
}
