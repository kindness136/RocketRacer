using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderController : MonoBehaviour
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
        Vector3 cameraPos = this.MainCamera.transform.position; //�J�����̍��W�̎擾
        transform.position = new Vector3(cameraPos.x, cameraPos.y - 5.5f, cameraPos.z); //�J�����ɒǏ]���ē���
    }
}
