using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HealthEnemy : MonoBehaviour
{
    public float health = 100f;
    private NavMeshAgent agent;
    public AudioSource audioSource;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        audioSource.Stop();
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        audioSource.Play();
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }   
}
