using System.Collections;
using UnityEngine;

public class Status : MonoBehaviour {
    public float Hp { get; protected set; } = 0.1f;
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

    [SerializeField] protected CapsuleCollider hitCollider;
    public bool AttackPossible { get; protected set; } = true;

    public bool BuildUpper { get; protected set; } = false;

    public bool Die { get; protected set; } = false;

    protected Animator animator;

    public virtual void Start() {
        stamina = staminaMax;
        size = 1;
        animator = GetComponent<Animator>();
    }

    void Update() {
        if (Hp <= 0) {
            OnDie();
        }
    }

    public void AttackPossibleSwitch(bool value) {
        AttackPossible = value;
    }

    public void InAttack(string name) {

        var target = GameObject.Find(name);
        var targetStatus = target.GetComponent<EnemyStatus>();
        StartCoroutine(AttackCroutine(targetStatus));
    }

    public void OnAttack() {
        Debug.Log("Attack");
    }

    public virtual void OnAttackFinished() {
        AttackPossibleSwitch(true);
    }

    public virtual void OnDie() {
        hitCollider.enabled = false;
        animator.SetTrigger("Die");
        Debug.Log(name + " is dead");
        StartCoroutine(DestroyCoroutine());
    }

    public virtual IEnumerator AttackCroutine<T>(T status) where T : Status {
        while (true) {
            if (Hp <= 0) {
                Die = true;
                break;
            }
            else if (AttackPossible || status.Hp <= 0) {
                break;
            }
            animator.SetTrigger("Attack");
            if (status.Hp > 0) {
                status.Hp -= Random.Range(0.1f, 0.5f);
                Debug.Log(status.name + "'s HP is " + status.Hp);
                if (status.Hp <= 0) {
                    BuildUpper = true;
                    break;
                }
                yield return new WaitForSeconds(2);
            }
        }
    }

    IEnumerator DestroyCoroutine() {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
