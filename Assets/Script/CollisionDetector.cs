using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class CollisionDetector : MonoBehaviour {
    [SerializeField] UnityEvent<Collider> onAttackTrriger = new UnityEvent<Collider>();
    [SerializeField] UnityEvent<Collider> onTriggerStay = new UnityEvent<Collider>();
    EnemyStatus enemyStatus;

    private void Awake() {
        enemyStatus = GameObject.Find("Slime_Green").GetComponent<EnemyStatus>();
    }

    private void OnTriggerStay(Collider other) {
        if (other.CompareTag("Player")) {
            onTriggerStay.Invoke(other);
        }
        else if (other.CompareTag("Enemy")) {
            onAttackTrriger.Invoke(other);
        }
    }

    private void OnTriggerExit(Collider other) {
        enemyStatus.usuallyMove = true;
    }
}
