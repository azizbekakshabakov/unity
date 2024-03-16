using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D body;
    private float speed = 5f;
    private Animator animator;
    private bool onGround;
    private float inputGetAxisHorizontal;

    private float maxJump = 1f;
    private float currentJump = 0f;

    // хитбокс
    private BoxCollider2D boxCollider;

    //все ground элементы
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private AudioClip jumpSound;

    private void Awake(){
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update(){
        inputGetAxisHorizontal = Input.GetAxis("Horizontal");

        body.velocity = new Vector2(inputGetAxisHorizontal * speed, body.velocity.y);

// перевернуть спрайт
        if (inputGetAxisHorizontal > 0f) {
            transform.localScale = new Vector3(5, 5, 1);
        } else if (inputGetAxisHorizontal < 0f) {
            transform.localScale = new Vector3(-5, 5, 1);
        }

// переключать аниматоры со стойки в ходбьу
        animator.SetBool("walk", inputGetAxisHorizontal != 0);
// переключить анимацию прыжка
        animator.SetBool("on_ground", isGrounded());

        // выполн только один раз после нажат
        if (Input.GetKeyDown(KeyCode.Space) && currentJump < maxJump) {
            SoundManager.instance.PlaySound(jumpSound);
            body.velocity = new Vector2(body.velocity.x, speed * 1.25f);

            // только прыгнул
            currentJump++;
        }

        if (isGrounded()) {
            currentJump = 0;
        }
    }

// если ударился с землей, то переменная будет true
    // private void OnCollisionEnter2D(Collision2D collision) {
    //     if (collision.gameObject.tag == "Ground") {
    //         onGround = true;
    //     }
    // }

    public bool canShoot() {
        return inputGetAxisHorizontal == 0 && isGrounded();
    }

    private bool isGrounded() {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
}
