using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;        // �� ���ݷ�

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ������ �ε��� ������Ʈ�� �±װ� "Player"�̸�
        if  (collision.CompareTag("Player"))
        {
            // �� ���ݷ¸�ŭ �÷��̾� ü�� ����
            collision.GetComponent<PlayerHP>().TakeDamage(damage);
            // �� ���
            Destroy(gameObject);
        }
    }
}
