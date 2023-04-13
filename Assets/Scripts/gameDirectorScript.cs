using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class gameDirectorScript : MonoBehaviour
{
    GameObject gameOverModal;
    Image panel;
    Text victoryText;
    Text endingText;

    bool isVictory = false;

    // Start is called before the first frame update
    void Start()
    {
        panel = GameObject.Find("Canvas/Panel").GetComponent<Image>();
        victoryText = GameObject.Find("Canvas/victory").GetComponent<Text>();
        endingText = GameObject.Find("Canvas/endingTime").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isVictory)
        {
            panel.enabled = true;
            victoryText.enabled = true;
            endingText.enabled = true;
        }
        else
        {
            panel.enabled = false;
            victoryText.enabled = false;
            endingText.enabled = false;
        }
    }


    public void SetVictory(bool isVictory)
    {
        this.isVictory = isVictory;
    }

    public void SetEndingTime()
    {
        playTimeController gameTime = GameObject.Find("Canvas/playTime").GetComponent<playTimeController>();

        endingText.text = "총 소요시간: " + gameTime.GetTimeCount() + "초";
    }

}
