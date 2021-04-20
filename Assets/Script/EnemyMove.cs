using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMove : MonoBehaviour {
    RaycastHit[] raycastHits = new RaycastHit[10];
    [SerializeField] LayerMask layerMask;
    EnemyStatus enemyStatus;
    NavMeshAgent agent;
    Vector3 offset;
    float distance = 0;

    void Start() {
        enemyStatus = GetComponent<EnemyStatus>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update() {
        if (enemyStatus.usuallyMove) {
            agent.isStopped = false;
            var path = new NavMeshPath();
            // なぜかdistance <= 1じゃないと上手くいかない
            if (distance <= 1) {
                offset.x = Random.Range(-5f * enemyStatus.Scale, 5f * enemyStatus.Scale);
                offset.z = Random.Range(-5f * enemyStatus.Scale, 5f * enemyStatus.Scale);
            }
            Vector3 destination = offset + transform.position;
            if (destination.x < -20 || destination.x > 20 || destination.z < -20 || destination.z > 20 || !NavMesh.CalculatePath(transform.position, destination, NavMesh.AllAreas, path)) {
                distance = 0;
            }
            else {
                agent.SetDestination(destination); // destination = destination;
                distance = (offset - transform.position).magnitude;
            }
        }
        /*
        else if (!enemyStatus.usuallyMove) {
            if (enemyStatus.Hp <= 0) {
                agent.isStopped = true;
            }
        }
        */
    }

    public void OnDetectObject(Collider collider) {
        agent.isStopped = false;
        if (collider.CompareTag("Player")) {
            enemyStatus.usuallyMove = false;
            var posDiff = collider.transform.position - transform.position;
            var distance = posDiff.magnitude;
            var direction = posDiff.normalized;
            var hitCount = Physics.RaycastNonAlloc(transform.position, direction, raycastHits, distance, layerMask);
            if (hitCount == 0) {
                agent.SetDestination(collider.transform.position); // destination = collider.transform.position;
            }
            else {
                this.distance = 0;
                agent.isStopped = true;
                enemyStatus.usuallyMove = true;
            }
        }
        else {
            return;
            /*
            agent.isStopped = true;
            enemyStatus.usuallyMove = true;
            */
        }
    }

    public void Attack(Collider value) {
        if (!enemyStatus.AttackPossible) {
            return;
        }
        enemyStatus.AttackPossibleSwitch(false);
        enemyStatus.usuallyMove = false;
        agent.isStopped = true;
        transform.LookAt(value.transform.position);
        enemyStatus.InAttack(value.name);
        if (enemyStatus.BuildUpper) {
            enemyStatus.BuildUp();
            enemyStatus.usuallyMove = true;
        }
    }
}
