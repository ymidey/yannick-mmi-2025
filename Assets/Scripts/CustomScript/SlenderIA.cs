using Unity.VisualScripting;
using UnityEngine;

public class SlenderAI : MonoBehaviour
{
    [SerializeField] private Transform player; // Référence au joueur
    [SerializeField] private float speed = 5f; // Vitesse de déplacement de Slender Man
    [SerializeField] private float detectionRange = 15f; // Distance à partir de laquelle Slender Man apparaît
    [SerializeField] private Animator animator; // Référence à l'Animator
    [SerializeField] private AudioSource laughAudioSource; // L'AudioSource pour le rire

    [SerializeField] private float teleportDistanceThreshold = 20f; // Distance à partir de laquelle Slender doit se téléporter
    [SerializeField] private float teleportCooldown = 5f; // Temps en secondes avant de téléporter
    [SerializeField] private float teleportDistanceFromPlayer = 10f; // Rayon autour du joueur pour téléportation

    private bool hasPlayedLaugh = false; // Indicateur si le rire a déjà été joué
    private float teleportTimer = 0f; // Chronomètre pour vérifier la distance

    void Start()
    {
        animator = GetComponent<Animator>(); // Assigne l'Animator attaché à Slender
    }

    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);

        if (distance <= detectionRange) // Si le joueur est dans le champ de vision
        {
            animator.SetFloat("Speed", 1); // Active l'animation de course
            MoveTowardsPlayer(); // Déplacer Slender vers le joueur
        }
        else
        {
            animator.SetFloat("Speed", 0); // Désactive l'animation de course
        }

        // Vérifie si le joueur est à plus de 20 unités pendant 5 secondes
        if (distance > teleportDistanceThreshold)
        {
            teleportTimer += Time.deltaTime;
            if (teleportTimer >= teleportCooldown)
            {
                TeleportNearPlayer(); // Téléporte l'ennemi près du joueur
                teleportTimer = 0f; // Réinitialise le chronomètre
            }
        }
        else
        {
            teleportTimer = 0f; // Réinitialise le chronomètre si le joueur est proche
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
        // Générer une direction aléatoire sur une sphère autour du joueur
        Vector3 randomDirection = Random.insideUnitSphere.normalized;

        // Calculer la nouvelle position en utilisant le rayon spécifié autour du joueur
        Vector3 teleportPosition = player.position + randomDirection * teleportDistanceFromPlayer;
        teleportPosition.y = transform.position.y; // Conserver la même hauteur (axe Y)

        transform.position = teleportPosition; // Téléporter Slender Man à la nouvelle position
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Assure-toi que le tag du joueur est correct
        {
            // Jouer le son de rire
            if (laughAudioSource != null && !hasPlayedLaugh) // Vérifie que le son n'est pas déjà en cours
            {
                laughAudioSource.Play();
                hasPlayedLaugh = true;
            }

            // Appeler la méthode TriggerGameOver
            GameOverManager gameOverManager = FindObjectOfType<GameOverManager>();
            gameOverManager.TriggerGameOver();

            // Autres logiques pour arrêter le jeu si nécessaire
        }
    }
}
