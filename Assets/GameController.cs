using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int score;
    public int countEnemy;
    public int countEnemyDead;
    public int maxEnemy;
    public bool isSpawnEnemy = true;
    public static GameController instance;

    private void Awake()
    {
        instance = this;
    }

    public void SpawnEnemyController()
    {
        if (countEnemy >= maxEnemy)
        {
            isSpawnEnemy = false;
        }
    }

    public void CheckWinLost()
    {
        if (score <= 0)
        {
            Debug.Log("Lose");
            Time.timeScale = 0;
            UiManager.ins.GameOverPanel.gameObject.SetActive(true);
        }
        if(score >= 0 && countEnemyDead == maxEnemy)
        {
            Debug.Log("WIn");
            Time.timeScale = 0;

            UiManager.ins.GamWinPanel.gameObject.SetActive(true);

        }
    }

    public void Replay()
    {
        SceneManager.LoadScene("PhoenixGame");
        Time.timeScale = 1;
    }
}
