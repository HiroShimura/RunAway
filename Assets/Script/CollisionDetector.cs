using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class CollisionDetector : MonoBehaviour {
    [SerializeField] UnityEvent<Collider> onTriggerStay = new UnityEvent<Collider>();

    private void OnTriggerStay(Collider other) {
        onTriggerStay.Invoke(other);
    }
}
