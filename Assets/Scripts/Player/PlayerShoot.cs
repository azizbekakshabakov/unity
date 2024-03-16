using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private Animator animator;
    private PlayerMove playerMove;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] bullets;

    //звук выстрла
    [SerializeField] private AudioClip shootSound;

    // время перезарядки
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
        //издать звук
        SoundManager.instance.PlaySound(shootSound);

        animator.SetTrigger("shoot");

        // сбросить таймер ожидания выстрела
        shootTimer = 0;

        // найти свободный префаб пули
        int i = 0;
        for (; i < bullets.Length; i++) {
            if (! bullets[i].activeInHierarchy) {
                break;
            }
        }

        bullets[i].transform.position = firePoint.position;
        bullets[i].GetComponent<BulletScript>().SetDirection(Mathf.Sign(transform.localScale.x));
    }
}
