using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundGenerator : MonoBehaviour
{
    GameObject MainCamera;
    public GameObject backgroundPrefab;
    float generate_pos = 0f;
    // Start is called before the first frame update
    void Start()
    {
        this.MainCamera = GameObject.Find("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        float cameraPosy = this.MainCamera.transform.position.y; //カメラのy座標の取得

        //genrate_posよりカメラが高くなったらy座標10上に背景を生成
        if (cameraPosy >= generate_pos) 
        {
            GameObject go = Instantiate(backgroundPrefab);
            generate_pos += 10;
            go.transform.position = new Vector3(0, generate_pos, 0);
        }

    }
}
