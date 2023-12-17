using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phoenix : MonoBehaviour
{
    [SerializeField] int speed;
    public Animator anim;
    public Rigidbody2D rb;
    public BoxCollider2D col;
    public GameObject fire;
    bool isAttack;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        PhoenixMovement();
        Attack();
    }

    void PhoenixMovement()
    {
        if(Input.GetKey(KeyCode.W)) 
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
    }

    private void Attack()
    {
        if(Input.GetMouseButton(0) || Input.GetKeyDown(KeyCode.Space))
        {
            if (!isAttack)
            {
                isAttack = true;
                StartCoroutine(ChangeIsAttack());
                GameObject projectile = Instantiate(fire,transform.position, Quaternion.identity);
            }
        }
      
    }
    IEnumerator ChangeIsAttack()
    {
        yield return new WaitForSeconds(1f);
        isAttack = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            Destroy(collision.gameObject);
            GameController.instance.score -= 10;
            UiManager.ins.scoreText.text = "Score : " + GameController.instance.score.ToString();
            GameController.instance.CheckWinLost();
        }
    }
}
