using UnityEngine;
using UnityEngine.InputSystem;

public class SquareScript : MonoBehaviour
{
    [SerializeField] FalseScript falseScript;
    [SerializeField] HitPointScript hitPointScript;
    [SerializeField] Stage1Start stage1start;
    Rigidbody2D rb;
    public float Jumpheight = 5;

    bool isInTheAir = false;
    public bool isFalsed = false;
    public bool isWorked = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (stage1start != null && stage1start.isJustResumed)
            isInTheAir = true;
        
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            rb.AddForce(gameObject.transform.up * Jumpheight, ForceMode2D.Impulse);
        }

        if (hitPointScript.isCleared && !isWorked)
            isWorked = true;

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !isInTheAir)
            isInTheAir = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float z = transform.eulerAngles.z;
        if (z > 180f) z -= 360f;

        if (collision.gameObject.CompareTag("Ground") && isInTheAir && !isFalsed && 
            !hitPointScript.isCleared && Mathf.Abs(z) < 115)
        {
            falseScript.False();
            isFalsed = true;
            TimeManager.isNowGaming = false;
        }
        else if (collision.gameObject.CompareTag("Player") && collision.gameObject.GetComponent<SquareScript>().isWorked && !hitPointScript.isCleared)
        {
            falseScript.False();
            isFalsed = true;
            TimeManager.isNowGaming = false;
        }

        SoundManager.instance.PlayhitSE();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        float z = transform.eulerAngles.z;
        if (z > 180f) z -= 360f;

        if (collision.gameObject.CompareTag("Ground") && isInTheAir && !isFalsed &&
            !hitPointScript.isCleared && Mathf.Abs(z) < 115)
        {
            rb.angularVelocity = 0;
        }
    }
}
