using System.Collections;
using UnityEngine;

public class BossHP : MonoBehaviour
{
    [SerializeField]
    private float maxHP = 1000;     // �ִ� ü��
    private float currentHP;        // ���� ü��
    private SpriteRenderer spriteRenderer;
    private Boss boss;

    public float MaxHP => maxHP;
    public float CurrentHP => currentHP;

    private void Awake()
    {
        currentHP = maxHP;
        spriteRenderer = GetComponent<SpriteRenderer>();
        boss = GetComponent<Boss>();
    }

    public void TakeDamage(float damage)
    {
        // ���� ü���� damage��ŭ ����
        currentHP -= damage;

        StopCoroutine("HitColorAnimation");
        StartCoroutine("HitColorAnimation");

        // ü���� 0 ���� = �÷��̾� ĳ���� ���
        if (currentHP <= 0)
        {
            // ü���� 0�̸� OnDie() �Լ��� ȣ���ؼ� �׾��� �� ó���� �Ѵ�
            boss.OnDie();
        }
    }

    private IEnumerator HitColorAnimation()
    {
        // ������ ������ ����������
        spriteRenderer.color = Color.red;
        // 0.1�� ���� ���
        yield return new WaitForSeconds(0.1f);
        // ������ ������ ���� ������ �Ͼ������
        // (���� ������ �Ͼ���� �ƴ� ��� ���� ���� ���� ����)
        spriteRenderer.color = Color.white;
    }
}
