using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    // con fig vars
    [Header("DEBUG")]
    [SerializeField] bool targetTrace = false;
    [SerializeField] float traceLength = 100f;
    [SerializeField] float traceDuration = 0f;

    [Header("Position")]
    [Tooltip("In ms^-1"), SerializeField]
    float speed = 20f;
    [Tooltip("In m"), SerializeField]
    float xClamp = 15f;
    [Tooltip("In m"), SerializeField]
    float yClamp = 10f;

    [Header("Rotation")]
    [SerializeField]
    float pitchFactor = -1.8f;
    [SerializeField]
    float pitchControll = -22f;
    [SerializeField]
    float yawFactor = 1.8f;
    [SerializeField]
    float rollFactor = -18f;
    [SerializeField]
    float rollControll = -30f;

    [Header("Sound FX")]
    [SerializeField]
    AudioSource thrusterSound;

    //state vars
    float idleSoundPitch;
    
    // Start is called before the first frame update
    void Start()
    {
        if (thrusterSound)
        {
            idleSoundPitch = thrusterSound.pitch;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (targetTrace) Debug.DrawRay(transform.position, transform.forward * traceLength, Color.red, traceDuration);
        ProcessTranslation();
    }

    private void ProcessTranslation()
    {
        // handle x position
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * speed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xClamp, xClamp);

        // handle y position
        float yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * speed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yClamp, yClamp);

        AdjustThrustSound(xThrow, yThrow, clampedXPos);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
        ProcessRotation(xThrow, yThrow);
    }

    private void AdjustThrustSound(float xThrow, float yThrow, float clampedXPos)
    {
        if (!thrusterSound) return;

        float pitchMod = Mathf.Abs(xThrow) + Mathf.Abs(yThrow);
        thrusterSound.pitch = idleSoundPitch + pitchMod;

        float panMod = Mathf.Sin(transform.localPosition.x);
        thrusterSound.panStereo = transform.localPosition.x / 9;
    }

    private void ProcessRotation(float xThrow, float yThrow)
    {
        float pitch = transform.localPosition.y * pitchFactor + yThrow * pitchControll;
        float yaw = transform.localPosition.x * yawFactor;
        float roll = (transform.localPosition.x * transform.localPosition.y) / rollFactor + xThrow * rollControll;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
}
