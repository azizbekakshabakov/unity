using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;

    private void Awake() {
        gameOverScreen.SetActive(false);
    }

    public void GameOver() {
        gameOverScreen.SetActive(true);
    }

    public void Restart() {
        SceneManager.LoadScene(1);
        SceneManager.LoadScene(0);
    }

    public void Exit() {
        Application.Quit();
    }
}
