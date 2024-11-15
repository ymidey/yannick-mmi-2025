using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    [SerializeField] private float timerDuration = 60f; // Dur�e du timer en secondes (1 minute)
    private float timeRemaining; // Temps restant

    [SerializeField] private Text timerText; // R�f�rence au texte UI pour le timer

    private bool isGameOver = false; // �tat pour v�rifier si le jeu est termin�

    void Start()
    {
        // V�rifier si timerText est bien assign�
        if (timerText == null)
        {
            Debug.LogError("Le texte du timer n'est pas assign� dans l'inspecteur !");
            return;
        }

        // Initialiser le temps restant avec la dur�e du timer
        timeRemaining = timerDuration;

        // Initialiser le texte avec la dur�e du timer d�s le d�but
        UpdateTimerDisplay();
    }

    void Update()
    {
        // Si le jeu n'est pas termin�, on met � jour le timer
        if (!isGameOver)
        {
            // R�duit le temps restant chaque seconde
            timeRemaining -= Time.deltaTime;

            // Met � jour le texte du timer
            UpdateTimerDisplay();

            // V�rifie si le temps est �coul�
            if (timeRemaining <= 0)
            {
                timeRemaining = 0;
                GameOver();
            }
        }
        else
        {
            // Si le jeu est termin�, vous pouvez continuer � afficher le timer
            UpdateTimerDisplay(); // Vous pouvez garder cette ligne pour montrer le timer jusqu'� la fin
        }
    }

    void UpdateTimerDisplay()
    {
        // Formate le temps restant en minutes et secondes
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);

        // Affiche le temps format� dans le texte du timer
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void GameOver()
    {
        isGameOver = true;
        timerText.color = Color.red; // Change la couleur du timer pour indiquer la fin du temps

        // D�clenche la logique de Game Over (perte) ici
        // Par exemple, appelle une fonction dans un GameOverManager pour afficher l'�cran de Game Over
        GameOverManager gameOverManager = FindObjectOfType<GameOverManager>();
        gameOverManager.TriggerGameOver();
    }
}
