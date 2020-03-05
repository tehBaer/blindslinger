using UnityEngine;
using System.Collections;

public class ShootableBubble : MonoBehaviour
{

    [Header("Unity Setup")]
    public ParticleSystem deathParticles;

    public GameObject SpawnController;

    //The bubble's current health point total
    [HideInInspector] public int currentHealth = 1;

    public void Damage(int damageAmount)
    {
        //subtract damage amount when Damage function is called
        currentHealth -= damageAmount;

        //Check if health has fallen below zero
        if (currentHealth <= 0)
        {
            //if health has fallen below zero, deactivate it 
            //gameObject.SetActive (false);
			Destroy();
        }        
    }

	public void Destroy()
        {
			Instantiate(deathParticles, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
}
