using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public bool hasKey = false; // Indicateur pour savoir si le joueur possède la clé

    // Méthode pour récupérer la clé
    public void PickUpKey()
    {
        hasKey = true;
    }
}
