using UnityEngine;

public class EnemyPunch : MonoBehaviour
{
    private float punchTimeout = 0.5f;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    private float damage = 1f;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;
    private float punchTimer = 6f;

    private Animator animator;
    private Health playerHealth;

    private EnemyPatrol enemyPatrol;

    private void Awake() {
        animator = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<EnemyPatrol>();
    }

    private void Update() {
        punchTimer += Time.deltaTime;

        if (PlayerVisible()) {
            if (punchTimer > punchTimeout) {
                punchTimer = 0;
                animator.SetTrigger("hit");
            }
        }

        if (enemyPatrol != null) {
            enemyPatrol.enabled = !PlayerVisible();
        }
    }

    private bool PlayerVisible() {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);

        if (hit.collider != null) {
            playerHealth = hit.transform.GetComponent<Health>();
        }

        return hit.collider != null;
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    private void DamagePlayer() {
        if (PlayerVisible()) {
            playerHealth.TakeDamage(damage);
        }
    }
}