using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class maincode : MonoBehaviour
{
    bool sounds_off = false;
    bool heroontheground = false;
    bool settingson = false;
    bool controlson = false;
    public static int elixircount = 0;
    public GameObject hero;
    public GameObject elixir;
    public GameObject fkey;
    public GameObject camerafollowing;
    public GameObject circlehero;
    public GameObject settingsscene;
    public GameObject controlsscene;
    public GameObject music;
    public Animator heroanimator;
    public Image healthimage;
    public AudioSource hurt;
    public AudioSource enemyhurt;
    public TMPro.TextMeshProUGUI elixircounttext;

    private void Start()
    {
        elixircount = 0;
    }

    void Update()
    {
        camerafollowing.transform.position = new Vector3(hero.GetComponent<Rigidbody2D>().transform.position.x, hero.GetComponent<Rigidbody2D>().transform.position.y + 0.35f, hero.GetComponent<Rigidbody2D>().transform.position.z - 5);

        elixircounttext.text = elixircount.ToString();

        if (healthimage.fillAmount < 0.2f)
        {
            heroanimator.SetTrigger("death");
            Invoke("loadscenedefeat", 3);
        }
        if(hero.transform.position.y <= -8)
        {
            Invoke("loadscenedefeat", 0);
        }

        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            Invoke("circleherofunction", 0.5f);
        }

        if (Input.GetKey(KeyCode.A) && healthimage.fillAmount >= 0.2f)
        {
            hero.GetComponent<Rigidbody2D>().velocity = new Vector2(-1, hero.GetComponent<Rigidbody2D>().velocity.y);
            hero.GetComponent<Rigidbody2D>().transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        if (Input.GetKey(KeyCode.D) && healthimage.fillAmount >= 0.2f)
        {
            hero.GetComponent<Rigidbody2D>().velocity = new Vector2(1, hero.GetComponent<Rigidbody2D>().velocity.y);
            hero.GetComponent<Rigidbody2D>().transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (Input.GetKeyUp(KeyCode.A) && healthimage.fillAmount >= 0.2f)
        {
            hero.GetComponent<Rigidbody2D>().velocity = new Vector2(-0.2f, hero.GetComponent<Rigidbody2D>().velocity.y);
            hero.GetComponent<Rigidbody2D>().transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (Input.GetKeyUp(KeyCode.D) && healthimage.fillAmount >= 0.2f)
        {
            hero.GetComponent<Rigidbody2D>().velocity = new Vector2(0.2f, hero.GetComponent<Rigidbody2D>().velocity.y);
            hero.GetComponent<Rigidbody2D>().transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.W) && healthimage.fillAmount >= 0.2f)
        {
            if (heroontheground == true)
            {
               hero.GetComponent<Rigidbody2D>().velocity = new Vector2(hero.GetComponent<Rigidbody2D>().velocity.x, 1.2f);
               hero.GetComponent<Rigidbody2D>().gravityScale = 0.2f;
               heroontheground = false;
               Invoke("normalgravity", 1.2f);
            }
        }


        if (hero.GetComponent<Rigidbody2D>().transform.position.x < elixir.GetComponent<Rigidbody2D>().transform.position.x + 0.2 && hero.GetComponent<Rigidbody2D>().transform.position.x > elixir.GetComponent<Rigidbody2D>().transform.position.x - 0.2)
        {
            fkey.SetActive(true);

            if(Input.GetKey(KeyCode.F))
            {
                elixir.SetActive(false);
                Destroy(fkey);
                elixircount++;
            }
        }
        else
        {
            fkey.SetActive(false);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "flatground")
        {
            heroontheground = true;
        }

        if (collision.collider.tag == "circle"  ||  collision.collider.tag == "circle2"  ||  collision.collider.tag == "circle3")
        {
            healthimage.fillAmount -= 0.2f;
            if (sounds_off == false)
            {
                hurt.Play();
            }

            if (healthimage.fillAmount > 0.2)
            {
                animationcode.circletouchme = true;
            }
        }

        if (collision.collider.tag == "circleboss")
        {
            healthimage.fillAmount -= 0.4f;
            if (sounds_off == false)
            {
                hurt.Play();
            }

            if (healthimage.fillAmount > 0.2)
            {
                animationcode.circletouchme = true;
            }
        }
    }

    public void circleherofunction()
    {
        circlehero.SetActive(true);
        Invoke("circleherofunction2", 0.1f);
    }

    public void circleherofunction2()
    {
        circlehero.SetActive(false);
    }

    public void normalgravity()
    {
        hero.GetComponent<Rigidbody2D>().gravityScale = 1;
    }

    public void loadscenemenu()
    {
        SceneManager.LoadScene(0);
    }

    public void loadsceneplay()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }

    public void loadscenedefeat()
    {
        SceneManager.LoadScene(3);
    }

    public void loadscenesettings()
    {
        controlsscene.SetActive(false);

        if (settingson == false)
        {
            settingsscene.SetActive(true);
            settingson = true;
            Time.timeScale = 0f;
        }
        else
        {
            settingsscene.SetActive(false);
            settingson = false;
            Time.timeScale = 1f;
        }
    }

    public void loadscenecontrols()
    {
        settingsscene.SetActive(false);

        if (controlson == false)
        {
            controlsscene.SetActive(true);
            controlson = true;
            Time.timeScale = 0f;
        }
        else
        {
            controlsscene.SetActive(false);
            controlson = false;
            Time.timeScale = 1f;
        }
    }


    public void musicon()
    {
        music.SetActive(true);
    }

    public void musicoff()
    {
        music.SetActive(false);
    }

    public void soundson()
    {
        sounds_off = false;
        animationcode.soundsoff = false;
    }

    public void soundsoff()
    {
        sounds_off = true;
        animationcode.soundsoff = true;
    }

    public void quit()
    {
        Application.Quit();
    }
}
