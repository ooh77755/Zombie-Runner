using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float enemyDamage = 40f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public void AttackHitEvent()
    {
        PlayerHealth targetPH = FindObjectOfType<PlayerHealth>();
        if (target == null)
        {
            return;
        }
        targetPH.ReceiveDamage(enemyDamage);
        Debug.Log("Enemy hits Player");
    }
}
