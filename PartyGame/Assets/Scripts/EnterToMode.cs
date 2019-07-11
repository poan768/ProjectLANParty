using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnterToMode : MonoBehaviour
{
    public void EnterMode(int EnterToMode)
    {
        SceneManager.LoadScene(EnterToMode);
    }
}
