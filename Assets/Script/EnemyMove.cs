using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMove : MonoBehaviour {
    RaycastHit[] raycastHits = new RaycastHit[10];
    [SerializeField] LayerMask layerMask;
    EnemyStatus enemyStatus;
    NavMeshAgent agent;
    Vector3 destination;
    float distance = 0;

    void Start() {
        enemyStatus = GetComponent<EnemyStatus>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update() {
        if (enemyStatus.usuallyMove) {
            // なぜかdistance <= 1じゃないと上手くいかない
            if (distance <= 1) {
                destination.x = Random.Range(-5f * enemyStatus.Scale, 5f * enemyStatus.Scale);
                destination.z = Random.Range(-5f * enemyStatus.Scale, 5f * enemyStatus.Scale);
            }
            Debug.Log("UsuallyMove");
            agent.destination = destination;
            distance = (destination - transform.position).magnitude;

        }
        else if (!enemyStatus.usuallyMove) {
            distance = 0;
            Debug.Log("ChasePlayer");
        }
    }

    public void OnDetectObject(Collider collider) {
        enemyStatus.usuallyMove = false;
        if (collider.CompareTag("Player")) {
            var posDiff = collider.transform.position - transform.position;
            var distance = posDiff.magnitude;
            var direction = posDiff.normalized;
            var hitCount = Physics.RaycastNonAlloc(transform.position, direction, raycastHits, distance, layerMask);
            if (hitCount == 0) {
                agent.destination = collider.transform.position;
            }
            else {
                this.distance = 0;
                enemyStatus.usuallyMove = true;
            }
        }
    }

    public void Attack(Collider value) {
        if (!enemyStatus.AttackPossible) {
            return;
        }
        agent.destination = transform.position;
        transform.LookAt(value.transform.position.normalized);
        enemyStatus.InAttack(value.name);
        enemyStatus.BuildUp();
    }

    public void OnAttack() {
        Debug.Log("Attack");
    }

    public void OnAttackFinished() {
        Debug.Log("Finished Attack");
    }
}
