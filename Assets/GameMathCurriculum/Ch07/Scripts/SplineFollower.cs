using UnityEngine;
using Unity.Mathematics;
using UnityEngine.Splines;

public class SplineFollower : MonoBehaviour
{
    public Transform mover;
    public float duration;
    private SplineContainer splineContainer;
    private float t;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        splineContainer = GetComponent<SplineContainer>();
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime / duration;
        t = Mathf.Repeat(t, 1f);

        if(!splineContainer.Evaluate(splineContainer.Spline, t,
            out float3 position, out float3 tan, out float3 up))
        {
            return;
        }
        mover.position = position;
        if(math.length(tan) > 0.00f)
        {
            mover.rotation = quaternion.LookRotation(tan, up);
        }
        
    }
}
