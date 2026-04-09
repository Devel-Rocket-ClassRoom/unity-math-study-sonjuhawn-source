using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject target;
    public GameObject bulletPrefab;
    public int bulletCount = 20;

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Shoot();
        }
        
    }

    void Shoot()
    {
        for (int i = 0; i < bulletCount; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            Bullet bulletScript = bullet.GetComponent<Bullet>();

            Vector3 halfPos = (transform.position + target.transform.position) * 0.5f;
            float halfDistance = Vector3.Distance(transform.position, target.transform.position) / 2;

            Vector3 randomPos1 = halfPos + Random.insideUnitSphere * halfDistance;
            Vector3 randomPos2 = halfPos + Random.insideUnitSphere * halfDistance;

            bulletScript.Init(
                transform.position,
                randomPos1,
                randomPos2,
                target.transform.position
            );
        }
    }
}