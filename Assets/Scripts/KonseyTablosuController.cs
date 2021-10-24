using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KonseyTablosuController : MonoBehaviour
{

    public GameObject konseyTablosuText;
    GameObject GameManagerObject;

    void Start()
    {
        konseyTablosuText.SetActive(false);
        GameManagerObject = GameObject.Find("GameManager");
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            konseyTablosuText.SetActive(true);
            GameManagerObject.gameObject.GetComponent<FirstLevelGameManager>().konseyTablosu();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            konseyTablosuText.SetActive(false);
        }
    }
}
