using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
    [SerializeField] int speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate (Vector2.down * speed* Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       /* if(collision.gameObject.tag == "Enemy")
        {
            Debug.Log("hit enemy");
            Destroy(collision.gameObject,0.5f);
        }*/
        if(collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}
