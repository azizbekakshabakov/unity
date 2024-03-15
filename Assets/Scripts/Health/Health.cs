using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
    private float startingHealth = 3f;
    public float currentHealth;
    private Animator animator;
    private bool dead;

    [SerializeField] private Behaviour[] components;

    private void Awake() {
        currentHealth = startingHealth;
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(float damage) {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);

        if (currentHealth > 0) {
            animator.SetTrigger("damage");

        } else {
            if (! dead) {
                animator.SetTrigger("death");

                // if (GetComponent<PlayerMove>() != null)
                //     GetComponent<PlayerMove>().enabled = false;

                // if (GetComponentInParent<GermanPatrol>() != null)
                //     GetComponentInParent<GermanPatrol>().enabled = false;

                // if (GetComponent<GermanPunch>() != null)
                //     GetComponent<GermanPunch>().enabled = false;

                foreach (Behaviour com in components) {
                    com.enabled = false;
                }

                this.dead = true;
            }

        }
    }

    public void AddHealth() {
        currentHealth = Mathf.Clamp(currentHealth + 1f, 0, startingHealth);
    }
}
