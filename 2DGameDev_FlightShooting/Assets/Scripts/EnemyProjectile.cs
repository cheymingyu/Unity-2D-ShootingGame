using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �߻�ü�� �ε��� ������Ʈ�� �±װ� "Player"�̸�
        if (collision.CompareTag("Player"))
        {
            // �ε��� ������Ʈ ü�� ���� (�÷��̾�)
            collision.GetComponent<PlayerHP>().TakeDamage(damage);
            // �� ������Ʈ ���� (�߻�ü)
            Destroy(gameObject);
        }
    }
}
