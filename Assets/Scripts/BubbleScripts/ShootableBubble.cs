using UnityEngine;
using System.Collections;

public class ShootableBubble : MonoBehaviour
{
    [Header("Unity Setup")]
    public ParticleSystem deathParticles;

    public GameObject SpawnController;

    [HideInInspector] public int currentHealth = 1;

    public void Damage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
			Destroy();
        }        
    }
	public void Destroy()
        {
			Instantiate(deathParticles, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
}
