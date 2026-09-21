using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class RetryScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // ここにスタートした時の音を入れる（苦肉の策）
        SoundManager.instance.PlayStartSE();
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.rKey.wasPressedThisFrame)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
