using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float turnSpeed = 5f;

    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    bool isAggro = false;

    EnemyHealth enemyHealth;
    
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        enemyHealth = GetComponent<EnemyHealth>();
    }
    
    void Update()
    {
        //IF statement checks if bool state is true from another script
        if (enemyHealth.IsDead())
        {
            enabled = false;
            navMeshAgent.enabled = false;
        }

        distanceToTarget = Vector3.Distance(target.position, transform.position);

        if(isAggro)
        {
            EngageTarget();
        }

        else if(distanceToTarget <= chaseRange)
        {
            isAggro = true;
          
        }
    }

    public void OnDamageTaken()
    {
        isAggro = true;
    }

    private void EngageTarget()
    {
        RotateToTarget();

        if (distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }

        if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }

    }

    private void AttackTarget()
    {
        GetComponent<Animator>().SetBool("Attack", true);
        Debug.Log("Enemy is attacking");
    }

    private void ChaseTarget()
    {
        GetComponent<Animator>().SetBool("Attack", false);
        GetComponent<Animator>().SetTrigger("Move");
        navMeshAgent.SetDestination(target.position);
    }

    private void RotateToTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1f, 1f, 0f, 0.5f);
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

}
