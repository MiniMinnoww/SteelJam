using TMPro;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        [SerializeField] private TextMeshProUGUI timerText;
        [SerializeField] private TextMeshProUGUI highscoreText;

        private float timeSpent;
        private void Awake() => Instance = this;

        public static void RestartLevel()
        {
            SceneChangeManager.SwitchScene("MainLevel");
        }

        public void WinLevel()
        {
            if (timeSpent < PlayerPrefs.GetFloat("highscore", Mathf.Infinity))
            {
                PlayerPrefs.SetFloat("highscore", timeSpent);
            }
        }

        private void Update()
        {
            timeSpent += Time.deltaTime;
        
            UpdateTimerText();
        }

        private void Start()
        {
            timeSpent = 0;
        
            float hs = PlayerPrefs.GetFloat("highscore", -1);
            highscoreText.text = Mathf.Approximately(hs, -1) ? "Highscore: None" : $"Highscore: {FormatTime(hs)}<size=50%>s</size>";
        }

        private void UpdateTimerText()
        {
            timerText.text = $"{FormatTime(timeSpent)}<size=50%>s</size>";
        }
    
        // Format from float seconds to seconds:tenthOfASecond
        private static string FormatTime(float t) => $"{(int)(t % 60):00}:{(int)(t - (int)t * 100):00}";
    }
}
