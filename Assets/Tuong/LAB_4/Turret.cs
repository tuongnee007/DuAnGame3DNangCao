using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform firepoint;
    public float fireRate = 1f;
    private float nextFireTime;
    private void Update()
    {
        if(Time.time >= nextFireTime)
        {
            HealthEnemy target = FindNearestEnemy();
            if(target != null )
            {
                Shoot(target);
                nextFireTime = Time.time + fireRate;
            }
        }
    }
    HealthEnemy FindNearestEnemy()
    {
        HealthEnemy[] enemies = FindObjectsOfType<HealthEnemy>(); 
        HealthEnemy nearestEnemy = null;
        float shortestDistance = Mathf.Infinity;

        foreach( HealthEnemy enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if(distance < shortestDistance)
            {
                shortestDistance = distance;
                nearestEnemy = enemy;
            }
        }
        return nearestEnemy;
    }
    void Shoot(HealthEnemy target)
    {
        GameObject bullet = ObjectPool.Instance.GetBullet();
        bullet.transform.position = firepoint.position;
        bullet.transform.rotation = firepoint.rotation;

        Bullet bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.SetTarget(target);
    }
}
