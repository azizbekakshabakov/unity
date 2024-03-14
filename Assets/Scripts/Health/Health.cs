using UnityEngine;

public class Health : MonoBehaviour
{
    private float startingHealth = 3f;
    public float currentHealth;

    private void Awake() {
        currentHealth = startingHealth;
    }

    public void TakeDamage(float damage) {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);

        if (currentHealth > 0) {

        } else {

        }
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {
            TakeDamage(1);
        }
    }
}
