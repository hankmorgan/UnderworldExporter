using UnityEngine;
using System.Collections;
//Taken and adapted from https://gist.github.com/ftvs/5822103
public class CameraShake : UWEBase
{
    // Transform of the camera to shake. Grabs the gameObject's transform
    // if null.
    public Transform camTransform;

    // How long the object should shake for.
    private float shakeDuration = 0f;

    // Amplitude of the shake. A larger value shakes the camera harder.
    private float shakeAmount = 0.7f;
    private float decreaseFactor = 1.0f;

    Vector3 originalPos;

    public bool shaking = false;
    public static CameraShake instance;

    void Awake()
    {
        instance = this;
        if (camTransform == null)
        {
            camTransform = GetComponent(typeof(Transform)) as Transform;
        }
    }

    public void ShakeEarthQuake(float duration)
    {
        if (shaking) { return; }//Don't add more shake
        shakeAmount = 0.7f;
        shakeDuration = duration;
    }

    public void ShakeCombat(float duration)
    {
        if (shaking) { return; }//Don't add more shake
        shakeAmount = 0.1f;
        shakeDuration = duration;
    }

    void OnEnable()
    {
        originalPos = camTransform.localPosition;
    }

    void Update()
    {
        if (shakeDuration > 0)
        {
            shaking = true;
            camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shaking = false;
            shakeDuration = 0f;
            camTransform.localPosition = originalPos;
        }
    }
}