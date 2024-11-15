using Unity.VisualScripting;
using UnityEngine;

public class SlenderAI : MonoBehaviour
{
    [SerializeField] private Transform player; // R�f�rence au joueur
    [SerializeField] private float speed = 5f; // Vitesse de d�placement de Slender Man
    [SerializeField] private float detectionRange = 15f; // Distance � partir de laquelle Slender Man appara�t
    [SerializeField] private Animator animator; // R�f�rence � l'Animator
    [SerializeField] private AudioSource laughAudioSource; // L'AudioSource pour le rire

    [SerializeField] private float teleportDistanceThreshold = 20f; // Distance � partir de laquelle Slender doit se t�l�porter
    [SerializeField] private float teleportCooldown = 5f; // Temps en secondes avant de t�l�porter
    [SerializeField] private float teleportDistanceFromPlayer = 10f; // Rayon autour du joueur pour t�l�portation

    private bool hasPlayedLaugh = false; // Indicateur si le rire a d�j� �t� jou�
    private float teleportTimer = 0f; // Chronom�tre pour v�rifier la distance

    void Start()
    {
        animator = GetComponent<Animator>(); // Assigne l'Animator attach� � Slender
    }

    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);

        if (distance <= detectionRange) // Si le joueur est dans le champ de vision
        {
            animator.SetFloat("Speed", 1); // Active l'animation de course
            MoveTowardsPlayer(); // D�placer Slender vers le joueur
        }
        else
        {
            animator.SetFloat("Speed", 0); // D�sactive l'animation de course
        }

        // V�rifie si le joueur est � plus de 20 unit�s pendant 5 secondes
        if (distance > teleportDistanceThreshold)
        {
            teleportTimer += Time.deltaTime;
            if (teleportTimer >= teleportCooldown)
            {
                TeleportNearPlayer(); // T�l�porte l'ennemi pr�s du joueur
                teleportTimer = 0f; // R�initialise le chronom�tre
            }
        }
        else
        {
            teleportTimer = 0f; // R�initialise le chronom�tre si le joueur est proche
        }
    }

    void MoveTowardsPlayer()
    {
        // Se dirige vers le joueur
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;

        // Effectuer la rotation pour orienter Slender Man vers le joueur
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * speed);

        // Verrouiller la rotation sur l'axe Y
        transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
    }

    void TeleportNearPlayer()
    {
        // G�n�rer une direction al�atoire sur une sph�re autour du joueur
        Vector3 randomDirection = Random.insideUnitSphere.normalized;

        // Calculer la nouvelle position en utilisant le rayon sp�cifi� autour du joueur
        Vector3 teleportPosition = player.position + randomDirection * teleportDistanceFromPlayer;
        teleportPosition.y = transform.position.y; // Conserver la m�me hauteur (axe Y)

        transform.position = teleportPosition; // T�l�porter Slender Man � la nouvelle position
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Assure-toi que le tag du joueur est correct
        {
            // Jouer le son de rire
            if (laughAudioSource != null && !hasPlayedLaugh) // V�rifie que le son n'est pas d�j� en cours
            {
                laughAudioSource.Play();
                hasPlayedLaugh = true;
            }

            // Appeler la m�thode TriggerGameOver
            GameOverManager gameOverManager = FindObjectOfType<GameOverManager>();
            gameOverManager.TriggerGameOver();

            // Autres logiques pour arr�ter le jeu si n�cessaire
        }
    }
}
