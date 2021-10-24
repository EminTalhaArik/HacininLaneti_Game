using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    int health;

    public bool ayranAldiMi;
    public bool donerAldiMi;
    
    public int ayranCount;
    public int donerCount;

    bool kalkanDurum;

    public GameObject kalkanObject;

    public GameObject ayranPrefab;
    
    public Transform namlu;

    public GameObject donerPrefab;

    public List<GameObject> hasarEffectPos;
    GameObject uiManager;

    public AudioSource ayranSound;
    public AudioSource donerSound;
    public AudioSource yenilemeSound;


    void Start()
    {
        ayranAldiMi = false;
        donerAldiMi = false;
        kalkanDurum = true;
        health = 10;
        ayranCount = 0;
        donerCount = 0;
        kalkanObject.SetActive(false);
        uiManager = GameObject.Find("UIManager");
        uiManager.GetComponent<StatsUIManager>().CanGuncelle(health);
    }

    void Update()
    {
        
        if(ayranCount > 0 && Input.GetKeyDown(KeyCode.F))
        {
            AyranFirlat();
        }

        if (donerCount > 0 && Input.GetKeyDown(KeyCode.G))
        {
            DonerFirlat();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            KalkanAl();
        }
        

    }

    public void KalkanAl()
    {
        if (kalkanDurum)
        {
            kalkanObject.SetActive(true);
            uiManager.GetComponent<StatsUIManager>().kalkanGuncelleFalse();
            StartCoroutine(KalkalKapat());
        }
    }

    IEnumerator KalkalKapat()
    {
        kalkanDurum = false;
        yield return new WaitForSeconds(4);
        uiManager.GetComponent<StatsUIManager>().kalkanGuncelleTrue();
        kalkanObject.SetActive(false);
        StartCoroutine(kalkanTime());
    }

    IEnumerator kalkanTime()
    {
        yield return new WaitForSeconds(10);
        kalkanDurum = true;
    }

    public void AyranFirlat()
    {
        ayranCount--;
        ayranSound.Play();
        uiManager.GetComponent<StatsUIManager>().ayranGuncelle(ayranCount);
        GameObject ayran = Instantiate(ayranPrefab, namlu);
        ayran.GetComponent<AyranManager>().isRight = GetComponent<PlayerMovement>().isRight;
        
    }

    public void DonerFirlat()
    {
        donerCount--;
        donerSound.Play();
        uiManager.GetComponent<StatsUIManager>().donerGuncelle(donerCount);
        GameObject doner = Instantiate(donerPrefab, namlu);
        doner.GetComponent<DonerManager>().isRight = GetComponent<PlayerMovement>().isRight;

    }

    public void DonerYenile()
    {
        donerCount = 4;
        donerAldiMi = true;
        yenilemeSound.Play();
        uiManager.GetComponent<StatsUIManager>().donerGuncelle(donerCount);
        Debug.Log("Güncel Döner Sayýsý " + donerCount);
    }

    public void GeciciDonerYenile()
    {
        donerCount = 1;
        yenilemeSound.Play();
        uiManager.GetComponent<StatsUIManager>().donerGuncelle(donerCount);
        Debug.Log("Güncel Döner Sayýsý " + donerCount);
    }

    public void AyranYenile()
    {
        ayranCount = 10;
        ayranAldiMi = true;
        yenilemeSound.Play();
        uiManager.GetComponent<StatsUIManager>().ayranGuncelle(ayranCount);
        Debug.Log("Güncel Ayran Sayýsý " + ayranCount);
    }

    public void GeciciAyranYenile()
    {
        ayranCount = 4;
        ayranAldiMi = true;
        yenilemeSound.Play();
        uiManager.GetComponent<StatsUIManager>().ayranGuncelle(ayranCount);
        Debug.Log("Güncel Ayran Sayýsý " + ayranCount);
    }

    public void HasarEfekt(int hasar)
    {
        StartCoroutine(efektGoster(hasar));
    }

    IEnumerator efektGoster(int hasar)
    {
        GameObject efekt = hasarEffectPos[Random.Range(0, hasarEffectPos.Count)];
        efekt.SetActive(true);
        efekt.GetComponent<TextMesh>().text = hasar.ToString();
        
        yield return new WaitForSeconds(1);

        efekt.SetActive(false);
    }

    public void normalHasarVer()
    {
        health--;
        healthControl();
        uiManager.GetComponent<StatsUIManager>().CanGuncelle(health);
        HasarEfekt(-1);
        Debug.Log(health + " Hasar verildi");
    }

    public void yuksekHasarVer()
    {
        health = health - 2;
        healthControl();
        uiManager.GetComponent<StatsUIManager>().CanGuncelle(health);
        HasarEfekt(-2);
        Debug.Log(health + " Hasar verildi");
    }

    public void healthControl()
    {
        if(health <= 0)
        {

            SceneManager.LoadScene(3);
            
        }
    }

}
