using System;
using UnityEngine;
using UnityEngine.Video;

public class PBCamera : MonoBehaviour
{
    public float minX = -360.0f;
    public float maxX = 360.0f;

    public float minY = -45.0f;
    public float maxY = 45.0f;

    public float sensX = 100.0f;
    public float sensY = 100.0f;

    float rotationY = 0.0f;
    float rotationX = 0.0f;

    float MouseX;
    float MouseY;

    public VideoPlayer videoPlayer;
    public Canvas canvas;

    void Start()
    {
        BWEventManager.StartListening("ResetVR", ResetVR);

        // Reset the VR
        BWEventManager.TriggerEvent("ResetVR");
    }

    ////////////////////////////////////////////////////////////////////////////////
    // ResetVR

    void ResetVR()
    {
        Debug.Log("ResetVR");
        OVRManager.display.RecenterPose();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            BWEventManager.TriggerEvent("Stop");
            videoPlayer.Pause();
            canvas.gameObject.SetActive(true);            // Show the menu
        }

        // Reset all the VR - so recalibrate pose
        if (Input.GetKeyUp(KeyCode.R))
        {
            BWEventManager.TriggerEvent("ResetVR");
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            var x = Input.GetAxis("Mouse X");
            var y = Input.GetAxis("Mouse Y");
            if (x != MouseX || y != MouseY)
            {
                rotationX += x * sensX * Time.deltaTime;
                rotationY += y * sensY * Time.deltaTime;
                rotationY = Mathf.Clamp(rotationY, minY, maxY);
                MouseX = x;
                MouseY = y;
                transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
            }
        }
    }
}