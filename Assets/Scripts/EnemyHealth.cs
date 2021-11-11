using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float enemyHP = 200f;

    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken");
        enemyHP -= damage;

        if(enemyHP <= 0)
        {
            GetComponent<Animator>().SetTrigger("Die");
            //Destroy(gameObject);
        }
    }
}
