using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DoorInteraction : MonoBehaviour
{
    [SerializeField] private Transform teleportDestination; // Destination de téléportation
    [SerializeField] private CanvasGroup fadeCanvasGroup;    // Canvas pour le fondu au noir
    public GameObject interactionText;
    public GameObject lockedMessageText;

    [SerializeField] private float fadeDuration = 1f;        // Durée du fondu

    private bool isPlayerNearby = false;                    // Indique si le joueur est proche de la porte
    private PlayerInventory playerInventory;

    private void Start()
    {
        // Récupère l'inventaire du joueur
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            playerInventory = player.GetComponent<PlayerInventory>();
        }

      
            interactionText.SetActive(false);
        lockedMessageText.SetActive(false);
        

        fadeCanvasGroup.alpha = 0;
    }

    private void Update()
    {
        // Affiche l'invite si le joueur est proche et appuie sur "E"
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            if (playerInventory != null && playerInventory.hasKey)
            {
                // Si le joueur possède la clé, ouvrir la porte
                StartCoroutine(OpenDoor());
            }
            else
            {
                // Si le joueur n'a pas la clé, afficher le message de porte verrouillée
                ShowLockedMessage();
            }
        }
    }

    private void ShowLockedMessage()
    {
        interactionText.gameObject.SetActive(false);
        lockedMessageText.gameObject.SetActive(true);
    }

    private void HideLockedMessage()
    {
        lockedMessageText.gameObject.SetActive(false);
    }

    private IEnumerator OpenDoor()
    {
        // Démarre le fondu au noir
        yield return StartCoroutine(FadeToBlack());

        // Téléporte le joueur de l'autre côté de la porte
        GameObject.FindWithTag("Player").transform.position = teleportDestination.position;

        // Termine le fondu
        yield return StartCoroutine(FadeFromBlack());
    }

    private IEnumerator FadeToBlack()
    {
        float timer = 0;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            fadeCanvasGroup.alpha = Mathf.Lerp(0, 1, timer / fadeDuration);
            yield return null;
        }
    }

    private IEnumerator FadeFromBlack()
    {
        float timer = 0;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            fadeCanvasGroup.alpha = Mathf.Lerp(1, 0, timer / fadeDuration);
            yield return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Si le joueur entre dans la zone de la porte
        if (other.CompareTag("Player"))
        {
            Debug.Log("test");
            isPlayerNearby = true;
            interactionText.gameObject.SetActive(true); // Affiche le texte "Appuyez sur E pour ouvrir la porte"
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Si le joueur quitte la zone de la porte
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            interactionText.gameObject.SetActive(false); // Cache le texte d'interaction
            lockedMessageText.gameObject.SetActive(false); // Cache le message de porte verrouillée si affiché
        }
    }
}
