using UnityEngine;

public class CameraRandomRotation : MonoBehaviour
{
    public float minRotationSpeed = 1f;
    public float maxRotationSpeed = 5f;
    public float minRotationDuration = 1f;
    public float maxRotationDuration = 5f;

    private float rotationSpeed;
    private float rotationDuration;
    private float remainingRotationDuration;
    private float rotationDirection;

    private void Start()
    {
        SetRandomRotation();
    }

    private void Update()
    {
        if (remainingRotationDuration <= 0f)
        {
            SetRandomRotation();
        }

        float rotationAmount = rotationSpeed * Time.deltaTime * rotationDirection;
        transform.Rotate(0f, 0f, rotationAmount);
        remainingRotationDuration -= Time.deltaTime;
    }

    private void SetRandomRotation()
    {
        rotationSpeed = Random.Range(minRotationSpeed, maxRotationSpeed);
        rotationDuration = Random.Range(minRotationDuration, maxRotationDuration);
        rotationDirection = Random.value > 0.5f ? 1f : -1f;
        remainingRotationDuration = rotationDuration;
    }
}
