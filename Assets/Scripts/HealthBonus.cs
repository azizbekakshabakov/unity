using UnityEngine;

public class HealthBonus : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            collision.GetComponent<Health>().AddHealth();
            gameObject.SetActive(false);
        }
    }
}
