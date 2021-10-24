using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject playerObject;
    
    public float minX;
    public float minY;

    public float maxX;
    public float maxY;


    void Start()
    {
        
    }


    void Update()
    {
        this.transform.position = new Vector3(Mathf.Clamp(playerObject.transform.position.x, minX, maxX),Mathf.Clamp(playerObject.transform.position.y,minY,maxY),this.transform.position.z);
    }
}
