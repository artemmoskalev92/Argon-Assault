using System;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [Header("General Setup Settings")]
    [Tooltip("How fast ship moves up and down based upon player input")]
    [SerializeField] float speed = 10f;
    [Tooltip("How far player moves horizontally")]
    [SerializeField] float xRange = 15f;
    [Tooltip("How far player moves vertically")]
    [SerializeField] float yRange = 15f;

    [Header("Laser gun array")]
    [Tooltip("Add all player lasers here")]
    [SerializeField] GameObject[] lasers; 

    [Header("Screen position based tuning")]
    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float positionYawFactor = 2f;

    [Header("Player input based tuning")]
    [SerializeField] float controlPitchFactor = -20f;
    [SerializeField] float controlRollFactor = 40f;

    float xThrow, yThrow;

    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();

    }
    void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;

        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void ProcessTranslation()
    {
         xThrow = Input.GetAxis("Horizontal");
         yThrow = Input.GetAxis("Vertical");


        float xOffset = xThrow * Time.deltaTime * speed;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        float yOffset = yThrow * Time.deltaTime * speed;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }
    void ProcessFiring()
    {
        if (Input.GetButton("Fire1"))
        {
            SetLasersActive(true);
        }
        else
        {
            SetLasersActive(false);
        }
    }

    void SetLasersActive(bool isActive)
    {
        foreach (GameObject laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
        }
    }

    
}
