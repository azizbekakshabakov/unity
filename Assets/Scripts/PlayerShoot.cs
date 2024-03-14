using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private Animator animator;
    private PlayerMove playerMove;
    private float shootReload = 0.5f;
    private float shootTimer = Mathf.Infinity;

    private void Awake() {
        animator = GetComponent<Animator>();
        playerMove = GetComponent<PlayerMove>();
    }

    private void Update() {
        if (Input.GetKey(KeyCode.X) && playerMove.canShoot() && shootTimer > shootReload) {
            Shoot();
        }

// увеличить время ожидания выстрела
        shootTimer += Time.deltaTime;
    }

    private void Shoot() {
        animator.SetTrigger("shoot");

// сбросить таймер ожидания выстрела
        shootTimer = 0;
    }
}
