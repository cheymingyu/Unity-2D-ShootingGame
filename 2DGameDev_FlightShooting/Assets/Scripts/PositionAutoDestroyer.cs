using UnityEngine;

public class PositionAutoDestroyer : MonoBehaviour
{
    [SerializeField]
    private StageData stageData;
    private float destroyWeight = 2.0f;

    private void LateUpdate()
    {
        if (transform.position.y < stageData.LimitMin.y - destroyWeight ||
            transform.position.y > stageData.LimitMax.y + destroyWeight ||
            transform.position.x < stageData.LimitMin.y - destroyWeight ||
            transform.position.x > stageData.LimitMax.y + destroyWeight )
        {
            Destroy(gameObject);
        }
    }
}
