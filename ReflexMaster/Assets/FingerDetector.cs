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
                // Burada týklanan noktanýn dünya koordinatlarýný kullanabilirsiniz
                //Debug.Log("Týklanan nokta: " + touchPosition);
            }
        }
    }
}
