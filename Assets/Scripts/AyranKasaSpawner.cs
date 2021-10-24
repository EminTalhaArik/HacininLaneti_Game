using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AyranKasaSpawner : MonoBehaviour
{

    public List<GameObject> kasaSpawnPoint;
    public GameObject kasaPrefab;

    bool control;

    void Start()
    {
        control = true;
    }

    
    void Update()
    {

        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().ayranCount <= 0 && GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().ayranAldiMi)
        {
            if (control)
            {
                Debug.Log("Ayran Kasasý Çalýþtý.....");
                control = false;
                StartCoroutine(KasaSpawner());
            }
        }
    }

    IEnumerator KasaSpawner()
    {
        yield return new WaitForSeconds(Random.Range(3, 12));
        GameObject kasaPos = kasaSpawnPoint[Random.Range(0, kasaSpawnPoint.Count)];
        Instantiate(kasaPrefab, new Vector3(kasaPos.transform.position.x, kasaPos.transform.position.y,0), Quaternion.identity);
        control = true;
    }
}
