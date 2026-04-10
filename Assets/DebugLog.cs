using System.IO;
using UnityEngine;

public class PathCombineExample : MonoBehaviour
{
    void Start()
    {
        // ❌ 좋지 않음: 플랫폼마다 구분자가 다름
        string badPath = Application.persistentDataPath + "/Save/" + "data.txt";

        // ✅ 좋음: Path.Combine이 플랫폼에 맞는 구분자를 사용
        string goodPath = Path.Combine(Application.persistentDataPath, "Save", "data.txt");

        Debug.Log($"경로: {goodPath}");
    }
}