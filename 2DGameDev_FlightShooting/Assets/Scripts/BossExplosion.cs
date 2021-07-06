using UnityEngine;
using UnityEngine.SceneManagement;

public class BossExplosion : MonoBehaviour
{
    private PlayerController playerController;
    private string sceneName;

    public void SetUp(PlayerController playerController, string sceneName)
    {
        this.playerController = playerController;
        this.sceneName = sceneName;
    }

    private void OnDestroy()
    {
        // ���� óġ +10000
        playerController.Score += 10000;
        // �÷��̾� ȹ�� ������ "Score"Ű�� ����
        PlayerPrefs.SetInt("Score", playerController.Score);
        // scnenName���� �� ����
        SceneManager.LoadScene(sceneName);
    }
}
