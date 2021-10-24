using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DukkanPideBankasManagert : MonoBehaviour
{

    public GameObject pideBankasiText;

    bool control;

    void Start()
    {
        pideBankasiText.SetActive(false);
        control = false;
    }

    void Update()
    {
        if (control)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene(4);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            pideBankasiText.SetActive(true);

            control = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            control = false;
            pideBankasiText.SetActive(false);

        }
    }
}
