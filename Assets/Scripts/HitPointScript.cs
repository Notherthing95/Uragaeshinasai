using UnityEngine;

public class HitPointScript : MonoBehaviour
{
    [SerializeField] ClearScript clearScript;
    [SerializeField] FalseScript falseScript;
    [SerializeField] SquareScript squareScript;
    [SerializeField] hit[] hit;
    public bool isCleared = false; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !clearScript.isCleared && !isCleared)
        {
            if (hit[0].isHit && hit[1].isHit)
            {
                clearScript.Clear();
                isCleared = true;
            }
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log(hit[0].isHit + " " + hit[1].isHit + " " + collision.gameObject.GetComponent<SquareScript>().isWorked);
            if (collision.gameObject.GetComponent<SquareScript>().isWorked)
            {
                falseScript.False();
                squareScript.isFalsed = true;
                TimeManager.isNowGaming = false;
            }
        }

        Debug.Log(collision.gameObject.tag);
    }
}
