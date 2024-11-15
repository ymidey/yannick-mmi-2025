using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] private ElectricTorchOnOff torchScript; // R�f�rence au script de la torche

    public void OnFlash(InputValue value)
    {
        torchScript.ToggleTorch();
    }
}