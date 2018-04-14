using System.Collections;
using UnityEngine;
using VRTK;
using VRTK.GrabAttachMechanics;

public class Flashlight : MonoBehaviour
{
    public VRTK_InteractableObject interactableObject;
    public VRTK_FixedJointGrabAttach fixedJoint;
    public Light flashLight;
    public Transform snapHandle;
    private bool isActive;
    private bool isForward;
    private SteamVR_TrackedObject trackedObj;
    private SteamVR_Controller.Device device;
    public GameObject controllerRight;
    private SteamVR_TrackedController controller;
    // Use this for initialization
    void Start()
    {
        isActive = true;
        isForward = true;
        controller = controllerRight.GetComponent<SteamVR_TrackedController>();
        controller.TriggerClicked += TriggerPressed;
        controller.MenuButtonClicked += MenuPressed;
        trackedObj = controllerRight.GetComponent<SteamVR_TrackedObject>();
    }

    private void TriggerPressed(object sender, ClickedEventArgs e)
    {
        if (interactableObject.enabled == true)
            TurnOff();
    }

    private void MenuPressed(object sender, ClickedEventArgs e)
    {
        if (interactableObject.enabled == true)
            ChangeRotation();
    }

    public void TurnOff()
    {
        if (isActive == false)
        {
            flashLight.enabled = true;
            isActive = true;
        }
        else if (isActive == true)
        {
            flashLight.enabled = false;
            isActive = false;
        }
    }

    public void ChangeRotation()
    {
        if (isForward == false)
        {
            fixedJoint.rightSnapHandle.GetComponent<Transform>().eulerAngles = new Vector3(0, 0, 0);
            fixedJoint.leftSnapHandle.GetComponent<Transform>().eulerAngles = new Vector3(0, 0, 0);
            isForward = true;
        }
        else if (isForward == true);
        {
            fixedJoint.rightSnapHandle.GetComponent<Transform>().eulerAngles = new Vector3(180, 0, 0);
            fixedJoint.leftSnapHandle.GetComponent<Transform>().eulerAngles = new Vector3(180, 0, 0);
            isForward = false;
        }
    }

}



