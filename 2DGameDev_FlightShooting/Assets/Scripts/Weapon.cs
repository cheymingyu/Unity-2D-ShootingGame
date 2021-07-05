using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private GameObject  projectilePrefab;           // ������ �� �����Ǵ� �߻�ü ������
    [SerializeField]
    private float       attackRate = 0.1f;          // ���� �ӵ�
    private int         attackLevel = 1;            // ���� ����
    private AudioSource audioSource;                // ���� ��� ������Ʈ


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void StartFiring()
    {
        StartCoroutine("TryAttack");
    }

    public void StopFiring()
    {
        StopCoroutine("TryAttack");
    }

    private IEnumerator TryAttack()
    {
        while (true)
        {
            //// �߻�ü ������Ʈ ����
            //Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            // ���� ������ ���� �߻�ü ����
            AttackByLevel();
            // ���� ���� ���
            audioSource.Play();

            // attackRate �ð���ŭ ���
            yield return new WaitForSeconds(attackRate);
        }
    }

    private void AttackByLevel()
    {
        GameObject cloneProjectile = null;

        switch (attackLevel)
        {
            case 1:     // Level 01 : ������ ���� �߻�ü 1�� ����
                Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                break;
            case 2:     // Level 02 : ������ �ΰ� �������� �߻�ü 2�� ����
                Instantiate(projectilePrefab, transform.position + Vector3.left * 0.2f, Quaternion.identity);
                Instantiate(projectilePrefab, transform.position + Vector3.right * 0.2f, Quaternion.identity);
                break;
            case 3:     // Level 03 : �������� �߻�ü 1��, �¿� �밢�� �������� �߻�ü �� 1��
                Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                // ���� �밢�� �������� �߻�Ǵ� �߻�ü
                cloneProjectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                cloneProjectile.GetComponent<Movement2D>().MoveTo(new Vector3(-0.2f, 1, 0));
                // ������ �밢�� �������� �߻�Ǵ� �߻�ü
                cloneProjectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                cloneProjectile.GetComponent<Movement2D>().MoveTo(new Vector3(0.2f, 1, 0));
                break;

        }
    }
}
