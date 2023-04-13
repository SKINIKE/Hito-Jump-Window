using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackHomeButton : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene("0.StartPage");
    }
}
