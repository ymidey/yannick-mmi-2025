using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] private ElectricTorchOnOff torchScript; // Référence au script de la torche

    public void OnFlash(InputValue value)
    {
        torchScript.ToggleTorch();
    }
}