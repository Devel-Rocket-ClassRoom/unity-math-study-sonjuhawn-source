using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector3 p0, p1, p2, p3;

    float t = 0;
    public float duration = 2f;

    public void Init(Vector3 start, Vector3 c1, Vector3 c2, Vector3 end)
    {
        p0 = start;
        p1 = c1;
        p2 = c2;
        p3 = end;
    }

    void Update()
    {
        t += Time.deltaTime / duration;
        t = Mathf.Clamp01(t);

        transform.position = CubicBezier(p0, p1, p2, p3, t);

        // 도착하면 삭제
        if (t >= 1f)
        {
            Destroy(gameObject);
        }
    }

    Vector3 CubicBezier(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {
        Vector3 a = Vector3.Lerp(p0, p1, t);
        Vector3 b = Vector3.Lerp(p1, p2, t);
        Vector3 c = Vector3.Lerp(p2, p3, t);

        Vector3 d = Vector3.Lerp(a, b, t);
        Vector3 e = Vector3.Lerp(b, c, t);

        return Vector3.Lerp(d, e, t);
    }
}