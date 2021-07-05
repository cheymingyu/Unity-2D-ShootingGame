using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;                     // �� ���ݷ�
    [SerializeField]
    private int scorePoint = 100;               // �� óġ�� ȹ�� ����
    [SerializeField]
    private GameObject explosionPrefab;         // ���� ȿ��
    [SerializeField]
    private GameObject[] itemPrefabs;           // ���� �׿��� �� ȹ�� ������ ������

    private PlayerController playerController;  // �÷��̾��� ����(Score) ������ �����ϱ� ����

    private void Awake()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ������ �ε��� ������Ʈ�� �±װ� "Player"�̸�
        if  (collision.CompareTag("Player"))
        {
            // �� ���ݷ¸�ŭ �÷��̾� ü�� ����
            collision.GetComponent<PlayerHP>().TakeDamage(damage);
            // �� ����� ȣ���ϴ� �Լ�
            OnDie();
        }
    }

    public void OnDie()
    {
        // �÷��̾��� ������ scorePoint��ŭ ������Ų��.
        playerController.Score += scorePoint;
        // ���� ����Ʈ ����
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        // ���� Ȯ���� ������ ����
        SpawnItem();
        // �� ������Ʈ ����
        Destroy(gameObject);
    }

    private void SpawnItem()
    {
        // �Ŀ���(10%), ��ź+1(5%), ü��ȸ��(15%)
        int spawnItem = Random.Range(0, 100);
        if (spawnItem < 10)
        {
            Instantiate(itemPrefabs[0], transform.position, Quaternion.identity);
        }
        else if (spawnItem < 15)
        {
            Instantiate(itemPrefabs[1], transform.position, Quaternion.identity);
        }
        else if (spawnItem < 30)
        {
            Instantiate(itemPrefabs[2], transform.position, Quaternion.identity);
        }
    }
}
