using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{

    GameObject GameManagerObject;

    void Start()
    {
        GameManagerObject = GameObject.Find("GameManager");
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameManagerObject.GetComponent<FirstLevelGameManager>().gorevControl();
        }
    }
}
