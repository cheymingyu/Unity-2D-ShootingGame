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
        // Tip. ������ ���� .ToString()�� �ϰ� �Ǹ� �������� ���ǵ� 
        // ���� �̸��� string���� �޾ƿ��� �ȴ�.
        // ex) bossState�� ���� BossState.MoveToAppearPoint�̸� "MoveToAppearPoint"

        // �̸� �̿��� �������� �̸��� �ڷ�ƾ �̸��� ��ġ���� 
        // ������ ������ �ٶ� �ڷ�ƾ �Լ� ����� ������ �� �ִ�.

        // ������ ������̴� ���� ����
        StopCoroutine(bossState.ToString());
        // ���� ����
        bossState = newState;
        // ���ο� ���� ���
        StartCoroutine(bossState.ToString());
    }

    private IEnumerator MoveToAppearPoint()
    {
        // �̵����� ���� [�ڷ�ƾ ���� �� 1ȸ ȣ��]
        movement2D.MoveTo(Vector3.down);

        while (true)
        {
            if (transform.position.y <= bossAppearPoint)
            {
                // �̵������� (0, 0, 0)���� ������ ���ߵ��� �Ѵ�.
                movement2D.MoveTo(Vector3.zero);
                // Phase01 ���·� ����
                ChangeState(BossState.Phase01);
            }

            yield return null;
        }
    }

    private IEnumerator Phase01()
    {
        // �� ������ ��� ���� ����
        bossWeapon.StartFiring(AttackType.CircleFire);

        while (true) {
            yield return null;
        }
    }
}
