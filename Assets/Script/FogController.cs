using UB.Simple2dWeatherEffects.Standard;
using UnityEngine;

public class FogController : MonoBehaviour {
    [SerializeField] GameObject player;
    D2FogsPE1 fogController;
    void Start() {
        fogController = GetComponent<D2FogsPE1>();
    }

    void Update() {
        if (player.transform.position.x <= -25 || player.transform.position.x >= 25 || player.transform.position.z <= -25 || player.transform.position.z >= 25) {
            if (fogController.Density >= 4.5f) {
                return;
            }
            fogController.Size = 0.2f;
            fogController.Density += Time.deltaTime;
        }
        else if (player.transform.position.x <= -20 || player.transform.position.x >= 20 || player.transform.position.z <= -20 || player.transform.position.z >= 20) {
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
        else if (player.transform.position.x <= -16 || player.transform.position.x >= 16 || player.transform.position.z <= -16 || player.transform.position.z >= 16) {
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
