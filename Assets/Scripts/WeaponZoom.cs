using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] RigidbodyFirstPersonController rbScript;
    float zoomedInFOV = 20f;
    float zoomedOutFOV = 60f;
    float ZoomOut = 2f;
    float ZoomIn = 0.5f;

    bool zoomedInToggle = false;

    //WeaponZoom scripts get disabled each time player toggles weapon that isn't carbine
    private void OnDisable()
    {
        ZoomOutMethod();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            if(zoomedInToggle == false)
            {
                ZoomInMethod();
            }

            else
            {
                ZoomOutMethod();
            }
        }
    }

    private void ZoomInMethod()
    {
        zoomedInToggle = true;
        mainCamera.fieldOfView = zoomedInFOV;
        rbScript.mouseLook.XSensitivity = ZoomIn;
        rbScript.mouseLook.YSensitivity = ZoomIn;
    }

    private void ZoomOutMethod()
    {
        zoomedInToggle = false;
        mainCamera.fieldOfView = zoomedOutFOV;
        rbScript.mouseLook.XSensitivity = ZoomOut;
        rbScript.mouseLook.YSensitivity = ZoomOut;
    }

}
