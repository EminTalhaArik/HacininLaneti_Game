using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HaciController : MonoBehaviour
{

    GameObject player;
    public float speed;

    public float jumpSeconds;

    Rigidbody2D myRigidbody;

    bool control;

    bool move;

    bool saldirDurum;

    float health;

    public AudioSource dusmanSound;

    void Start()
    {
        move = true;
        saldirDurum = true;
        control = true;
        player = GameObject.FindGameObjectWithTag("Player");
        myRigidbody = GetComponent<Rigidbody2D>();
        health = 24;
    }

    void Update()
    {

        if (control)
        {
            control = false;
            StartCoroutine(Jump());
        }
        if (move)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, speed);
            if (this.transform.position.x < player.transform.position.x)
            {
                this.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                this.transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }

    }

    public void normalHasarAl()
    {
        health--;
        Debug.Log("Hacýnýn Saðlýk Durumu : " + health);
        hasarControl();
    }

    public void yuksekHasarAl()
    {
        health = health - 3;
        Debug.Log("Hacýnýn Saðlýk Durumu : " + health);
        hasarControl();

    }

    void hasarControl()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene(6);
            Destroy(this.gameObject);

        }
    }

    IEnumerator Jump()
    {
        yield return new WaitForSeconds(jumpSeconds);

        myRigidbody.AddForce(new Vector2(0, 200));
        control = true;
    }

    public void hasarVer()
    {
        if (saldirDurum)
        {
            saldirDurum = false;
            StartCoroutine(saldir());
        }
    }

    IEnumerator saldir()
    {
        player.GetComponent<PlayerManager>().yuksekHasarVer();
        dusmanSound.Play();
        yield return new WaitForSeconds(2);
        saldirDurum = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            move = false;
            hasarVer();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            move = true;
        }
    }
}
