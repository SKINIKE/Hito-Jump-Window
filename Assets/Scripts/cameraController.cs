using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{

    private float cameraSpeed = 5.0f;
    private GameObject hito;
    
    void Start()
    {
       hito = GameObject.Find("hito");
    }

    
    void Update()
    {
        Vector3 dir = hito.transform.position - this.transform.position;
        Vector3 moveVector = new Vector3(this.transform.position.x, dir.y * cameraSpeed * Time.deltaTime, 0.0f);
        this.transform.Translate(moveVector);
    }
}
