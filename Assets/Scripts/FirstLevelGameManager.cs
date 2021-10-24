using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstLevelGameManager : MonoBehaviour
{

    bool konseyTablosuGorevi;
    bool bilgisayarGorevi;
    bool mantarPanoGorevi;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void konseyTablosu()
    {
        konseyTablosuGorevi = true;
        
    }

    public void bilgisayarTablosu()
    {
        bilgisayarGorevi = true;
        
    }

    public void mantarTablosu()
    {
        mantarPanoGorevi = true;
        
    }

    public void gorevControl()
    {
        if(konseyTablosuGorevi && bilgisayarGorevi && mantarPanoGorevi)
        {
            Debug.Log("Görevler Tamamlandý");
            SceneManager.LoadScene(2);
        }
    }
}
