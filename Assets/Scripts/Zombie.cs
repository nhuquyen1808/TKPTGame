using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Zombie : MonoBehaviour
{
    public Vector2 leftDes, rightDes;
    public int speed;
    public Rigidbody2D rb;
    public bool isFacingRight;
    public GameObject projectile;
    float countSpawn;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        leftDes = (Vector2)transform.position + new Vector2(-1, 0);
        rightDes = (Vector2)transform.position + new Vector2(1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        countSpawn += Time.deltaTime;
        EnemyMovement();
        SpawnProjectile();
    }
    void EnemyMovement()
    {

        if (!isFacingRight)
        {
            transform.Translate(Vector2.left * 2 * Time.deltaTime);
            transform.localScale = new Vector3(-1, 1, 1);

            if (transform.position.x <= leftDes.x)
            {
                isFacingRight = true;
                transform.localScale = new Vector3(1, 1, 1);

            }
        }
        if(isFacingRight)
        {
            transform.Translate(Vector2.right * 2 * Time.deltaTime);

            if (transform.position.x >= rightDes.x)
            {
                isFacingRight = false;
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }

    }

    void SpawnProjectile()
    {
        if(countSpawn >= 2)
        {
            countSpawn = 0;
            GameObject obj = Instantiate(projectile, transform.position, Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Fire")
        {
            anim.Play("ZombieDead");
            Destroy(gameObject,1);
            GameController.instance.score += 3;
            GameController.instance.countEnemyDead += 1;
            UiManager.ins.scoreText.text = "Score : "+ GameController.instance.score.ToString();
            GameController.instance.CheckWinLost();

        }

    }
}
