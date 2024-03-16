using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Health playerHealth;
    private MenuManager menuManager;

    private void Awake() {
        playerHealth = GetComponent<Health>();
        menuManager = FindObjectOfType<MenuManager>();
    }

    public void Respawn2() {
        if (playerHealth.currentHealth < 1f) {
            menuManager.GameOver();
            return;
        }
        else {
            transform.position = new Vector3(-6, 0, 0);
            playerHealth.Respawn();
        }
    }
}
