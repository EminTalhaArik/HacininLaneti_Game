using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeciciDonerKasasiManager : MonoBehaviour
{
    bool donerDurum;

    GameObject player;

    public GameObject donerKasasiText;

    void Start()
    {
        donerDurum = false;
        player = GameObject.FindGameObjectWithTag("Player");
        donerKasasiText.SetActive(false);
    }

    void Update()
    {
        if (donerDurum)
        {
            DonerAl();
        }

    }

    public void DonerAl()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            player.GetComponent<PlayerManager>().GeciciDonerYenile();
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            donerDurum = true;
            donerKasasiText.SetActive(true);
        }
    }

}
