using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private StageData       stageData;              // �� ������ ���� �������� ũ�� ����
    [SerializeField]
    private GameObject      enemyPrefab;            // �����ؼ� ������ �� ĳ���� ������
    [SerializeField]
    private GameObject      enemyHPSliderPrefab;    // �� ü���� ��Ÿ���� Slider UI ������
    [SerializeField]
    private Transform       canvasTransform;        // UI�� ǥ���ϴ� Canvas ������Ʈ�� Transform
    [SerializeField]
    private BGMController   bgmController;          // ������� ���� (���� ���� �� ����)
    [SerializeField]
    private float           spawnTime;              // ���� �ֱ�
    [SerializeField]
    private float           maxEnemyCount = 100;    // ���� ���������� �ִ� �� ��������

    private void Awake()
    {
        StartCoroutine("SpawnEnemy");
    }

    private IEnumerator SpawnEnemy()
    {
        int currentEnemyCount = 0;      // �� ���� ���� ī��Ʈ�� ����

        while (true)
        {
            // x ��ġ�� ���������� ũ�� ���� ������ ������ ���� ����
            float positionX = Random.Range(stageData.LimitMin.x, stageData.LimitMax.x);
            // �� ���� ��ġ
            Vector3 position = new Vector3(positionX, stageData.LimitMax.y + 1.0f, 0.0f);
            // �� ĳ���� ����
            GameObject enemyClone = Instantiate(enemyPrefab, position, Quaternion.identity);
            // �� ü���� ��Ÿ���� Slider UI ���� �� ����
            SpawnEnemyHPSlider(enemyClone);

            // �� ���� ���� ����
            currentEnemyCount++;
            // ���� �ִ� ���ڱ��� �����ϸ� �� ���� �ڷ�ƾ ����, ���� ���� �ڷ�ƾ ����
            if (currentEnemyCount == maxEnemyCount)
            {
                StartCoroutine("SpawnBoss");
                break;
            }

            // spawnTime��ŭ ���
            yield return new WaitForSeconds(spawnTime);
        }
    }

    private void SpawnEnemyHPSlider(GameObject enemy)
    {
        // �� ü���� ��Ÿ���� Slider UI ����
        GameObject sliderClone = Instantiate(enemyHPSliderPrefab);
        // Slider UI ������Ʈ�� parent("Canvas" ������Ʈ)�� �ڽ����� ����
        // Tip. UI�� ĵ������ �ڽ� ������Ʈ�� �����Ǿ� �־�� ȭ�鿡 ���δ�.
        sliderClone.transform.SetParent(canvasTransform);
        // ���� �������� �ٲ� ũ�⸦ �ٽ� (1, 1, 1)�� ����
        sliderClone.transform.localScale = Vector3.one;

        // Slider UI�� �Ѿƴٴ� ����� �������� ����
        sliderClone.GetComponent<SliderPositionAutoSetter>().SetUp(enemy.transform);
        // Slider UI�� �ڽ��� ü�� ������ ǥ���ϵ��� ����
        sliderClone.GetComponent<EnemyHPViewer>().SetUp(enemy.GetComponent<EnemyHP>());
    }

    private IEnumerator SpawnBoss()
    {
        // ���� ���� BGM ����
        bgmController.ChangeBGM(BGMType.Boss); // bgmController.ChangeBGM(1); ���� �������� ����.
        yield return null;
    }
}
