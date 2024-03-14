using UnityEngine;

public class EnemyPunch : MonoBehaviour
{
    private float punchTimeout = 5f;
    private float range = 1f;
    private float colliderDistance = 0.5f;
    private float damage = 1f;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;
    private float punchTimer = 6f;

    private Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    private void Update() {
        punchTimer += Time.deltaTime;

        if (PlayerVisible()) {
            if (punchTimer > punchTimeout) {
                punchTimer = 0;
                animator.SetTrigger("hit");
            }
        }
    }

    private bool PlayerVisible() {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z).x,
            0, Vector2.left, 0, playerLayer);

        return hit.collider != null;
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z).x);
    }
}