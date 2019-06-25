using UnityEngine;
using UnityEngine.Networking;

public class PlayerCtrl : NetworkBehaviour
{
    public float PlayerSpeed;
    public float PlayerRot;
    public GameObject Cam;

    void Start()
    {
        if (!isLocalPlayer)
        {
            this.gameObject.GetComponent<PlayerCtrl>().enabled = false;//非本地玩家關閉自己
        }
    }

    void Update()
    {
        //前進
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) this.transform.Translate(Vector3.forward * PlayerSpeed * Time.deltaTime) ;
        //後退
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) this.transform.Translate(Vector3.forward * -PlayerSpeed * Time.deltaTime);
        //往左
        if (Input.GetKey(KeyCode.A) | Input.GetKey(KeyCode.LeftArrow)) this.transform.Translate(Vector3.right * -PlayerSpeed * Time.deltaTime);
        //往右
        if (Input.GetKey(KeyCode.D) | Input.GetKey(KeyCode.RightArrow)) this.transform.Translate(Vector3.right * PlayerSpeed * Time.deltaTime);
    }
}
