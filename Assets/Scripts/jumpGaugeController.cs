using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class jumpGaugeController : MonoBehaviour
{
    RectTransform jumpGaugeTransform;
    Transform hitoTransform;

    // Start is called before the first frame update
    void Start()
    {
        jumpGaugeTransform = this.GetComponent<RectTransform>();
        hitoTransform = GameObject.Find("hito").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        jumpGaugeTransform.position = Camera.main.WorldToScreenPoint(hitoTransform.transform.position + new Vector3(0f, 0.7f, 0));
    }
}
