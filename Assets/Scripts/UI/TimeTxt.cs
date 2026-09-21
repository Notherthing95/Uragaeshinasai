using System;
using TMPro;
using UnityEngine;

public class TimeTxt : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI txt;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TimeManager.isNowGaming)
        {
            TimeManager.GameTime += Time.deltaTime;
        }

        txt.text = TimeManager.GameTime.ToString("N2");
    }
}
