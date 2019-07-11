using UnityEngine;

public class PointTrigger : MonoBehaviour
{
    public GameObject CheckPoint01;
    public GameObject CheckPoint02;
    public GameObject CheckPoint03;
    public GameObject CheckPoint04;
    public GameObject CheckPoint05;
    public GameObject CheckPoint06;

    void OnTriggerEnter()
    {
        CheckPoint01.SetActive(true);
        CheckPoint02.SetActive(false);
        CheckPoint03.SetActive(false);
        CheckPoint04.SetActive(false);
        CheckPoint05.SetActive(false);
        CheckPoint06.SetActive(false);


    }
}
