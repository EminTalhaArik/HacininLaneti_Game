using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeciciAyranKasasiManager : MonoBehaviour
{
    bool ayranAlDurum;

    GameObject player;

    public GameObject ayranKasasiText;

    void Start()
    {
        ayranAlDurum = false;
        player = GameObject.FindGameObjectWithTag("Player");
        ayranKasasiText.SetActive(false);
    }

    void Update()
    {
        if (ayranAlDurum)
        {
            AyranAl();
        }
    }

    public void AyranAl()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            player.GetComponent<PlayerManager>().GeciciAyranYenile();
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ayranAlDurum = true;
            ayranKasasiText.SetActive(true);
        }
    }

    
}
