using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;

    private void Awake() {
        gameOverScreen.SetActive(false);
    }

    public void GameOver() {
        gameOverScreen.SetActive(true);
    }
}
