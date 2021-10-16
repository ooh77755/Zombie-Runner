using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera playerCamera;
    [SerializeField] float raycastRange = 100f;
    float damage = 100f;

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, raycastRange))
        {
            Debug.Log("I hit this thing: " + hit.transform.name);
            //TODO: add hit effect
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target==null)
            {
                return;
            }
            target.TakeDamage(damage); 
        }

        else
        {
            return;
        }
    }
}
