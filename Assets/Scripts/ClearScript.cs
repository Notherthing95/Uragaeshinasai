using UnityEngine;
using UnityEngine.SceneManagement;
using unityroom.Api;

public class ClearScript : MonoBehaviour
{
    public bool isCleared = false;
    [SerializeField] private string moveSceneName;
    [SerializeField] GameObject ClearTxt;
    [SerializeField] FalseScript falseScript;
    public float interval = 3;
    public int clearHitCount = 1;
    private int _endCount = 3;
    private int _hitCount = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isCleared)
            interval -= Time.deltaTime;

        if (interval <= 0)
        {
            // Todo: マジックナンバー3をEndSceneに変える
            if (clearHitCount < 3)
                SceneManager.LoadScene(moveSceneName);
        }
    }

    public void Clear()
    {
        _hitCount++;
        SoundManager.instance.PlayReverseSE(_hitCount - 1);
        if (_hitCount >= clearHitCount && !falseScript.isFalsed)
        {
            isCleared = true;
            ClearTxt.SetActive(true);
            TimeManager.isNowGaming = false;
            SoundManager.instance.PlayClearSE();
            if (clearHitCount >= 3) // Todo: マジックナンバー3をEndSceneに変える
            {
                if (TimeManager.GameTime < TimeManager.HiScoreTime)
                {
                    TimeManager.HiScoreTime = TimeManager.GameTime;
                }
                UnityroomApiClient.Instance.SendScore(1, TimeManager.HiScoreTime, ScoreboardWriteMode.Always);
            }
        }
    }
}
