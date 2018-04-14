using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunTriggerRotation : MonoBehaviour
{
    public GameObject controllerRight;
    public GameObject controllerLeft;
    public float triggerPressed;
    private SteamVR_Controller.Device device;
    private Trigger controller;
    private float minTriggerRotation = -10f;
    private float maxTriggerRotation = 45f;


    void Update ()
    {
        controller = controllerRight.GetComponent<Trigger>();
        controller.triggerAxis += triggerPressed;
        controller = controllerLeft.GetComponent<Trigger>();
        controller.triggerAxis += triggerPressed;
        Debug.Log("TriggerPressed = " + triggerPressed);

    }
}
