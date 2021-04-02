using UnityEngine;
using UnityEngine.UI;

public class StaminaGauge : MonoBehaviour {
    [SerializeField] Status status;
    [SerializeField] Image fillImage;
    void Start() {
        status.GetComponent<Status>();
    }

    void Update() {
        fillImage.fillAmount = status.Stamina / status.StaminaMax;
    }
}
