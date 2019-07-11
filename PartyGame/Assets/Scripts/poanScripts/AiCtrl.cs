using UnityEngine;

public class AiCtrl : MonoBehaviour
{
    [Header("角色移動速度")]
    public float Speed = 40;//角色移動速度
    private float Speed_copy;//角色移動速度還原值

    [Header("角色摩擦力")]
    public float Friction = 5;//角色摩擦力

    [Header("剎車靈敏度度")]
    public float BreakSpeed = 30;//剎車靈敏度

    [Header("角色旋轉速度")]
    public float RotationSpeed = 40;//角色旋轉速度
    private float RotationSpeed_copy;//角色旋轉速度還原值

    private bool SpeedCtrl = false;
    private void Start()
    {
        //初始化
        Speed_copy = Speed;
        RotationSpeed_copy = RotationSpeed;
        Speed = 0;
    }

    void Update()
    {
        //往前打雷射
        RaycastHit hit;
        Ray downRay = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(downRay, out hit))
        {
            Debug.DrawLine(transform.position, hit.transform.position, Color.red, .1f);
            if (hit.collider.gameObject.tag == "SlowDown")
            {
                float distance = hit.point.z - this.transform.position.z;
                //Debug.Log(distance);
                if(hit.point.z - this.transform.position.z <= 50 && hit.point.z - this.transform.position.z >= 10)
                {
                    if(Speed > 15)SpeedCtrl = true;
                    else SpeedCtrl = false;
                }
                else
                {
                    SpeedCtrl = false;
                }
            }
        }
        //油門控制
        if (SpeedCtrl == true)
        {
            PlayerMove("Back");
            print("true");
        }
        else if (SpeedCtrl == false)
        {
            PlayerMove("Foward");
            //print("false");
        }
    }


    /// <summary>
    /// 移動控制
    /// </summary>
    #region PlayerMove
    private void PlayerMove(string Direction)
    {
        if (Direction == "Foward")
        {
            //還在後退時按下W剎車更快
            if (Speed <= 0) Speed += BreakSpeed * Time.deltaTime;
            else
            {
                this.GetComponent<Rigidbody>().MovePosition(transform.position + transform.forward * Speed * Time.deltaTime);
            }
            //移動
            Speed += Speed_copy * Time.deltaTime;
        }
        else if (Speed > 0)
        {
            Break(true);
        }

        if (Direction == "Back")
        {
            //還在前進時按下S剎車更快
            if (Speed >= 0) Speed -= BreakSpeed * Time.deltaTime;
            else
            {
                Break(false);
                this.GetComponent<Rigidbody>().MovePosition(transform.position + transform.forward * Speed * Time.deltaTime);
            }
            //移動
            Speed -= Speed_copy * Time.deltaTime;
        }
        else if (Speed < 0) Break(false);
    }
    #endregion

    /// <summary>
    /// 移動中放開按鈕剎車停止
    /// </summary>
    /// <param name="Direction">True往前，False往後</param>
    #region Friction
    private void Break(bool Direction)
    {
        this.GetComponent<Rigidbody>().MovePosition(transform.position + transform.forward * Speed * Time.deltaTime);

        if (Direction == true) Speed -= Friction * Time.deltaTime;
        else Speed += Friction * Time.deltaTime;
    }
    #endregion
}
