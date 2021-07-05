using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private GameObject  projectilePrefab;           // 공격할 때 생성되는 발사체 프리팹
    [SerializeField]
    private float       attackRate = 0.1f;          // 공격 속도
    private int         attackLevel = 1;            // 공격 레벨
    private AudioSource audioSource;                // 사운드 재생 컴포넌트


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
            //// 발사체 오브젝트 생성
            //Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            // 공격 레벨에 따라 발사체 생성
            AttackByLevel();
            // 공격 사운드 재생
            audioSource.Play();

            // attackRate 시간만큼 대기
            yield return new WaitForSeconds(attackRate);
        }
    }

    private void AttackByLevel()
    {
        GameObject cloneProjectile = null;

        switch (attackLevel)
        {
            case 1:     // Level 01 : 기존과 같이 발사체 1개 생성
                Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                break;
            case 2:     // Level 02 : 간격을 두고 전방으로 발사체 2개 생성
                Instantiate(projectilePrefab, transform.position + Vector3.left * 0.2f, Quaternion.identity);
                Instantiate(projectilePrefab, transform.position + Vector3.right * 0.2f, Quaternion.identity);
                break;
            case 3:     // Level 03 : 전방으로 발사체 1개, 좌우 대각선 방향으로 발사체 각 1개
                Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                // 왼쪽 대각선 방향으로 발사되는 발사체
                cloneProjectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                cloneProjectile.GetComponent<Movement2D>().MoveTo(new Vector3(-0.2f, 1, 0));
                // 오른쪽 대각선 방향으로 발사되는 발사체
                cloneProjectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                cloneProjectile.GetComponent<Movement2D>().MoveTo(new Vector3(0.2f, 1, 0));
                break;

        }
    }
}
