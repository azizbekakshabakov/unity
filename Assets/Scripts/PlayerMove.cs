using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D body;
    private float speed = 5f;
    private Animator animator;
    private bool onGround;
    private float inputGetAxisHorizontal;

    private void Awake(){
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update(){
        inputGetAxisHorizontal = Input.GetAxis("Horizontal");

        body.velocity = new Vector2(inputGetAxisHorizontal * speed, body.velocity.y);

// прыжок
        if (Input.GetKey(KeyCode.Space) && onGround) {
            body.velocity = new Vector2(body.velocity.x, speed);
            onGround = false;
        }

// перевернуть спрайт
        if (inputGetAxisHorizontal > 0f) {
            transform.localScale = new Vector3(5, 5, 1);
        } else if (inputGetAxisHorizontal < 0f) {
            transform.localScale = new Vector3(-5, 5, 1);
        }

// переключать аниматоры со стойки в ходбьу
        animator.SetBool("walk", inputGetAxisHorizontal != 0);
// переключить анимацию прыжка
        animator.SetBool("on_ground", onGround);
    }

// если ударился с землей, то переменная будет true
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Ground") {
            onGround = true;
        }
    }

    public bool canShoot() {
        return inputGetAxisHorizontal == 0 && onGround;
    }
}
