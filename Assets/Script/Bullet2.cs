using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2 : MonoBehaviour
{

    public float speed = 10f;
    public float LifeTime = 0.5f;


    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = -transform.up * speed;
        Invoke("DestroyBullet", LifeTime);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player1"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Platform"))
        {
            Destroy(gameObject);
        }




    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }


}