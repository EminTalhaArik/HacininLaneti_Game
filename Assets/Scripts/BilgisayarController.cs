using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BilgisayarController : MonoBehaviour
{

    public GameObject computerText;

    GameObject GameManagerObject;

    void Start()
    {
        computerText.SetActive(false);
        GameManagerObject = GameObject.Find("GameManager");
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            computerText.SetActive(true);
            GameManagerObject.gameObject.GetComponent<FirstLevelGameManager>().bilgisayarTablosu();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            computerText.SetActive(false);
        }
    }
}
