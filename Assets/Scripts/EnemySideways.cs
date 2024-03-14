using UnityEngine;

public class Enemy_Sideways : MonoBehaviour {
    private float damage = 1f;
    // private float movementDistance = 10f;
    // private float speed = 5f;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
}