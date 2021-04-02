using UnityEngine;

public class Status : MonoBehaviour {
    float stamina;
    [SerializeField] float staminaMax = 200f;

    public float Stamina {
        get => stamina;
        set => stamina = value > staminaMax ? staminaMax : value < 0 ? 0 : value;
    }
    public float StaminaMax => staminaMax;
    public bool StaminaEmpty { get; set; } = false;

    public virtual void Start() {
        stamina = staminaMax;
    }
}
