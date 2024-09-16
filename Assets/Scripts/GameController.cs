using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private void OnEnable()
    {
        ScoreManager.Instance.ScoreChanged += CheckLevelCompletion;
    }

    private void OnDisable()
    {
        ScoreManager.Instance.ScoreChanged -= CheckLevelCompletion;
    }

    private void CheckLevelCompletion()
    {
        if (ScoreManager.Instance.Score < ScoreManager.MAXMIMUM_SCORE)
        {
            return;
        }

        LevelManager.Instance.LoadNextLevel();
    }
}