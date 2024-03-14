using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private float speed = 10f;
    private float direction;
    private bool hit;

    private float bulletLifeTime;

    private BoxCollider2D boxCollider;
    private Animator animator;

    private void Awake() {
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    private void Update() {
        // если ударился, то не выполнять дальше
        if (hit) return;

        // двигать пулю
        transform.Translate(speed * Time.deltaTime * direction, 0, 0);

        // пуля исчезнет после 5 сек
        bulletLifeTime += Time.deltaTime;
        if (bulletLifeTime > 2f) {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        hit = true;
        boxCollider.enabled = false;
        animator.SetTrigger("hit");
    }

    public void SetDirection(float direction) {
        bulletLifeTime = 0;

        this.direction = direction;
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;

        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX) != direction) {
            localScaleX = -localScaleX;
        }

        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }

    private void Deactivate() {
        gameObject.SetActive(false);
    }
}
