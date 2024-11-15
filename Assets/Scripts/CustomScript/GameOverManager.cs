using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private Image gameOverImage;       // Référence à l'image de Game Over
    [SerializeField] private Text restartText;          // Référence au texte "Appuyez sur R pour recommencer"
    private bool isGameOver = false;                    // Indicateur d'état de Game Over

    void Start()
    {
        // Masquer l'image et le texte au début du jeu
        gameOverImage.enabled = false;
        restartText.enabled = false;
    }

    void Update()
    {
        // Vérifie si le jeu est en état de Game Over et si la touche "R" est pressée
        if (isGameOver && Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }

    public void TriggerGameOver()
    {
        // Affiche l'image de Game Over, le texte de redémarrage et active l'état de Game Over
        gameOverImage.enabled = true;
        restartText.enabled = true;
        isGameOver = true;
    }

    private void RestartGame()
    {
        // Recharge la scène actuelle pour recommencer le jeu
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
