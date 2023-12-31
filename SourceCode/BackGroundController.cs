using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundController : MonoBehaviour
{
    GameObject MainCamera;
    // Start is called before the first frame update
    void Start()
    {
        this.MainCamera = GameObject.Find("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        float backgroundPos = transform.position.y; //生成された背景のy座標
        float cameraPos = this.MainCamera.transform.position.y; //カメラのy座標

        //カメラと距離が12離れたら破棄
        if (cameraPos - backgroundPos > 12)
        {
            Destroy(gameObject);
        }
    }
}
