using UnityEngine;
using UnityEngine.UI;

public class IndicatorController : MonoBehaviour

{
    Camera cam;
    public GameObject[] cubes;
    public Image[] indicators;

    Vector3 cubePosInScreen;
    Vector3 cubePosInView;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = FindAnyObjectByType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < cubes.Length; i++)
        {
            cubePosInScreen = cam.WorldToScreenPoint(cubes[i].transform.position);
            cubePosInView = cam.ScreenToViewportPoint(cubePosInScreen);

            if (cubePosInView.x >= 0f && cubePosInView.x <= 1f &&
                cubePosInView.y >= 0f && cubePosInView.y <= 1f &&
                cubePosInView.z > 0f)
            {
                cubes[i].SetActive(true);
                indicators[i].enabled = false;

            }
            else
            {
                cubes[i].SetActive(false);
                indicators[i].enabled = true;

                indicators[i].rectTransform.position = cubePosInScreen;

            }
        }
    }
}
