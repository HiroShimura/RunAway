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

    private void Update() {
        if (enemyStatus.usuallyMove) {
            Debug.Log("UsuallyMove");
            if (distance <= 1) {
                destination.x = Random.Range(-8f * enemyStatus.Scale, 8f * enemyStatus.Scale);
                destination.z = Random.Range(-8f * enemyStatus.Scale, 8f * enemyStatus.Scale);
            }
            else if (!enemyStatus.usuallyMove) {
                return;
            }
            agent.destination = destination;
            distance = (destination - transform.position).magnitude;
        }
        else if (!enemyStatus.usuallyMove) {
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

    public void Attack(Collider collider) {
        EnemyStatus enemy = GameObject.Find(collider.name).GetComponent<EnemyStatus>();
        if (collider.CompareTag("Enemy")) {
            Debug.Log(enemy.name);
            transform.LookAt(collider.transform.position);
        }
        enemyStatus.Damage(Random.Range(0.1f, 0.5f));
        enemyStatus.SetAttack();
    }
}
