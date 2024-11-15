using System.Security.Cryptography;
using UnityEngine;

public class CollectibleLeaf : MonoBehaviour
{
    private bool isPlayerNearby = false; // Pour savoir si le joueur est proche
    public GameObject interactionText; // Texte d'interaction à afficher

    private PlayerInventory playerInventory;

    void Start()
    {
        // Assure-toi que le texte est désactivé au début
        if (interactionText != null)
        {
            interactionText.SetActive(false);
        }

        // Récupère l'inventaire du joueur
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            playerInventory = player.GetComponent<PlayerInventory>();
        }
    }

    void Update()
    {
        // Vérifie si le joueur est proche et appuie sur "E"
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            CollectLeaf();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Si le joueur entre dans la zone
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            if (interactionText != null)
            {
                interactionText.SetActive(true); // Affiche le texte d'interaction
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Si le joueur quitte la zone
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            if (interactionText != null)
            {
                interactionText.SetActive(false); // Cache le texte d'interaction
            }
        }
    }

    void CollectLeaf()
    {
        // Actions de collecte de la feuille
        Debug.Log("Feuille collectée !");

        // Ajoute la feuille à l'inventaire du joueur
        if (playerInventory != null)
        {
            Debug.Log("clé récupéré");
            playerInventory.hasKey = true; // Indique que le joueur a la "clé" pour ouvrir la porte
        }

        // Désactive ou détruit l’objet feuille
        gameObject.SetActive(false);

        // Cache le texte d’interaction
        if (interactionText != null)
        {
            interactionText.SetActive(false);
        }
    }
}
