using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public bool hasKey = false; // Indicateur pour savoir si le joueur poss�de la cl�

    // M�thode pour r�cup�rer la cl�
    public void PickUpKey()
    {
        hasKey = true;
    }
}
