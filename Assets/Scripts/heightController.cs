using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class heightController : MonoBehaviour
{
    private GameObject hito;
    private Text height;
    private float maxHitoHeight;
    private Vector3 hitoHeight;

    void Start()
    {
        hito = GameObject.Find("hito");
        height = GetComponent<Text>();
        
        hitoHeight = hito.transform.position + new Vector3(0f, 3.54f, 0f);
        maxHitoHeight = hitoHeight.y;
        height.text = "최대높이: " + hitoHeight.y.ToString("N2") + "M";
    }
  
    void Update()
    {

        hitoHeight = hito.transform.position + new Vector3(0f,3.54f, 0f);
        if(hitoHeight.y > maxHitoHeight)
        {
            maxHitoHeight = hitoHeight.y;
            height.text = "최대높이: " + hitoHeight.y.ToString("N2") + "M";
        }
    }
}