﻿using UnityEngine;
using System.Collections;

public class BubbleManager : MonoBehaviour
{
    public GameObject Bubble;                // The enemy prefab to be spawned
    public float spawnTime = 7f;            // Time between spawns
    public GameObject RotatingSpawner;      // The sphere that the spawn point(s) are connected to
    public bool BubbleMovement;             // Enables movement in BubbleTrajectory.cs
    public Transform[] spawnPoints;         // TODO: Make single SpawnPoint

    void Start()
    {
        // Reset values of parameters and enable them
        ResetParameters();

        // Make the first bubble silent and stationary
        Bubble.GetComponent<AudioSource>().mute = true;
        Bubble.GetComponent<BubbleTrajectory>().enabled = false;
        RotatingSpawner.GetComponent<LineRenderer>().enabled = false; // Is immediatly re-enabled
        Instantiate(Bubble, new Vector3(3, 3, 3), new Quaternion(0, 0, 0, 0));

        // Unmute, enable movement and show trajectory for the following Bubbles
        Bubble.GetComponent<AudioSource>().mute = false;
        Bubble.GetComponent<BubbleTrajectory>().enabled = true;
        RotatingSpawner.GetComponent<LineRenderer>().enabled = true;

        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void ResetParameters(){
        Color col = Bubble.GetComponent<Renderer>().sharedMaterial.color;
        col.a = 1f;
        Bubble.GetComponent<Renderer>().sharedMaterial.color = col;
        Bubble.GetComponent<Renderer>().enabled = true;
        Bubble.GetComponent<Light>().intensity = 1f;
        Bubble.GetComponent<Light>().enabled = true;
        RotatingSpawner.GetComponent<LineRenderer>().enabled = true;
    }

    void DecreaseParameters(){
        
        // Reduce the opacity of the Bubble
        Color col = Bubble.GetComponent<Renderer>().sharedMaterial.color;
        col.a -= 0.2f;
        Bubble.GetComponent<Renderer>().sharedMaterial.color = col;

        // Reduce the intensity of the Bubble's light
        Bubble.GetComponent<Light>().intensity -= 0.2f;

        // Turn off rendering and light if its less than 10% visible
        if (col.a < 0.1f)
        {
            Bubble.GetComponent<Renderer>().enabled = false;
            Bubble.GetComponent<Light>().enabled = false;
            RotatingSpawner.GetComponent<LineRenderer>().enabled = false;
        }
    }
    public void Spawn()
    {
        // Check to see if there are no Bubbles in play
        if (GameObject.Find("Bubble(Clone)") == null)
        {
            // Change the direction of the rotation
            RotatingSpawner.GetComponent<RandomRotation>().RotateAxis();

            // Reduce the transparancy/light of the Bubble to be spawned
            DecreaseParameters();

            // Create an instance of the enemy prefab at the spawn point's position and rotation.
            Instantiate(Bubble, spawnPoints[0].position, spawnPoints[0].rotation);
        }
    }
}