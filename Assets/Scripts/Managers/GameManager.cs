using System;
using Managers;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI highscoreText;

    private float timeSpent;
    private void Awake() => Instance = this;

    public void RestartLevel()
    {
        SceneChangeManager.SwitchScene("MainLevel");
    }

    public void WinLevel()
    {
        
    }

    private void Update()
    {
        timeSpent += Time.deltaTime;
    }

    private void Start()
    {
        timeSpent = 0;
        timerText.text
    }
}
