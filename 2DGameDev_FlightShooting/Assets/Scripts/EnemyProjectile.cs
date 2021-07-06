using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 발사체에 부딪힌 오브젝트의 태그가 "Player"이면
        if (collision.CompareTag("Player"))
        {
            // 부딪힌 오브젝트 체력 감소 (플레이어)
            collision.GetComponent<PlayerHP>().TakeDamage(damage);
            // 내 오브젝트 삭제 (발사체)
            Destroy(gameObject);
        }
    }
}
