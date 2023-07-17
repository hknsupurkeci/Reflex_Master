using UnityEngine;

public class FingerDetector : MonoBehaviour
{
    private Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved)
            {
                Vector2 touchPosition = mainCamera.ScreenToWorldPoint(touch.position);
                transform.position = touchPosition;
            }
        }
    }
    private void LateUpdate()
    {
        if (Input.touchCount <= 0)
        {
            Vector2 touchPosition = new Vector2(999, 999);
            transform.position = touchPosition;
        }
    }
}
