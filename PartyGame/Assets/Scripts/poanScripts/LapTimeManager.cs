using UnityEngine;
using UnityEngine.UI;


public class LapTimeManager : MonoBehaviour
{
    public static int MinuteCount;
    public static int SecondCount;
    public static float MilliCount;

    public GameObject TimeText;

    private void Update()
    {
        MilliCount += Time.deltaTime * 10;
        TimeText.GetComponent<Text>().text = MinuteCount.ToString("0") + ": " + SecondCount.ToString("00")+ ": " + MilliCount.ToString("0.0");
        //毫秒為10進秒
        if (MilliCount >= 10)
        {
            MilliCount = 0;
            SecondCount += 1;
        }
        //秒為60進分
        if (SecondCount >= 60)
        {
            SecondCount = 0;
            MinuteCount += 1;
        }

    }
}
