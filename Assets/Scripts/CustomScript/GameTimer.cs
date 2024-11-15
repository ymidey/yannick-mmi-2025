using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    [SerializeField] private float timerDuration = 60f; // Durée du timer en secondes (1 minute)
    private float timeRemaining; // Temps restant

    [SerializeField] private Text timerText; // Référence au texte UI pour le timer

    private bool isGameOver = false; // État pour vérifier si le jeu est terminé

    void Start()
    {
        // Vérifier si timerText est bien assigné
        if (timerText == null)
        {
            Debug.LogError("Le texte du timer n'est pas assigné dans l'inspecteur !");
            return;
        }

        // Initialiser le temps restant avec la durée du timer
        timeRemaining = timerDuration;

        // Initialiser le texte avec la durée du timer dès le début
        UpdateTimerDisplay();
    }

    void Update()
    {
        // Si le jeu n'est pas terminé, on met à jour le timer
        if (!isGameOver)
        {
            // Réduit le temps restant chaque seconde
            timeRemaining -= Time.deltaTime;

            // Met à jour le texte du timer
            UpdateTimerDisplay();

            // Vérifie si le temps est écoulé
            if (timeRemaining <= 0)
            {
                timeRemaining = 0;
                GameOver();
            }
        }
        else
        {
            // Si le jeu est terminé, vous pouvez continuer à afficher le timer
            UpdateTimerDisplay(); // Vous pouvez garder cette ligne pour montrer le timer jusqu'à la fin
        }
    }

    void UpdateTimerDisplay()
    {
        // Formate le temps restant en minutes et secondes
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);

        // Affiche le temps formaté dans le texte du timer
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void GameOver()
    {
        isGameOver = true;
        timerText.color = Color.red; // Change la couleur du timer pour indiquer la fin du temps

        // Déclenche la logique de Game Over (perte) ici
        // Par exemple, appelle une fonction dans un GameOverManager pour afficher l'écran de Game Over
        GameOverManager gameOverManager = FindObjectOfType<GameOverManager>();
        gameOverManager.TriggerGameOver();
    }
}
