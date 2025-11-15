using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private void Awake() => Instance = this;

    public void RestartLevel()
    {
        // TODO: Replace with a custom scene manager with a fade transition
        SceneManager.LoadScene("MainLevel");
    }
}
