using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    float zoomedInFOV = 20f;
    float zoomedOutFOV = 60f;
    RigidbodyFirstPersonController rbScript;
    float ZoomOut = 2f;
    float ZoomIn = 0.5f;

    bool zoomedInToggle = false;

    private void Start()
    {
        rbScript = GetComponent<RigidbodyFirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            if(zoomedInToggle == false)
            {
                zoomedInToggle = true;
                mainCamera.fieldOfView = zoomedInFOV;
                rbScript.mouseLook.XSensitivity = ZoomIn;
                rbScript.mouseLook.YSensitivity = ZoomIn;
            }

            else
            {
                zoomedInToggle = false;
                mainCamera.fieldOfView = zoomedOutFOV;
                rbScript.mouseLook.XSensitivity = ZoomOut;
                rbScript.mouseLook.YSensitivity = ZoomOut;
            }
        }
    }
}
