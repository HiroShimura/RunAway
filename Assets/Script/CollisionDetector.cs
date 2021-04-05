using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class CollisionDetector : MonoBehaviour {
    [SerializeField] UnityEvent<Collider> onTriggerStay = new UnityEvent<Collider>();
    EnemyMove enemy;

    private void Awake() {
        enemy = GameObject.Find("Slime_Green").GetComponent<EnemyMove>();
    }

    private void OnTriggerStay(Collider other) {
        onTriggerStay.Invoke(other);
    }

    private void OnTriggerExit(Collider other) {
        enemy.usuallyMove = true;
    }
}
