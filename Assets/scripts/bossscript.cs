using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class bossscript : MonoBehaviour
{
    public float bullshitboss = 0;
    public GameObject hero;
    public GameObject circleleftboss;
    public GameObject circlerightboss;
    public GameObject bossimages;
    public Image bosshealth;
    public Animator bossanimator;
    public GameObject circleboss;  // bize vuraup hasar veren circle


    void Update()
    {
        if (bosshealth.fillAmount > 0)
        {
           bossmove();
           bossattack();

            if (hero.transform.position.y < -5.32)
            {
                bossimages.SetActive(true);
            }
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            bossanimator.SetTrigger("bossdeath");
            Invoke("loadscenevictory", 4);
        }
    }

    private void FixedUpdate()
    {
        bullshitboss += 1;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "circlehero")
        {
            bosshealth.fillAmount -= 0.1f;
        }
    }

    public void bossmove()
    {
        if (hero.transform.position.x > circleleftboss.transform.position.x || hero.transform.position.x > circlerightboss.transform.position.x)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-0.3f, 0);
            transform.rotation = Quaternion.Euler(0, 180, 0);
            bossanimator.SetTrigger("bosswalk");
        }

        else
        {
            if (transform.position.x < 8.33)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0.3f, 0);
                transform.rotation = Quaternion.Euler(0, 0, 0);
                bossanimator.SetTrigger("bosswalk");
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                bossanimator.SetTrigger("bossidle");
            }
        }
    }


    public void bossattack()
    {
        if (hero.transform.position.x >= circleboss.transform.position.x)
        {
            if (bullshitboss % 50 == 0)
            {
                Invoke("circlebossfunction", 0f);
            }
            else
            {
                bossanimator.SetTrigger("bosswalk");
            }
        }
    }


    public void circlebossfunction()
    {
        bossanimator.SetTrigger("bossattack");

        circleboss.SetActive(true);
        Invoke("circlebossfunction2", 0.1f);
    }
    public void circlebossfunction2()
    {
        circleboss.SetActive(false);
    }


    public void loadscenevictory()
    {
        SceneManager.LoadScene(2);
    }
}

