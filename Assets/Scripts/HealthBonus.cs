using UnityEngine;

public class HealthBonus : MonoBehaviour
{
    [SerializeField] private AudioClip healthSound;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            SoundManager.instance.PlaySound(healthSound);
            collision.GetComponent<Health>().AddHealth();
            gameObject.SetActive(false);
        }
    }
}
