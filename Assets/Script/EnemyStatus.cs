using UnityEngine;

public class EnemyStatus : Status {
    GameObject rig;
    [SerializeField] SphereCollider detectionRangeCollider;
    [SerializeField] float detectionRange = 5f;
    [SerializeField] GameObject front;
    BoxCollider frontAttackRange;
    public bool usuallyMove = true;
    public bool ChasePlayer { get; set; } = true;

    public EnemyStatus() {
        Hp = 1f;
    }

    public override void Start() {
        base.Start();
        int counter = GameObject.Find("Spawner").GetComponent<Spawner>().Counter;
        name = $"Enemy {counter}";
        GameObject.Find("RIG").name = name + " RIG";
        rig = GameObject.Find(name + " RIG");
        detectionRangeCollider.radius = detectionRange;
        frontAttackRange = front.GetComponent<BoxCollider>();
        Scale = 1 + Size * 0.2f;
    }

    void Update() {
        if (Hp <= 0) {
            OnDie();
        }
    }

    public void BuildUp() {
        Size++;
        Hp *= Size;
        Scale = 1 + Size * 0.2f;
        rig.transform.localScale = new Vector3(Size * 50, Size * 50, Size * 50);
        detectionRangeCollider.radius = detectionRange * Scale;
        float colliderPos = 0.5f + 0.5f * Size;
        front.transform.localPosition = new Vector3(0, 0, colliderPos);
        frontAttackRange.size = new Vector3(Size, 1, 0.1f);
        hitCollider.radius = 0.45f * Size;
        BuildUpper = false;
    }

    public override void OnAttackFinished() {
        base.OnAttackFinished();
        usuallyMove = true;
    }

    public override void OnDie() {
        front.SetActive(false);
        hitCollider.enabled = false;
        usuallyMove = false;
        base.OnDie();
    }
}
