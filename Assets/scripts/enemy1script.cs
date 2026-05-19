using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class enemy1script : MonoBehaviour
{
    public float bullshit = 0;
    public GameObject hero;
    public GameObject circleleft;
    public GameObject circleright;
    public Image enemy1health;
    public Animator enemy1animator;
    public GameObject circle;  // bize vuraup hasar veren circle


    void Update()
    {
        if (enemy1health.fillAmount >= 0.25)
        {
            enemymove();
            enemyattack();
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            enemy1animator.SetTrigger("enemy1death");
            Invoke("enemydestroy", 3f);
        }
    }

    private void FixedUpdate()
    {
        bullshit += 1;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "circlehero")
        {
            enemy1health.fillAmount -= 0.25f;
        }
    }

    public void enemymove()
    {
        if (hero.transform.position.x > circleleft.transform.position.x || hero.transform.position.x > circleright.transform.position.x)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-0.6f, 0);
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        else
        {
            if (transform.position.x <= -5.75)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0.3f, 0);
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            if (transform.position.x >= -4.25)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-0.3f, 0);
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }


    public void enemyattack()
    {
        if(hero.transform.position.x  >=  circle.transform.position.x)
        {
            if (bullshit % 50 == 0)
            {
                Invoke("circlefunction", 0f);
            }
            else
            {
                enemy1animator.SetTrigger("enemy1walk");
            }
        }
    }


    public void enemydestroy()
    {
        Destroy(gameObject);
    }


    public void circlefunction()
    {
        enemy1animator.SetTrigger("enemy1attack");

        circle.SetActive(true);
        Invoke("circlefunction2", 0.1f);
    }
    public void circlefunction2()
    {
        circle.SetActive(false);
    }
}
