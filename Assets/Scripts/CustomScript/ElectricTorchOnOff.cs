using UnityEngine;

public class ElectricTorchOnOff : MonoBehaviour
{
    [SerializeField] private Light torchLight;            // Référence à la lumière de la torche
    [SerializeField] private Transform cameraTransform;   // Référence à la caméra du Player

    private bool _flashLightOn = false;                   // État actuel de la torche (allumée/éteinte)

    // Méthode publique pour activer/désactiver la torche
    public void ToggleTorch()
    {
        _flashLightOn = !_flashLightOn;
        torchLight.intensity = _flashLightOn ? 2.5f : 0f;
    }

    void Update()
    {
        // Aligne la rotation de la torche avec celle de la caméra pour qu'elle suive les mouvements de la vue
        if (cameraTransform != null)
        {
            transform.rotation = cameraTransform.rotation;
        }
    }
}
