using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    private const string SCORE_FORMAT = "Score: {0}/{1}";

    [SerializeField] private TextMeshProUGUI m_ScoreLabel;

    private void Start()
    {
        ScoreManager.Instance.OnAddScore += UpdateScoreDisplay;
        UpdateScoreDisplay();
    }

    public void UpdateScoreDisplay()
    {
        m_ScoreLabel.text = string.Format(SCORE_FORMAT, ScoreManager.Instance.Score, ScoreManager.MAXMIMUM_SCORE);
    }

    private void OnDestroy()
    {
        ScoreManager.Instance.OnAddScore -= UpdateScoreDisplay;
    }
}