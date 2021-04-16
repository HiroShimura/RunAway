using UB.Simple2dWeatherEffects.Standard;
using UnityEngine;

public class FogController : MonoBehaviour {
    [SerializeField] GameObject player;
    D2FogsPE1 fogController;
    void Start() {
        fogController = GetComponent<D2FogsPE1>();
    }

    void Update() {
        if (player.transform.position.x <= -15 || player.transform.position.x >= 15 || player.transform.position.z <= -15 || player.transform.position.z >= 15) {
            if (fogController.Density >= 4.5f) {
                return;
            }
            fogController.Size = 0.2f;
            fogController.Density += Time.deltaTime;
        }
        else if (player.transform.position.x <= -12 || player.transform.position.x >= 12 || player.transform.position.z <= -12 || player.transform.position.z >= 12) {
            if (fogController.Density >= 3.8f) {
                fogController.Density -= Time.deltaTime;
            }
            else if (fogController.Density <= 3f) {
                fogController.Density += Time.deltaTime;
            }
            else {
                return;
            }
        }
        else if (player.transform.position.x <= -10 || player.transform.position.x >= 10 || player.transform.position.z <= -10 || player.transform.position.z >= 10) {
            if (fogController.Density >= 3f) {
                fogController.Density -= Time.deltaTime;
            }
            else if (fogController.Density <= 2.4f) {
                fogController.Density += Time.deltaTime;
            }
            else {
                return;
            }
        }
        else {
            if (fogController.Density <= 0.4f) {
                return;
            }
            fogController.Size = 0.3f;
            fogController.Density -= Time.deltaTime;
        }
    }
}
