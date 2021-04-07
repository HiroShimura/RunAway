using UnityEngine;

public class EnemyStatus : Status {
    GameObject rig;
    SphereCollider detectionRangeCollider;
    [SerializeField] float detectionRange = 5f;
    public bool usuallyMove = true;
    public bool ChasePlayer { get; set; } = true;

    public EnemyStatus() {
        Hp = 5f;
    }

    public override void Start() {
        base.Start();
        rig = GameObject.Find("RIG");
        detectionRangeCollider = GameObject.Find("DetectionRangeCollider").GetComponent<SphereCollider>();
        detectionRangeCollider.radius = detectionRange;
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
        detectionRangeCollider.radius = 5 * Scale;
    }
}
