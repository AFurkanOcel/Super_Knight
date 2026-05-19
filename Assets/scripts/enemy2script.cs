using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class enemy2script : MonoBehaviour
{
    public float bullshit2 = 0;
    public GameObject hero;
    public GameObject circleleft2;
    public GameObject circleright2;
    public Image enemy2health;
    public Animator enemy2animator;
    public GameObject circle2;  // bize vuraup hasar veren circle


    void Update()
    {
        if (enemy2health.fillAmount >= 0.25)
        {
            enemy2move();
            enemy2attack();
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            enemy2animator.SetTrigger("enemy2death");
            Invoke("enemy2destroy", 3f);
        }
    }

    private void FixedUpdate()
    {
        bullshit2 += 1;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "circlehero")
        {
            enemy2health.fillAmount -= 0.25f;
        }
    }

    public void enemy2move()
    {
        if (hero.transform.position.x > circleleft2.transform.position.x || hero.transform.position.x > circleright2.transform.position.x)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-0.6f, 0);
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        else
        {
            if (transform.position.x <= -0.75)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0.3f, 0);
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            if (transform.position.x >= 0.75)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-0.3f, 0);
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }


    public void enemy2attack()
    {
        if (hero.transform.position.x >= circle2.transform.position.x)
        {
            if (bullshit2 % 50 == 0)
            {
                Invoke("circle2function", 0f);
            }
            else
            {
                enemy2animator.SetTrigger("enemy2walk");
            }
        }
    }


    public void enemy2destroy()
    {
        Destroy(gameObject);
    }


    public void circle2function()
    {
        enemy2animator.SetTrigger("enemy2attack");

        circle2.SetActive(true);
        Invoke("circle2function2", 0.1f);
    }
    public void circle2function2()
    {
        circle2.SetActive(false);
    }
}
