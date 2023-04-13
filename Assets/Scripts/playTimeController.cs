using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class playTimeController : MonoBehaviour
{
    private GameObject hito;
    private Text playTime;
    float timeCount;

    void Start()
    {
        hito = GameObject.Find("hito");
        playTime = GetComponent<Text>();
    }
  
    void Update()
    {
        timeCount += Time.deltaTime;
        playTime.text = "경과시간: " + timeCount.ToString("N2") + "초";
    }

    public string GetTimeCount()
    {
        return timeCount.ToString("N2");
    }
}