using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float playerHP = 100f;

    public void ReceiveDamage(float enemyDamage)
    {
        playerHP -= enemyDamage;

        if(playerHP <= 0)
        {
            Debug.Log("Player is dead");
        }
    }
}
