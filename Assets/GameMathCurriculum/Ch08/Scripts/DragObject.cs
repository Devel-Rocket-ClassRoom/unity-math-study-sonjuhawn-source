using UnityEngine;

public class DragObject : MonoBehaviour
{
    public bool isReturning;
    public float timeReturn = 2f;
    public Vector3 originalPosition;
    private Vector3 startPosition;

    private Terrain terrain;
    private float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        terrain = Terrain.activeTerrain;
    }

    // Update is called once per frame
    void Update()
    {
        if (isReturning)
        {
            timer += Time.deltaTime / timeReturn;
            Vector3 newPos = Vector3.Lerp(startPosition, originalPosition, timer);
            newPos.y = terrain.SampleHeight(newPos) + 0.5f;
            transform.position = newPos;

            if (timer > 1f)
            {
                isReturning = false;
                transform.position = originalPosition;
                timer = 0f;

            }
        }
    }

    public void Return()
    {
        timer = 0f;
        isReturning = true;
        startPosition = transform.position;
    }

    public void DragStart()
    {
        timer = 0f;
        isReturning = false;
        timer = 0f;
        startPosition = Vector3.zero;
        originalPosition = transform.position;


    }
    public void DragEnd()
    {
        isReturning = false;
        timer = 0f;
        originalPosition = Vector3.zero;
        startPosition = Vector3.zero;
    }
}
