using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMoveController : MonoBehaviour
{
    [Tooltip("Im ms^-1")] [SerializeField] public float speed = 10;
    [Tooltip("Im m")] [SerializeField] public float bordersTopBottom = 10;
    [Tooltip("Im m")] [SerializeField] public float bordersLeftRight = 10;
    [SerializeField] public float positionPitchFactor = -3;
    [SerializeField] public float controlPitchFactor = -15;
    [SerializeField] public float positionYawFactor =  5;
    [SerializeField] public float controlRollFactor = -20;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    #region Private Methods

    /**
     * Change position of player
     */
    private void ProcessTranslation()
    {
        var clampedXPos = CalculateClampedPos("Horizontal", transform.localPosition.x, bordersLeftRight);
        var clampedYPos = CalculateClampedPos("Vertical", transform.localPosition.y, bordersTopBottom);
        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    private float CalculateClampedPos(string axisName, float localPosition, float borders)
    {
        float moveThrow = CrossPlatformInputManager.GetAxis(axisName);
        float offset = moveThrow * speed * Time.deltaTime;
        float rawNewPos = localPosition + offset;
        var clampedPos = Mathf.Clamp(rawNewPos, -borders, borders);
        return clampedPos;
    }

    /**
     * Rotate player
     */
    private void ProcessRotation()
    {
        var pitch = CalculatePitch();

        float yaw = CalculateYaw();
        float roll = CalculateRoll();
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private float CalculatePitch()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = CrossPlatformInputManager.GetAxis("Vertical") * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;
        return pitch;
    }

    private float CalculateYaw()
    {
        return transform.localPosition.x * positionYawFactor;
    }

    private float CalculateRoll()
    {
        return CrossPlatformInputManager.GetAxis("Horizontal") * controlRollFactor;
    }

    #endregion
}