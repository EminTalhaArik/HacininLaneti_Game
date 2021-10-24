using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AyranManager : MonoBehaviour
{

    public float speed;
    public bool isRight;

    bool control;

    void Start()
    {
        control = true;
        Destroy(this.gameObject, 10);
    }

    void Update()
    {
        if (control)
        {
            if (isRight)
            {
                right();
            }
            else
            {
                left();
            }
        }

    }

    public void right()
    {
        control = false;
        GetComponent<Rigidbody2D>().AddForce(new Vector2(600, 0));
    }
    public void left()
    {
        control = false;
        GetComponent<Rigidbody2D>().AddForce(new Vector2(-600, 0));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Garson")
        {
            collision.gameObject.GetComponent<GarsonController>().normalHasarAl();
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Haci")
        {
            collision.gameObject.GetComponent<HaciController>().normalHasarAl();
            Destroy(this.gameObject);
        }
    }
}
