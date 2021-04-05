using UnityEngine;

public class EnemyStatus : Status {
    public float Hp { get; set; } = 5f;
    GameObject rig;
    SphereCollider collisionDetectorCollider;

    public override void Start() {
        base.Start();
        rig = GameObject.Find("RIG");
        collisionDetectorCollider = GameObject.Find("CollisionDetector").GetComponent<SphereCollider>();
        Scale = 1 + Size * 0.2f;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.R)) {
            Size++;
            Scale = 1 + Size * 0.2f;
            rig.transform.localScale = new Vector3(Size * 50, Size * 50, Size * 50);
            collisionDetectorCollider.radius = 5 * Scale;
        }
    }

    /*
IEnumerator StaminaEmptyCoroutine() {
    yield return new WaitForSeconds(2);
    Stamina = StaminaMax;
}
*/
}
