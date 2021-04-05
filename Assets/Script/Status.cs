using UnityEngine;

public class Status : MonoBehaviour {
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

    public virtual void Start() {
        stamina = staminaMax;
        size = 1;
    }
}
