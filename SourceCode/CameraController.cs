using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject rocket;
    float currentheight = -3f; //�J�����̍����̊
    float destination = 245f; //�S�[���n�_�ł̃J�����̍���
    // Start is called before the first frame update
    void Start()
    {
        this.rocket = GameObject.Find("rocket");
    }

    // Update is called once per frame
    void Update()
    {
        float highest = this.rocket.transform.position.y; // �J�����̍�������
        
        //���@�����ɍs���Ă������̃L�[�v
        if (highest > currentheight)
        {
            transform.position = new Vector3(transform.position.x, highest + 3f, transform.position.z);
            currentheight = highest;
        }

        //�S�[�����ӂŃJ�����̐Î~
        if (transform.position.y >= destination)
        {
            transform.position = new Vector3(0, destination, -10);
        }
    }
}
