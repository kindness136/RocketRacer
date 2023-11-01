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
        float backgroundPos = transform.position.y; //�������ꂽ�w�i��y���W
        float cameraPos = this.MainCamera.transform.position.y; //�J������y���W

        //�J�����Ƌ�����12���ꂽ��j��
        if (cameraPos - backgroundPos > 12)
        {
            Destroy(gameObject);
        }
    }
}
