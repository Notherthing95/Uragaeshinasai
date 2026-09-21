using UnityEngine;
using UnityEngine.SceneManagement;

public class FalseScript : MonoBehaviour
{
    public bool isFalsed = false;
    [SerializeField] GameObject FalseTxt;
    [SerializeField] ClearScript clearScript;
    public float interval = 3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isFalsed)
            interval -= Time.deltaTime;

        if (interval <= 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void False()
    {
        if (!isFalsed && !clearScript.isCleared)
        {
            isFalsed = true;
            FalseTxt.SetActive(true);
            TimeManager.isNowGaming = false;
            SoundManager.instance.PlayFalseSE();
            
        }
    }
}
