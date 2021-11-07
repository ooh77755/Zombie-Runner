using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlots;

    [System.Serializable]
    private class AmmoSlot
    {
        public AmmoType ammoType;
        public int ammoAmount;
    }

    public int GetCurrentAmmo(AmmoType ammoTypeHere)
    {
        return GetAmmoSlot(ammoTypeHere).ammoAmount;
    }

    public void IncreaseCurrentAmmo(AmmoType ammoTypeHere, int ammoAmountHere)
    {
        GetAmmoSlot(ammoTypeHere).ammoAmount += ammoAmountHere;
    }

    public void ReduceCurrentAmmo(AmmoType ammoTypeHere)
    {
        GetAmmoSlot(ammoTypeHere).ammoAmount--;
    }

    private AmmoSlot GetAmmoSlot(AmmoType ammoTypeHere)
    {
        foreach (AmmoSlot ammoSlot in ammoSlots)
        {
            if (ammoSlot.ammoType == ammoTypeHere)
            {
                return ammoSlot;
            }
        }
        return null;
    }
}
