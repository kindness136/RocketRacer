using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject rocket;
    float currentheight = -3f; //カメラの高さの基準
    float destination = 245f; //ゴール地点でのカメラの高さ
    // Start is called before the first frame update
    void Start()
    {
        this.rocket = GameObject.Find("rocket");
    }

    // Update is called once per frame
    void Update()
    {
        float highest = this.rocket.transform.position.y; // カメラの高さ制限
        
        //自機が下に行っても高さのキープ
        if (highest > currentheight)
        {
            transform.position = new Vector3(transform.position.x, highest + 3f, transform.position.z);
            currentheight = highest;
        }

        //ゴール周辺でカメラの静止
        if (transform.position.y >= destination)
        {
            transform.position = new Vector3(0, destination, -10);
        }
    }
}
