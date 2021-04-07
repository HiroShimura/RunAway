using System.Collections;
using UnityEngine;

public class Status : MonoBehaviour {
    public float Hp { get; protected set; }
    float stamina;
    public float Stamina {
        get => stamina;
        set => stamina = value > staminaMax ? staminaMax : value < 0 ? 0 : value;
    }
    [SerializeField] float staminaMax = 100f;
    public float StaminaMax => staminaMax;
    public bool StaminaEmpty { get; set; } = false;
    int size;
    public int Size {
        get => size;
        set => size = value > 5 ? 5 : value;
    }
    public float Scale { get; set; }
    public bool FriendlyFire { get; set; } = false;

    protected Animator animator;

    public virtual void Start() {
        stamina = staminaMax;
        size = 1;
        animator = GetComponent<Animator>();
    }

    public void Attack<T>(T value) where T : Status {
        value.Hp -= Random.Range(0.1f, 0.5f);
        animator.SetTrigger("Attack");
    }

    public void Die() {
        animator.SetTrigger("Die");
        StartCoroutine(DestroyCoroutine());
    }

    IEnumerator DestroyCoroutine() {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
