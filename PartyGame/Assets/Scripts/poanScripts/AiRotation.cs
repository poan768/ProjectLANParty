using UnityEngine;

public enum Touch
{
    Left = -1, Right = 1
}

public class AiRotation : MonoBehaviour
{
    public Touch touch = Touch.Left;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "LeftWall" || other.tag == "RightWall")
        {
            switch (touch)
            {
                case Touch.Left:
                    //transform.Translate((int)touch, 0,0);
                    gameObject.transform.parent.gameObject.transform.Rotate(0, 25 * Time.deltaTime, 0);
                    //print("Left");
                    break;
                case Touch.Right:
                    gameObject.transform.parent.gameObject.transform.Rotate(0, -25 * Time.deltaTime, 0);
                    //print("Right");
                    break;
            }
        }
    }
}
