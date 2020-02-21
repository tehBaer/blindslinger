using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleTrajectory : MonoBehaviour
{

    [HideInInspector] public GameObject SpawnPoint;
    [HideInInspector] public GameObject SpawnController;


    void Start()
    {
        SpawnPoint = GameObject.Find("MidSpawnPoint");
        SpawnController = GameObject.Find("SpawnController");
    }

    // Update is called once per frame
    void Update()
    {
        if (SpawnController.GetComponent<BubbleManager>().BubbleMovement == true){
            gameObject.transform.position = SpawnPoint.transform.position;
        }

    }

}
