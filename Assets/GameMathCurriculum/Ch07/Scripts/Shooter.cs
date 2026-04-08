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
            // 총알 생성
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            // Bullet 스크립트 가져오기
            Bullet bulletScript = bullet.GetComponent<Bullet>();

            // 베지어용 랜덤 컨트롤 포인트 생성
            Vector3 halfPos = (transform.position + target.transform.position) * 0.5f;
            float halfDistance = Vector3.Distance(transform.position, target.transform.position) / 2;

            Vector3 randomPos1 = halfPos + Random.insideUnitSphere * halfDistance;
            Vector3 randomPos2 = halfPos + Random.insideUnitSphere * halfDistance;

            // Bullet 초기화
            bulletScript.Init(
                transform.position,
                randomPos1,
                randomPos2,
                target.transform.position
            );
        }
    }
}