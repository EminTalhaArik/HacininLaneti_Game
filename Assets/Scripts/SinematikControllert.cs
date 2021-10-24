using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SinematikControllert : MonoBehaviour
{

    public GameObject isimTextTel;
    public GameObject metinTextTel;

    public GameObject isimTextDialog;
    public GameObject metinTextDialog;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void firstSceneMudur(string mesaj)
    {
        isimTextTel.GetComponent<TextMesh>().text = "Müdür PB";
        metinTextTel.GetComponent<TextMesh>().text = mesaj;
        
    }

    public void characterDialogMessage(string message)
    {
        isimTextDialog.GetComponent<TextMesh>().text = "Ýskender Hakký";
        metinTextDialog.GetComponent<TextMesh>().text = message;
    }

    public void secondTelephoneDialog(string message)
    {
        isimTextTel.GetComponent<TextMesh>().text = "Büyük Bey";
        metinTextTel.GetComponent<TextMesh>().text = message;
    }

    public void oyunaGec()
    {
        SceneManager.LoadScene(3);
    }
}
