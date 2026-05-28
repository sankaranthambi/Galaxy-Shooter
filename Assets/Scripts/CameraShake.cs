using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeDuration = 0f;

    public float shakeMagnitude = 0.2f;

    Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.localPosition;
    }

    void Update()
    {
        if(shakeDuration > 0)
        {
            transform.localPosition =
                originalPosition + Random.insideUnitSphere * shakeMagnitude;

            shakeDuration -= Time.deltaTime;
        }
        else
        {
            shakeDuration = 0f;

            transform.localPosition = originalPosition;
        }
    }

    public void Shake(float duration)
    {
        shakeDuration = duration;
    }
}