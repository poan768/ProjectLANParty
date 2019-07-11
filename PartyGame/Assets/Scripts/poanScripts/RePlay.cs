using UnityEngine;

public class RePlay : MonoBehaviour
{
    [Header ("重生點物件")]
    public Transform ReplayPoint;
    [Header("重生秒數")]
    public float time_ = 3;
    private float t_copy;
    void Start()
    {
        //初始化
        t_copy = time_;
    }

    void OnCollisionStay(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Player")
        {
            time_ -= 1 * Time.deltaTime;
            //print(time_);
            if (time_ <= 0)
            {
                //玩家傳回時速度為0
                collisionInfo.collider.GetComponent<PlayerCtrl>().Speed = 0;
                collisionInfo.transform.position = ReplayPoint.position;
                collisionInfo.transform.rotation = ReplayPoint.rotation;
                time_ = t_copy;
            }
        }
    }
}
