using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMove : MonoBehaviour {
    [SerializeField] GameObject player;
    EnemyStatus status;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start() {
        status = GetComponent<EnemyStatus>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update() {
        agent.destination = player.transform.position;
    }
}
