using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float enemyHP = 100f;

    public void TakeDamage(float damage)
    {
        enemyHP -= damage;

        if(enemyHP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
