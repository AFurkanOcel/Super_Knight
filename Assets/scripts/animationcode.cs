using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class animationcode : MonoBehaviour
{
    bool run = false;
    public int praycount = 3;
    public Image healthimage;
    public Animator heroanimator;
    public AudioSource swordsound;
    public AudioSource useelixir;
    public static bool jump = false;
    public static bool roll = false;
    public static bool circletouchme = false;
    public static bool soundsoff = false;
    public TMPro.TextMeshProUGUI praycounttext;

    private void Start()
    {
        praycount = 3;
    }

    void Update()
    {
        praycounttext.text = praycount.ToString();

        if (Input.GetMouseButtonDown(0)  &&  jump == false  &&  roll == false  &&  run == false)
        {
            heroanimator.SetTrigger("attack1");
            if (soundsoff == false)
            {
                swordsound.Play();
            }
        }
        if (Input.GetMouseButtonDown(1)  &&  jump == false  &&  roll == false  &&  run == false)
        {
            heroanimator.SetTrigger("attack2");
            if (soundsoff == false)
            {
                swordsound.Play();
            }
        }
        if (Input.GetMouseButtonDown(0) && jump == false && roll == false && run == true  ||  Input.GetMouseButtonDown(1) && jump == false && roll == false && run == true)
        {
            heroanimator.SetTrigger("runattack");
            if (soundsoff == false)
            {
                swordsound.Play();
            }
        }
        if (Input.GetKeyDown(KeyCode.Return) && maincode.elixircount > 0 && healthimage.fillAmount >= 0.2 && roll == false && run == false && jump == false)
        {
            heroanimator.SetTrigger("health");
            maincode.elixircount--;
            healthimage.fillAmount += 1f;
            useelixir.Play();
        }
        if(Input.GetKeyDown(KeyCode.LeftShift) && praycount > 0 && healthimage.fillAmount >= 0.2 && roll == false && run == false && jump == false)
        {
            heroanimator.SetTrigger("pray");
            praycount--;
            healthimage.fillAmount += 0.2f;
        }


        if (circletouchme == true)
        {
            heroanimator.SetTrigger("hurt");
            circletouchme = false;
        }


        if (Input.GetKey(KeyCode.A)  || Input.GetKey(KeyCode.D))
        {
            run = true;
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            run = false;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            jump = true;
        }
        if(Input.GetKey(KeyCode.S))
        {
            roll = true;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            roll = false;
        }


        if (jump == true)
        {
            heroanimator.SetTrigger("jump");
        }
        if (run == true  &&  jump == false  &&  roll == false)
        {
            heroanimator.SetTrigger("run");
        }
        if (run == false &&  jump == false)
        {
            heroanimator.SetTrigger("idle");
        }
        if(run == true  &&  roll == true  &&  GetComponent<Rigidbody2D>().velocity.x != 0)
        {
            heroanimator.SetTrigger("roll");
        }
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "flatground")
        {
            jump = false;
        }
    }
}
