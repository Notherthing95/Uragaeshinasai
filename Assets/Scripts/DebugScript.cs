using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class DebugScript : MonoBehaviour
{
    [SerializeField] string[] SceneNames;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.shiftKey.IsPressed())
        {
            if (Keyboard.current.digit1Key.wasPressedThisFrame)
            {
                SceneManager.LoadScene(SceneNames[0]);
            }
            if (Keyboard.current.digit2Key.wasPressedThisFrame)
            {
                SceneManager.LoadScene(SceneNames[1]);
            }
            if (Keyboard.current.digit3Key.wasPressedThisFrame)
            {
                SceneManager.LoadScene(SceneNames[2]);
            }
        }
    }
}
