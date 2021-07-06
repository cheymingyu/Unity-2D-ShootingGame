using System.Collections;
using UnityEngine;

public enum BossState { MoveToAppearPoint = 0, Phase01, }

public class Boss : MonoBehaviour
{
    [SerializeField]
    private float       bossAppearPoint = 2.5f;
    private BossState   bossState = BossState.MoveToAppearPoint;
    private Movement2D  movement2D;
    private BossWeapon  bossWeapon;

    private void Awake()
    {
        movement2D = GetComponent<Movement2D>();
        bossWeapon = GetComponent<BossWeapon>();
    }

    public void ChangeState(BossState newState)
    {
        // Tip. 열거형 변수 .ToString()을 하게 되면 열거형에 정의된 
        // 변수 이름을 string으로 받아오게 된다.
        // ex) bossState가 현재 BossState.MoveToAppearPoint이면 "MoveToAppearPoint"

        // 이를 이용해 열거형의 이름과 코루틴 이름을 일치시켜 
        // 열거형 변수에 다라 코루틴 함수 재생을 제어할 수 있다.

        // 이전에 재생중이던 상태 종료
        StopCoroutine(bossState.ToString());
        // 상태 변경
        bossState = newState;
        // 새로운 상태 재생
        StartCoroutine(bossState.ToString());
    }

    private IEnumerator MoveToAppearPoint()
    {
        // 이동방향 설정 [코루틴 실행 시 1회 호출]
        movement2D.MoveTo(Vector3.down);

        while (true)
        {
            if (transform.position.y <= bossAppearPoint)
            {
                // 이동방향을 (0, 0, 0)으로 설정해 멈추도록 한다.
                movement2D.MoveTo(Vector3.zero);
                // Phase01 상태로 변경
                ChangeState(BossState.Phase01);
            }

            yield return null;
        }
    }

    private IEnumerator Phase01()
    {
        // 원 형태의 방사 공격 시작
        bossWeapon.StartFiring(AttackType.CircleFire);

        while (true) {
            yield return null;
        }
    }
}
