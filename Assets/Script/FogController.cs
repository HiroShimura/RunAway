using System.Collections;
using UB.Simple2dWeatherEffects.Standard;
using UnityEngine;

public class FogController : MonoBehaviour {
    [SerializeField] GameObject player;
    D2FogsPE1 fogController;
    float foggy = 0.4f;
    void Start() {
        fogController = GetComponent<D2FogsPE1>();
        StartCoroutine(FoggyCroutine());
    }

    void Update() {
        if (player.transform.position.x <= -15 || player.transform.position.x >= 15 || player.transform.position.z <= -15 || player.transform.position.z >= 15) {
            if (fogController.Density >= foggy + 1.5f)
                return;
            fogController.Size = 1f;
            fogController.Density += Time.deltaTime;
        }
        else if (player.transform.position.x <= -12 || player.transform.position.x >= 12 || player.transform.position.z <= -12 || player.transform.position.z >= 12) {
            if (fogController.Density >= foggy + 1f)
                fogController.Density -= Time.deltaTime;
            else if (fogController.Density < foggy + 1f)
                fogController.Density += Time.deltaTime;
            else
                return;
            fogController.Size = 0.8f;
        }
        else if (player.transform.position.x <= -10 || player.transform.position.x >= 10 || player.transform.position.z <= -10 || player.transform.position.z >= 10) {
            if (fogController.Density >= foggy + 0.5f)
                fogController.Density -= Time.deltaTime;
            else if (fogController.Density < foggy + 0.5f)
                fogController.Density += Time.deltaTime;
            else
                return;
            fogController.Size = 0.5f;
        }
        else {
            if (fogController.Density <= foggy)
                return;
            fogController.Size = 0.3f;
            fogController.Density -= Time.deltaTime;
        }
    }

    IEnumerator FoggyCroutine() {
        while (true) {
            yield return new WaitForSeconds(10);
            foggy += 0.2f;
            if (foggy > 1.0f)
                break;
        }
    }
}
