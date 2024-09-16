using UnityEngine.SceneManagement;

public class LevelManager
{
    #region Singleton
    private static LevelManager m_Instance;

    public static LevelManager Instance
    {
        get
        {
            if (m_Instance == null)
            {
                m_Instance = new LevelManager();
            }

            return m_Instance;
        }
    }
    #endregion

    public void LoadNextLevel()
    {
        Scene activeScene = SceneManager.GetActiveScene();

        SceneManager.LoadScene(activeScene.buildIndex + 1);
        ScoreManager.Instance.Reset();
    }
}