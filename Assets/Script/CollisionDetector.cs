using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class CollisionDetector : MonoBehaviour {
    [SerializeField] UnityEvent<Collider> onTriggerStay = new UnityEvent<Collider>();
    [SerializeField] UnityEvent<Collider> onAttackTrigger = new UnityEvent<Collider>();
    EnemyStatus enemyStatus;

    private void Awake() {
        enemyStatus = GameObject.Find(transform.root.gameObject.name).GetComponent<EnemyStatus>();
    }

    private void OnTriggerEnter(Collider other) {
        onAttackTrigger.Invoke(other);
    }

    private void OnTriggerStay(Collider other) {
        onTriggerStay.Invoke(other);
    }

    private void OnTriggerExit(Collider other) {
        enemyStatus.usuallyMove = true;
    }
}
