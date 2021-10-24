using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MantarPanoController : MonoBehaviour
{

    public GameObject mantarPanoText;
    GameObject GameManagerObject;

    void Start()
    {
        mantarPanoText.SetActive(false);
        GameManagerObject = GameObject.Find("GameManager");
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            mantarPanoText.SetActive(true);
            GameManagerObject.gameObject.GetComponent<FirstLevelGameManager>().mantarTablosu();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            mantarPanoText.SetActive(false);
        }
    }
}
