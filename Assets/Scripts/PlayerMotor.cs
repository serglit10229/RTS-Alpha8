﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/* This component moves our player using a NavMeshAgent. */

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour
{
    public GameObject thisUnit;
    Transform target;       // Target to follow
    NavMeshAgent agent;     // Reference to our agent
    public float radiusMult = 0.8f;
    public float rotationSpeed = 5.0f;
    public float attackRange = 0.0f;
    public bool badUnit = false;

    public GameObject dirObj;

    // Get references
    void Start()
    {
        agent = thisUnit.GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // If we have a target
        if (target != null)
        {
            // Move towards it and look at it
            agent.SetDestination(target.position);
            FaceTarget();
        }

        if(gameObject.GetComponentInChildren<Attack>().enemyDetected == true)
        {
            FaceTarget();
        }
    }

    public void MoveToPoint(Vector3 point)
    {
        agent.SetDestination(point);
    }

    // Start following a target
    public void FollowTarget(Interactables newTarget)
    {
        agent.stoppingDistance = newTarget.radius * radiusMult;
        agent.updateRotation = false;

        target = newTarget.interationTransform;
    }

    // Stop following a target
    public void StopFollowingTarget()
    {
        agent.stoppingDistance = 0f;
        agent.updateRotation = true;

        target = null;
    }

    // Make sure to look at the target
    void FaceTarget()
    {
        Vector3 direction = (target.position - dirObj.transform.position).normalized;
        Quaternion lookRotation = new Quaternion();
        if (badUnit == true)
        {
            lookRotation = Quaternion.LookRotation(new Vector3(0f, direction.z, direction.x));
        }
        else
        {
            lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        }
        dirObj.transform.rotation = Quaternion.Slerp(dirObj.transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }

}