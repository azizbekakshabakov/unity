using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D body;
    private float speed = 5;
    private Animator animator;

    private void Awake(){
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update(){
        float inputGetAxisHorizontal = Input.GetAxis("Horizontal");

        body.velocity = new Vector2(inputGetAxisHorizontal * speed, body.velocity.y);

// прыжок
        if (Input.GetKey(KeyCode.Space)) {
            body.velocity = new Vector2(body.velocity.x, speed);
        }

// перевернуть спрайт
        if (inputGetAxisHorizontal > 0f) {
            transform.localScale = new Vector3(5, 5, 1);
        } else if (inputGetAxisHorizontal < 0f) {
            transform.localScale = new Vector3(-5, 5, 1);
        }

// переключать аниматоры со стойки в ходбьу
        animator.SetBool("walk", inputGetAxisHorizontal != 0);
    }
}
