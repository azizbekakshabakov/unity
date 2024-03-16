using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
    private float startingHealth = 3f;
    public float currentHealth;
    private Animator animator;
    public bool dead { get; private set; }

    // private Score score;

    [SerializeField] private Behaviour[] components;

    [SerializeField] private AudioClip hurtSound;

    private void Awake() {
        currentHealth = startingHealth;
        animator = GetComponent<Animator>();
        // score = GetComponent<Score>();
    }

    public void TakeDamage(float damage) {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);

        if (currentHealth > 0) {
            animator.SetTrigger("damage");

            // if (components.Length > 1) {
                // score.IncrementText(10f);
            // }
        } else {
            if (! dead) {
                foreach (Behaviour com in components) {
                    com.enabled = false;
                }

                animator.SetBool("on_ground", true);
                animator.SetTrigger("death");

                this.dead = true;
                //звук при смерти
                SoundManager.instance.PlaySound(hurtSound);
            }

        }
    }

    public void AddHealth() {
        currentHealth = Mathf.Clamp(currentHealth + 1f, 0, startingHealth);
    }

    public void Respawn() {
        dead = false;

        AddHealth();
        AddHealth();
        AddHealth();
        animator.ResetTrigger("die");
        animator.Play("Idle");

        foreach (Behaviour component in components) {
            component.enabled = true;
        }
    }
}
