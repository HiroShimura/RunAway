using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMove : MonoBehaviour {
    RaycastHit[] raycastHits = new RaycastHit[10];
    EnemyStatus status;
    NavMeshAgent agent;
    public bool usuallyMove = true;
    Vector3 destination;
    float distance = 0;

    void Start() {
        status = GetComponent<EnemyStatus>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update() {
        if (usuallyMove) {
            Debug.Log("UsuallyMove");
            if (distance <= 1) {
                destination.x = Random.Range(-8f, 8f);
                destination.z = Random.Range(-8f, 8f);
            }
            agent.destination = destination;
            distance = (destination - transform.position).magnitude;
            // Debug.Log(distance);
        }
        else if (!usuallyMove) {
            Debug.Log("ChasePlayer");
            distance = 0;
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
                agent.isStopped = false;
                agent.destination = collider.transform.position;
            }
            else {
                agent.isStopped = true;
                usuallyMove = true;
            }
        }
    }
}
