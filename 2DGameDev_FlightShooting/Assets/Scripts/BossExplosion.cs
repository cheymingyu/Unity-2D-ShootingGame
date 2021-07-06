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
        // 보스 처치 +10000
        playerController.Score += 10000;
        // 플레이어 획득 점수를 "Score"키에 저장
        PlayerPrefs.SetInt("Score", playerController.Score);
        // scnenName으로 씬 변경
        SceneManager.LoadScene(sceneName);
    }
}
