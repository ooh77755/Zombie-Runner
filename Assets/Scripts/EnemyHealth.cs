using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float enemyHP = 200f;

    bool isDead = false;

    public bool IsDead()
    {
        return isDead;
    }

    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken");
        enemyHP -= damage;

        if(enemyHP <= 0)
        {
            if(isDead)
            {
                return;
            }
            isDead = true;
            GetComponent<Animator>().SetTrigger("Die");
        }
    }
}
