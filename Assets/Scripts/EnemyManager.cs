using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] int speedSpawn;
    public float count;
    public GameObject enemy;

    void Update()
    {
        count += Time.deltaTime;

        SpawnEnemies();
    }

    void SpawnEnemies()
    {
        if(GameController.instance.isSpawnEnemy)
        {
            if (count >= speedSpawn)
            {
                count = 0;
                Vector2 pos = new Vector2(Random.Range(-5, 5), -3.5f);
                GameObject enemySpawn = Instantiate(enemy, pos, Quaternion.identity);

                enemySpawn.gameObject.transform.SetParent(transform);
                GameController.instance.countEnemy += 1;
                GameController.instance.SpawnEnemyController();
                UiManager.ins.enemyAmountText.text = "Enemy : " + GameController.instance.countEnemy.ToString();

            }
        }
          
    }
}
