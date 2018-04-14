using UnityEngine;
using System.Collections;
using EZEffects;
using VRTK;

public class Shooting : MonoBehaviour
{
    
    public GameObject controllerRight;
    public VRTK_InteractableObject interactableObject;
    private SteamVR_TrackedObject trackedObj;
    private SteamVR_Controller.Device device;

    private SteamVR_TrackedController controller;

    public EffectTracer TracerEffect;
    public Transform muzzleTransform;

    void Start()
    {
        
        controller = controllerRight.GetComponent<SteamVR_TrackedController>();
        controller.TriggerClicked += TriggerPressed;
        trackedObj = controllerRight.GetComponent<SteamVR_TrackedObject>();
    }

    private void TriggerPressed(object sender, ClickedEventArgs e)
    {
        
        if (interactableObject.enabled == true)
        ShootWeapon();
    }

    public void ShootWeapon()
    {
        RaycastHit hit = new RaycastHit();
        Ray ray = new Ray(muzzleTransform.position, muzzleTransform.forward);

        device = SteamVR_Controller.Input((int)trackedObj.index);
        device.TriggerHapticPulse(750);
        TracerEffect.ShowTracerEffect(muzzleTransform.position, muzzleTransform.forward, 250f);

        if (Physics.Raycast(ray, out hit, 5000f))
        {
            if (hit.collider.attachedRigidbody)
            {
                Debug.Log("We've hit" + hit.collider.gameObject.name);
            }
        }
    }

}
