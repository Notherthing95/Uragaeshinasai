using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Stage1Start : MonoBehaviour
{
    [SerializeField] GameObject DescriptionTxt;
    [SerializeField] GameObject VolumeSlider;
    [SerializeField] GameObject Timetext;

    public bool isJustResumed = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 0;
        TimeManager.GameTime = 0;
        TimeManager.isNowGaming = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Time.timeScale = 1;
            DescriptionTxt.SetActive(false);
            VolumeSlider.SetActive(false);
            Timetext.SetActive(true);

            TimeManager.isNowGaming = true;
            isJustResumed = true;
            this.enabled = false;
        }

    }
    
}
