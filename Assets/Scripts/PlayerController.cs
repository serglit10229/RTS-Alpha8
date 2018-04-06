﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Controls the player. Here we choose our "focus" and where to move. */

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{

    public Interactables focus;  // Our current focus: Item, Enemy etc.
    public bool selected = false;
    public LayerMask movementMask;  // Filter out everything not walkable
    public Transform lastPosition;

    public bool army = false;
    public Vector3 armyMid;

    public Vector3 dest;

    public GameObject thisUnit;

    Camera cam;         // Reference to our camera
    PlayerMotor motor;  // Reference to our motor

    // Get references
    void Start()
    {
        cam = Camera.main;
        motor = thisUnit.GetComponent<PlayerMotor>();
        InvokeRepeating("lastPos", 1,1);
    }

    void lastPos()
    {
        lastPosition = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (selected == true)
        {
            // If we press left mouse
            if (Input.GetMouseButtonDown(1))
            {
                // We create a ray
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                // If the ray hits
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, movementMask))
                {
                    dest = hit.point;
                    if (army == true)
                    {
                        //armyMid = Vector3.zero;
                        motor.MoveToPoint(transform.position + (dest - armyMid));  // Move to where we hit
                        RemoveFocus();
                    }
                    else
                    {
                        armyMid = Vector3.zero;
                        motor.MoveToPoint(hit.point);   // Move to where we hit
                        RemoveFocus();
                    }


                }
            }

            // If we press right mouse
            if (Input.GetMouseButtonDown(1))
            {
                // We create a ray
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                // If the ray hits
                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    Interactables interactable = hit.collider.GetComponent<Interactables>();
                    if (interactable != null)
                    {
                        SetFocus(interactable);
                    }
                }
            }
        }
    }

    // Set our focus to a new focus
    void SetFocus(Interactables newFocus)
    {
        // If our focus has changed
        if (newFocus != focus)
        {
            // Defocus the old one
            if (focus != null)
                focus.OnDefocused();

            focus = newFocus;   // Set our new focus
            motor.FollowTarget(newFocus);   // Follow the new focus
        }

        newFocus.OnFocused(transform);
    }

    // Remove our current focus
    void RemoveFocus()
    {
        if (focus != null)
            focus.OnDefocused();

        focus = null;
        motor.StopFollowingTarget();
    }

    void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, dest);
    }
}