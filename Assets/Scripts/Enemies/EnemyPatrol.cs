using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [SerializeField] private Transform enemy;

    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft;

    [SerializeField] private Animator animator;

    private void Awake() {
        initScale = enemy.localScale;
    }

    private void OnDisable() {
        animator.SetBool("moving", false);
    }

    private void Update() {
        if (movingLeft) {
            if (enemy.position.x >= leftEdge.position.x)
                MoveInDirection(-1);
            else {
                DirectionChange();
            }
        } else {
            if (enemy.position.x <= rightEdge.position.x)
                MoveInDirection(1);
            else {
                DirectionChange();
            }
        }
    }

    private void DirectionChange() {
        animator.SetBool("moving", false);
        movingLeft = !movingLeft;
    }

    private void MoveInDirection(int direction) {
        animator.SetBool("moving", true);

        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * direction, initScale.y, initScale.z);

        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * direction * speed,
            enemy.position.y, enemy.position.z);
    }
}
