using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsUIManager : MonoBehaviour
{

    public Text ayranText;
    public Text donerText;
    public Text canText;

    public GameObject kalkanBicak;

    void Start()
    {
        ayranText.text = "0";
        donerText.text = "0";
        kalkanGuncelleTrue();
    }

    void Update()
    {
        
    }

    public void CanGuncelle(int saglikDurumu)
    {
        canText.text = "" + saglikDurumu;
    }

    public void ayranGuncelle(int ayranSayisi)
    {
        ayranText.text = "" + ayranSayisi;
    }
    public void donerGuncelle(int donerSayisi)
    {
        donerText.text = "" + donerSayisi;
    }

    public void kalkanGuncelleFalse()
    {
        kalkanBicak.SetActive(false);
    }

    public void kalkanGuncelleTrue()
    {
        kalkanBicak.SetActive(true);
    }
}
