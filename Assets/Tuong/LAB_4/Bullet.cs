using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float damage = 25f;
    private HealthEnemy target;
    public VisualEffect effect;
    public void SetTarget(HealthEnemy newTarget)
    {
        target = newTarget;
    }
    private void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        if(Vector3.Distance(transform.position, target.transform.position) < 0.5f)
        {
            target.TakeDamage(damage);
            VisualEffect explosion = Instantiate(effect,transform.position,Quaternion.identity);
            explosion.transform.parent = null;
         
            Destroy(explosion.gameObject, 0.5f);
            ReturnToPool();
        }
    }
    void ReturnToPool()
    {
        gameObject.SetActive(false);
        ObjectPool.Instance.ReturnBullet(gameObject);
    }
}
