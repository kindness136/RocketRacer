using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, -0.03f, 0); // �������x
    }
    void OnCollisionEnter2D(Collision2D collision) //chatGPT�Q�l
    {
        //border�ɐG�ꂽ��j��
        if (collision.gameObject.CompareTag("border"))
        {
            Destroy(gameObject);
        }
    }
}
