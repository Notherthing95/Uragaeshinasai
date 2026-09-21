using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    private Camera mainCamera;
    private float halfWidth;

    void Start()
    {
        mainCamera = Camera.main;

        // カメラの左右端のワールド座標を計算
        float camHeight = mainCamera.orthographicSize;
        float camWidth = camHeight * mainCamera.aspect;
        halfWidth = camWidth - (GetComponent<SpriteRenderer>().bounds.size.x / 2f);
    }

    void Update()
    {
        Vector2 pos = transform.position;

        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
            pos.x -= speed * Time.deltaTime;
        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
            pos.x += speed * Time.deltaTime;

        // カメラ範囲内にClamp
        float camX = mainCamera.transform.position.x;
        pos.x = Mathf.Clamp(pos.x, camX - halfWidth, camX + halfWidth);

        transform.position = pos;
    }
}