using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class CollisionDetector : MonoBehaviour {
    [SerializeField] UnityEvent<Collider> onTriggerStay = new UnityEvent<Collider>();
    EnemyStatus enemyStatus;

    private void Awake() {
        enemyStatus = GameObject.Find(transform.root.gameObject.name).GetComponent<EnemyStatus>();
    }

    private void OnTriggerStay(Collider other) {
        onTriggerStay.Invoke(other);
    }

    private void OnTriggerExit(Collider other) {
        enemyStatus.usuallyMove = true;
    }
}
