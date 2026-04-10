using UnityEngine;
using UnityEngine.UI;

public class IndicatorController : MonoBehaviour

{
    Camera cam;
    public GameObject[] cubes;
    public Image[] indicators;
    public float margin = 50f;

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
                indicators[i].enabled = false;

            }
            else
            {
                Vector3 local = cam.transform.InverseTransformPoint(cubes[i].transform.position);
                Vector2 dir = new Vector2(local.x, local.y).normalized;
                Vector2 center = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);
                float scale = Mathf.Min(center.x / Mathf.Abs(dir.x), center.y / Mathf.Abs(dir.y));
                Vector2 pos = center + dir * scale;
                indicators[i].transform.position = new Vector3(pos.x, pos.y, 0);
                indicators[i].enabled = true;


                //indicators[i].enabled = true;

                //float centerX = Screen.width / 2f;
                //float centerY = Screen.height / 2f;

                //float ClampIndicatorsX;
                //float ClampIndicatorsY;

                //// 중심 기준 반전
                //if (cubePosInView.z < 0)
                //{
                //    float reversedX = centerX + (centerX - cubePosInScreen.x);
                //    float reversedY = centerY + (centerY - cubePosInScreen.y);

                //    ClampIndicatorsX = Mathf.Clamp(reversedX, margin, Screen.width - margin);
                //    ClampIndicatorsY = Mathf.Clamp(reversedY, margin, Screen.height - margin);
                //}
                //else
                //{
                //    ClampIndicatorsX = Mathf.Clamp(cubePosInScreen.x, margin, Screen.width - margin);
                //    ClampIndicatorsY = Mathf.Clamp(cubePosInScreen.y, margin, Screen.height - margin);
                //}


                //indicators[i].rectTransform.position = new Vector3(ClampIndicatorsX, ClampIndicatorsY, 0f);

            }
        }
    }
}
