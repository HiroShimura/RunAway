using System.Collections;
using UnityEngine;

public class EnemyStatus : Status {
    int size = 1;

    public float Hp { get; set; } = 5f;

    public override void Start() {
        base.Start();
    }

    void Update() {
        Stamina -= 0.5f;
        if (Stamina <= 0) {
            StartCoroutine(StaminaEmptyCoroutine());
        }
    }

    IEnumerator StaminaEmptyCoroutine() {
        yield return new WaitForSeconds(4);
        Stamina = StaminaMax;
    }
}
