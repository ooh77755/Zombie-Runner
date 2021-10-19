using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target;
    [SerializeField] float enemyDamage = 40f;
    
    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
    }
    
    public void AttackHitEvent()
    {
        if (target == null)
        {
            return;
        }
        target.ReceiveDamage(enemyDamage);
        Debug.Log("Enemy hits Player");
    }
}
