using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    float zoomedInFOV = 20f;
    float zoomedOutFOV = 60f;

    bool zoomedInToggle = false;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            if(zoomedInToggle == false)
            {
                zoomedInToggle = true;
                mainCamera.fieldOfView = zoomedInFOV;
            }

            else
            {
                zoomedInToggle = false;
                mainCamera.fieldOfView = zoomedOutFOV;
            }
        }
    }
}
