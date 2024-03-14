using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalHealth;
    [SerializeField] private Image currentHealth;

    private void Start() {
        totalHealth.fillAmount = 0.3f;
    }

    private void Update() {
        currentHealth.fillAmount = playerHealth.currentHealth / 10;
    }
}
