using System.Collections;
using System.Globalization;
using DG.Tweening;
using Managers;
using TMPro;
using UnityEngine;

public class WinScreenManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI youScoredText;
    [SerializeField] private TextMeshProUGUI actualScoreText;
    [SerializeField] private TextMeshProUGUI highscoreText;
    [SerializeField] private GameObject playAgainButton;
    
    public static float actualScore = 00.00f;
    
    private IEnumerator Start()
    {
        playAgainButton.SetActive(false);
        actualScoreText.text = "";
        // Make "you scored" rise up from its OG position minus 5 on the Y axis, and
        Vector2 ogPos = youScoredText.rectTransform.anchoredPosition;
        Color ogCol = youScoredText.color;
        Color ogCol2 = highscoreText.color;

        ogCol.a = 0;
        ogCol2.a = 0;
        youScoredText.color = ogCol;
        highscoreText.color = ogCol2;

        yield return new WaitForSeconds(2);
        
        youScoredText.rectTransform.anchoredPosition += Vector2.down;
        youScoredText.rectTransform.DOAnchorPosY(ogPos.y, 0.5f);

        youScoredText.DOFade(1, 0.5f);
        
        yield return new WaitForSeconds(0.75f);
        
        const float duration = 1;

        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            float score = Mathf.Lerp(0, actualScore, t / duration);
            actualScoreText.text = GameManager.FormatTime(score);
            yield return null;
        }

        actualScoreText.text = GameManager.FormatTime(actualScore);

        yield return new WaitForSeconds(0.5f);

        highscoreText.text = "best time: " + PlayerPrefs.GetFloat("highscore").ToString("F2", CultureInfo.InvariantCulture);
        Vector2 ogPos2 = highscoreText.rectTransform.anchoredPosition;
        highscoreText.rectTransform.anchoredPosition += Vector2.down;
        highscoreText.rectTransform.DOAnchorPosY(ogPos2.y, 0.5f);
        highscoreText.DOFade(1, 0.5f);

        yield return new WaitForSeconds(1f);
        playAgainButton.SetActive(true);
    }

    public void PlayAgain()
    {
        SceneChangeManager.SwitchScene("MainLevel");
    }
}
