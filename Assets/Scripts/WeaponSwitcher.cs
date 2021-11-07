using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] int currentWeapon = 0;
    //[SerializeField] WeaponZoom weaponZoom;

    void Start()
    {
        SetActiveWeapon();
    }

    void Update()
    {
        int previousWeapon = currentWeapon;

        ProcessKeyInput();
        ProcessScrollWheel();

        if (previousWeapon != currentWeapon)
        {
            SetActiveWeapon();
        }
    }

    private void ProcessKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeapon = 0;
        }

        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWeapon = 1;
        }

        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentWeapon = 2;
        }
    }

    private void ProcessScrollWheel()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            //i.e. if currentWeapon is >= 2 (No. of weapons in index)
            if (currentWeapon >= transform.childCount - 1)
            {
                currentWeapon = 0;
            }

            else
            {
                currentWeapon++;
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (currentWeapon <= 0)
            {
                //i.e. assign currentWeapon to 2
                currentWeapon = transform.childCount - 1;
            }

            else
            {
                currentWeapon--;
            }
        }
    }

    private void SetActiveWeapon()
    {
        int weaponIndex = 0;

        foreach (Transform weapon in transform)
        {
            if (weaponIndex == currentWeapon)
            {
                weapon.gameObject.SetActive(true);
            }

            else if (weaponIndex != currentWeapon)
            {
                weapon.gameObject.SetActive(false);
            }
            weaponIndex++;
        }
    }
}
