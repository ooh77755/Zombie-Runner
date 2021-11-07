using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] int pickupAmount = 10;
    [SerializeField] AmmoType ammoType;
    Ammo ammo;

    private void Start()
    {
        ammo = FindObjectOfType<Ammo>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            ammo.IncreaseCurrentAmmo(ammoType, pickupAmount);
            Destroy(gameObject);
        }
    }

    public int GetPickUpAmount()
    {
        return pickupAmount;
    }
}
