using UnityEngine;

public class EnemyStatus : Status {
    GameObject rig;
    [SerializeField] SphereCollider detectionRangeCollider;
    [SerializeField] float detectionRange = 5f;
    [SerializeField] GameObject front;
    BoxCollider frontAttackRange;
    [SerializeField] GameObject left;
    BoxCollider leftSideAttackRange;
    [SerializeField] GameObject right;
    BoxCollider rightSideAttackRange;
    [SerializeField] CapsuleCollider hit;
    public bool usuallyMove = true;
    public bool ChasePlayer { get; set; } = true;

    public EnemyStatus() {
        Hp = 5f;
    }

    public override void Start() {
        base.Start();
        int counter = GameObject.Find("Spawner").GetComponent<Spawner>().Counter;
        name = $"Enemy {counter}";
        rig = GameObject.Find("RIG");
        detectionRangeCollider.radius = detectionRange;
        frontAttackRange = front.GetComponent<BoxCollider>();
        leftSideAttackRange = left.GetComponent<BoxCollider>();
        rightSideAttackRange = right.GetComponent<BoxCollider>();
        Scale = 1 + Size * 0.2f;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.R)) {
            BuildUp();
        }
    }

    public void BuildUp() {
        Size++;
        Hp *= Size;
        Scale = 1 + Size * 0.2f;
        rig.transform.localScale = new Vector3(Size * 50, Size * 50, Size * 50);
        detectionRangeCollider.radius = detectionRange * Scale;
        float attackRangeColliderPos = 0.5f + 0.5f * Size;
        front.transform.localPosition = new Vector3(0, 0, attackRangeColliderPos);
        left.transform.localPosition = new Vector3(-attackRangeColliderPos, 0, 0);
        right.transform.localPosition = new Vector3(attackRangeColliderPos, 0, 0);
        frontAttackRange.size = new Vector3(Size, 1, 0.1f);
        leftSideAttackRange.size = new Vector3(0.05f, 1, Size);
        rightSideAttackRange.size = new Vector3(0.05f, 1, Size);
        hit.radius = 0.45f * Size;
    }
}
