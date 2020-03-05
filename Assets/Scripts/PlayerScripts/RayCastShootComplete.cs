﻿
using UnityEngine;
using System.Collections;
using Valve.VR;

public class RayCastShootComplete : MonoBehaviour
{
    [Header("Unity Setup")]
    public float weaponRange = 50f;                                     // Distance in Unity units over which the player can fire
    public int gunDamage = 1;                                           // Set the number of hitpoints that this gun will take away from shot objects with a health script
    public float fireRate = 0.25f;                                      // Number in seconds which controls how often the player can fire
    public Transform gunEnd;                                            // Holds a reference to the gun end object, marking the muzzle location of the gun
    private Camera fpsCam;                                              // Holds a reference to the first person camera
    private WaitForSeconds shotDuration = new WaitForSeconds(0.02f);    // WaitForSeconds object used by our ShotEffect coroutine, determines time laser line will remain visible
    private AudioSource gunAudio;                                       // Reference to the audio source which will play our shooting sound effect
    private LineRenderer laserLine;                                     // Reference to the LineRenderer component which will display our laserline
    public Light bloom1;                                                // Reference to the Light component which will light up parts of the walls

    public Light bloom2;                                                // Reference to the Light component which will light up the area around the bubble 
    private float nextFire;                                             // Float to store the time the player will be allowed to fire again, after firing
    private int shootableMask;                                          // Integer to store the number of the shootable layer
    public SteamVR_Action_Boolean shootaction;                          // Boolean to store the state of the shooting action
    public SteamVR_Input_Sources handType;                              // Stores which controller is used
    public bool triggerbool;                                            // Boolean to store the state of the trigger

    void Start()
    {
        // Get and store a reference to our LineRenderer component
        laserLine = GetComponent<LineRenderer>();

        // Get and store a reference to our AudioSource component
        gunAudio = GetComponent<AudioSource>();

        // Get and store a reference to our Camera by searching this GameObject and its parents
        fpsCam = GetComponentInParent<Camera>();

        // Get and store the layer number that will be shootable
        shootableMask = 1 << 9;

        // Get and store listeners to trigger press and idle triggers
        shootaction.AddOnStateDownListener(TriggerDown, handType);
        shootaction.AddOnStateUpListener(TriggerUp, handType);
    }

    public void TriggerUp(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        triggerbool = false;
    }
    public void TriggerDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        triggerbool = true;
    }

    void Update()
    {
        // Check if the player has pressed the fire button and if enough time has elapsed since they last fired
        if ((Input.GetButtonDown("Fire1") || triggerbool == true) && Time.time > nextFire)
        {
            // Update the time when our player can fire next
            nextFire = Time.time + fireRate;

            // Start our ShotEffect coroutine to turn our laser line on and off
            StartCoroutine(ShotEffect());

            // Create a vector at the center of our camera's viewport
            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));

            // Declare a raycast hit to store information about what our raycast has hit
            RaycastHit hit;

            // Set the start position for our visual effect for our laser to the position of gunEnd
            laserLine.SetPosition(0, gunEnd.position);

            // Chceck if our raycast has hit anything
            if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, weaponRange, shootableMask))
            {
                // Set the end position for our laser line 
                laserLine.SetPosition(1, hit.point);

                // Get a reference to a health script attached to the collider we hit
                ShootableBubble health = hit.collider.GetComponent<ShootableBubble>();

                // If there was a health script attached
                if (health != null)
                {
                    // Call the damage function of that script, passing in our gunDamage variable
                    health.Damage(gunDamage);
                }
            }
            else
            {
                // If we did not hit anything, set the end of the line to a position directly in front of the camera at the distance of weaponRange
                laserLine.SetPosition(1, rayOrigin + (fpsCam.transform.forward * weaponRange));
            }
        }
    }

    private IEnumerator ShotEffect()
    {
        // Play the shooting sound effect
        gunAudio.Play();
        
        // Turn on our line renderer
        laserLine.enabled = true;
        bloom1.enabled = true;
        bloom2.enabled = true;

        //Wait for .07 seconds
        yield return shotDuration;

        // Deactivate our line renderer after waiting
        laserLine.enabled = false;
        bloom1.enabled = false;
        bloom2.enabled = false;

    }
}
