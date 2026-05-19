using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class enemy3script : MonoBehaviour
{
    public float bullshit3 = 0;
    public GameObject hero;
    public GameObject circleleft3;
    public GameObject circleright3;
    public Image enemy3health;
    public Animator enemy3animator;
    public GameObject circle3;  // bize vuraup hasar veren circle


    void Update()
    {
        if (enemy3health.fillAmount >= 0.25)
        {
            enemy3move();
            enemy3attack();
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            enemy3animator.SetTrigger("enemy3death");
            Invoke("enemy3destroy", 3f);
        }
    }

    private void FixedUpdate()
    {
        bullshit3 += 1;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "circlehero")
        {
            enemy3health.fillAmount -= 0.25f;
        }
    }

    public void enemy3move()
    {
        if (hero.transform.position.x > circleleft3.transform.position.x || hero.transform.position.x > circleright3.transform.position.x)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-0.6f, 0);
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        else
        {
            if (transform.position.x <= -3.25)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0.3f, 0);
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            if (transform.position.x >= -1.75)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-0.3f, 0);
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }


    public void enemy3attack()
    {
        if (hero.transform.position.x >= circle3.transform.position.x)
        {
            if (bullshit3 % 50 == 0)
            {
                Invoke("circle3function", 0f);
            }
            else
            {
                enemy3animator.SetTrigger("enemy3walk");
            }
        }
    }


    public void enemy3destroy()
    {
        Destroy(gameObject);
    }


    public void circle3function()
    {
        enemy3animator.SetTrigger("enemy3attack");

        circle3.SetActive(true);
        Invoke("circle3function2", 0.1f);
    }
    public void circle3function2()
    {
        circle3.SetActive(false);
    }
}

