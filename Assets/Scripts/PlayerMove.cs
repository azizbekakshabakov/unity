using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField] private float speed;

    private void Awake(){
        body = GetComponent<Rigidbody2D>();
    }

    private void Update(){
        float inputGetAxisHorizontal = Input.GetAxis("Horizontal");

        body.velocity = new Vector2(inputGetAxisHorizontal * speed, body.velocity.y);

        if (inputGetAxisHorizontal > 0f) {
            transform.localScale = Vector3.one;
        }

        if (Input.GetKey(KeyCode.Space)) {
            body.velocity = new Vector2(body.velocity.x, speed);
        }
    }
}
