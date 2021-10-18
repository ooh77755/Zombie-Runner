﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;

    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    bool isAggro = false;
    
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    
    void Update()
    {
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

    private void EngageTarget()
    {
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1f, 1f, 0f, 0.5f);
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

}
