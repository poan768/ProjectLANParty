using UnityEngine;

public class PlayerCtrl : MonoBehaviour
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

    [Header("角色旋轉參數")]
    public float RotForward = 2.5f;//前進時遞減旋轉角度
    public float RotFriction = .3f;//滑行時遞減旋轉角度
    public float RotBreak = 4.2f;//按下S剎車時增加旋轉角度

    void Start()
    {
        //初始化
        Speed_copy = Speed;
        RotationSpeed_copy = RotationSpeed;
        Speed = 0;
    }
    
    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        PlayerMove();//角色移動
        PlayerRotation();//腳色旋轉
    }

    /// <summary>
    /// 轉動控制
    /// </summary>
    #region PlayerRotation
    private void PlayerRotation()
    {
        if (Input.GetKey("a") && Speed > .8f)
        {
            transform.Rotate(0, -RotationSpeed * Time.deltaTime, 0);
        }
        
        if (Input.GetKey("d") && Speed > .8f)
        {
            transform.Rotate(0, RotationSpeed * Time.deltaTime, 0);
        }
        ///待修改
        #region 旋轉因速度快而旋轉角度變小
        if (Input.GetKey("w"))
        {
            if (RotationSpeed >= 5) RotationSpeed -= RotForward * Time.deltaTime;
        }
        else
        {
            if (RotationSpeed <= RotationSpeed_copy) RotationSpeed += RotFriction * Time.deltaTime;
        }
        if (Input.GetKey("s"))
        {
            if (RotationSpeed <= RotationSpeed_copy) RotationSpeed += RotBreak * Time.deltaTime;
        }
        #endregion
    }
    #endregion

    /// <summary>
    /// 移動控制
    /// </summary>
    #region PlayerMove
    private void PlayerMove()
    {
        if (Input.GetKey("w"))
        {
            //還在後退時按下W剎車更快
            if (Speed <= 0) Speed += BreakSpeed * Time.deltaTime;
            else
            {
                //transform.Translate(Vector3.forward * Speed * Time.deltaTime);
                this.GetComponent<Rigidbody>().MovePosition(transform.position + transform.forward * Speed * Time.deltaTime);
            }
            //移動
            Speed += Speed_copy * Time.deltaTime;
        }
        else if (Speed > 0)
        {
            Break(true);
        }

        if (Input.GetKey("s"))
        {
            //還在前進時按下S剎車更快
            if (Speed >= 0) Speed -= BreakSpeed * Time.deltaTime;
            else
            {
                Break(false);
                //transform.Translate(Vector3.forward * Speed * Time.deltaTime);
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
        //transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        this.GetComponent<Rigidbody>().MovePosition(transform.position + transform.forward * Speed * Time.deltaTime);

        if (Direction == true) Speed -= Friction * Time.deltaTime;
        else Speed += Friction * Time.deltaTime;
    }
    #endregion
}
