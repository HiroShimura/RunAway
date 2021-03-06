using UnityEngine;
using UnityEngine.AI;

public class EnemyStatus : Status {
    GameObject rig;
    [SerializeField] SphereCollider detectionRangeCollider;
    [SerializeField] float detectionRange = 5f;
    [SerializeField] GameObject front;
    BoxCollider frontAttackRange;
    NavMeshAgent agent;
    public bool usuallyMove = true;
    public bool ChasePlayer { get; set; } = true;


    public EnemyStatus() {
        Hp = 1f;
    }

    public override void Start() {
        base.Start();
        int counter = GameObject.Find("EnemySpawner").GetComponent<Spawner>().Counter;
        name = $"Enemy {counter}";
        rig = transform.GetChild(1).gameObject;
        // rig.name = name + " RIG";
        // Debug.Log(rig.name);
        // GameObject.Find("RIG").name = name + " RIG";
        // rig = GameObject.Find(name + " RIG");
        detectionRangeCollider.radius = detectionRange;
        frontAttackRange = front.GetComponent<BoxCollider>();
        agent = GetComponent<NavMeshAgent>();
        Scale = 1 + Size * 0.2f;
    }

    /*
    public void BuildUp() {
        Size++;
        Hp += Size;
        Scale = 1 + Size * 0.2f;
        rig.transform.localScale = new Vector3(Size * 50, Size * 50, Size * 50);
        detectionRangeCollider.radius = detectionRange * Scale;
        float colliderPos = 0.5f + 0.5f * Size;
        front.transform.localPosition = new Vector3(0, 0, colliderPos);
        frontAttackRange.size = new Vector3(Size, 1, 0.1f);
        hitCollider.radius = 0.45f * Size;
        agent.radius += 0.5f;
        BuildUpper = false;
    }
    */

    public override void OnAttackFinished() {
        base.OnAttackFinished();
        usuallyMove = true;
    }

    public override void OnDie() {
        front.SetActive(false);
        hitCollider.enabled = false;
        usuallyMove = false;
        agent.isStopped = true;
        gameController.EnemyDestroy();
        base.OnDie();
    }
}
