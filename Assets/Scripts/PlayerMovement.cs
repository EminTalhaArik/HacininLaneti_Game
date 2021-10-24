using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    Rigidbody2D myRigidbody;

    bool control;

    public float jumpSecond;

    public bool isRight;
    void Start()
    {
        control = true;
        myRigidbody = GetComponent<Rigidbody2D>();  
    }

    
    void Update()
    {
        Move();
    }

    void Move()
    {
        float moveInput = Input.GetAxis("Horizontal");

        if(moveInput < 0)
        {
            this.gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
            isRight = false;
        }
        else if(moveInput > 0)
        {
            this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            isRight = true;
        }

        myRigidbody.velocity = new Vector2(speed * moveInput, myRigidbody.velocity.y);

        if (control)
        {
            control = false;
            StartCoroutine(Jump());
        }
    }

    IEnumerator Jump()
    {
        myRigidbody.AddForce(new Vector2(0, 200));
        yield return new WaitForSeconds(jumpSecond);
        control = true;
    }


}
