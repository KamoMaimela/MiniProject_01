using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private int health = 5;
   

    public Slider Health;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            health--;
            Health.value--;
         

            if(health <= 0)
            {
                KillSelf();
            }
        }
    }

    private void KillSelf()
    {
        gameObject.SetActive(false);
        Score.scoreValue1 += 1;
    }

}