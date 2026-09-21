using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip FalseSE, ClearSE, JumpSE, hitSE, StartSE;
    [SerializeField] AudioClip[] ReverseSE;

    public static SoundManager instance;

    [SerializeField] AudioSource bgmAudioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            PlayJumpSE();
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            // 自身のAudioSourceを取得（念のため自動取得に変更）
            if (audioSource == null)
                audioSource = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetBGMVolume(float volume)
    {
        bgmAudioSource.volume = volume;
    }

    public void PlayFalseSE()
    {
        audioSource.PlayOneShot(FalseSE);
    }

    public void PlayClearSE()
    {
        audioSource.PlayOneShot(ClearSE);
    }

    public void PlayJumpSE()
    {
        audioSource.PlayOneShot(JumpSE);
    }

    public void PlayhitSE()
    {
        audioSource.PlayOneShot(hitSE);
    }

    public void PlayStartSE()
    {
        audioSource.PlayOneShot(StartSE);
    }

    public void PlayReverseSE(int number)
    {
        audioSource.PlayOneShot(ReverseSE[number]);
    }
}
