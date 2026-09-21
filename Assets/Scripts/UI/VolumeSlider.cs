using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VolumeSlider : MonoBehaviour, IPointerUpHandler
{
    [SerializeField] Slider slider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 保存された音量を読み込む（デフォルト値は0.5f）
        float savedVolume = PlayerPrefs.GetFloat("BGMVolume", 0.5f);
        slider.value = savedVolume;
        SoundManager.instance.SetBGMVolume(savedVolume);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetBGMVolume(float volume)
    {
        SoundManager.instance.SetBGMVolume(volume);
        // 音量が変わるたびに保存
        PlayerPrefs.SetFloat("BGMVolume", volume);
    }

    // Sliderから指・マウスを離した瞬間に呼ばれる
    public void OnPointerUp(PointerEventData eventData)
    {
        SoundManager.instance.PlayStartSE();
    }
}
