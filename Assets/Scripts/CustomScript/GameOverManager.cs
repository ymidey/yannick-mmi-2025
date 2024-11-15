using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private Image gameOverImage;       // R�f�rence � l'image de Game Over
    [SerializeField] private Text restartText;          // R�f�rence au texte "Appuyez sur R pour recommencer"
    private bool isGameOver = false;                    // Indicateur d'�tat de Game Over

    void Start()
    {
        // Masquer l'image et le texte au d�but du jeu
        gameOverImage.enabled = false;
        restartText.enabled = false;
    }

    void Update()
    {
        // V�rifie si le jeu est en �tat de Game Over et si la touche "R" est press�e
        if (isGameOver && Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }

    public void TriggerGameOver()
    {
        // Affiche l'image de Game Over, le texte de red�marrage et active l'�tat de Game Over
        gameOverImage.enabled = true;
        restartText.enabled = true;
        isGameOver = true;
    }

    private void RestartGame()
    {
        // Recharge la sc�ne actuelle pour recommencer le jeu
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
