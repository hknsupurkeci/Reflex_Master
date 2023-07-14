using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public float shakeDuration = 0.5f;
    public float shakeMagnitude = 0.1f;

    private float currentShakeDuration = 0f;
    private float currentShakeMagnitude = 0f;
    private Vector3 originalPosition;

    private void Start()
    {
        originalPosition = transform.localPosition;
    }

    private void Update()
    {
        if (currentShakeDuration > 0)
        {
            transform.localPosition = originalPosition + Random.insideUnitSphere * currentShakeMagnitude;

            currentShakeDuration -= Time.deltaTime;
        }
        else
        {
            currentShakeDuration = 0f;
            transform.localPosition = originalPosition;
        }
    }

    public void ShakeScreen()
    {
        currentShakeDuration = shakeDuration;
        currentShakeMagnitude = shakeMagnitude;
    }
}
