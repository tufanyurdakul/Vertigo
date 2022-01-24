using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleScreen : MonoBehaviour
{
    public GameObject BackGround;
    void Start()
    {
        float defaultSize = 9.0f / 16.0f;
        float mySize = (float)Screen.width / (float)Screen.height;
        float multply =  defaultSize / mySize;
        BackGround.transform.localScale = new Vector3(BackGround.transform.localScale.x , BackGround.transform.localScale.y * multply, BackGround.transform.localScale.z);
    }
}
