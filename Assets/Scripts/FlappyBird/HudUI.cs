using TMPro;
using UnityEngine;
using DG.Tweening;

public class HudUI : MonoBehaviour
{

    [SerializeField] TMP_Text ScoreTxt;
    [SerializeField] GameOverDlg gameOverDlg;
    float m_score = 0;
    public void Init()
    {
        m_score = 0;
        gameOverDlg.Init();
    }
    void Update()
    {
        m_score = Mathf.Lerp(m_score, ScoreManager.Instance.CurScore, Time.deltaTime * 5);
        if (m_score >= ScoreManager.Instance.CurScore - 1) m_score = ScoreManager.Instance.CurScore;

        ScoreTxt.text = string.Format("SCORE : {0}", (int)m_score);
    }

    public void SetScoreText()
    {
        if (ScoreTxt == null) return;
        ScoreTxt.gameObject.transform.DOPunchScale(new Vector3(1.15f, 1.15f, 1.15f), 0.2f, 2);
    }

    public void ShowGameOverDlg()
    {
        gameOverDlg.Show(true);
    }
    
}
