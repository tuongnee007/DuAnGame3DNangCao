using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;
    public GameObject bulletPrefab;
    public int amountToPool = 10;
    private Queue<GameObject> bulletPool = new Queue<GameObject>();
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        for(int i = 0;i < amountToPool; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            bulletPool.Enqueue(bullet);
        }
    }
    public GameObject GetBullet()
    {
        if(bulletPool.Count > 0)
        {
            GameObject bullet = bulletPool.Dequeue();
            bullet.SetActive(true);
            return bullet;
        }
        else
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(true);
            bulletPool.Enqueue(bullet);
            return bullet;
        }
    }
    public void ReturnBullet(GameObject bullet)
    {
        bullet.SetActive(false);
        bulletPool.Enqueue(bullet);
    }
}
