using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject target;
    public GameObject bulletPrefap;
    public int bulletcount = 20;
    public float currentDuration;
    public float t = 0;

    private Vector3 p1;
    private Vector3 p2;
    private Vector3 halfPos;

    float halfDistance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = GetComponent<GameObject>();
        bulletPrefap = GetComponent<GameObject>();
        halfDistance = Vector3.Distance(transform.position, target.transform.position)/2;
        halfPos = (transform.position + target.transform.position) * 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < bulletcount; i++)
        {
            Vector3 randomPos1 = halfPos + Random.insideUnitSphere * halfDistance;
            Vector3 randomPos2 = halfPos + Random.insideUnitSphere * halfDistance;
            float randomDistance1 = Vector3.Distance(randomPos1, transform.position);
            float randomDistance2 = Vector3.Distance(randomPos2, transform.position);
            if (randomDistance1 < randomDistance2)
            {
                transform.position = CubicBezier(transform.position, randomPos1, randomPos2, );
            }
        }
    }

    Vector3 CubicBezier(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {
        // de Casteljau 알고리즘 — 3단계 Lerp
        Vector3 a = Vector3.Lerp(p0, p1, t);
        Vector3 b = Vector3.Lerp(p1, p2, t);
        Vector3 c = Vector3.Lerp(p2, p3, t);

        Vector3 d = Vector3.Lerp(a, b, t);
        Vector3 e = Vector3.Lerp(b, c, t);

        return Vector3.Lerp(d, e, t);
    }
}
