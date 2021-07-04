using System.Collections;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [SerializeField]
    private float maxHP = 10;       // �ִ� ü��
    private float currentHP;        // ���� ü��
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        currentHP = maxHP;
        spriteRenderer = GetComponent<SpriteRenderer>();
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
            Debug.Log("Player HP : 0.. Die");
        }
    }

    private IEnumerator HitColorAnimation()
    {
        // �÷����̾��� ������ ����������
        spriteRenderer.color = Color.red;
        // 0.1�� ���� ���
        yield return new WaitForSeconds(0.1f);
        // �÷��̾��� ������ ���� ������ �Ͼ������
        // (���� ������ �Ͼ���� �ƴ� ��� ���� ���� ���� ����)
        spriteRenderer.color = Color.white;
    }

}
