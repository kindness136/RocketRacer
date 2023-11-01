using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameDirector : MonoBehaviour
{
    GameObject generator;
    GameObject MainCamera;
    // Start is called before the first frame update
    void Start()
    {
        this.generator = GameObject.Find("RockGenerator");
        this.MainCamera = GameObject.Find("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        float cameraPosy = this.MainCamera.transform.position.y; //ƒJƒƒ‰‚Ì‚‚³

        //ƒJƒƒ‰‚Ì‚‚³‚ÆŠâ‚Ì—N‚«•û‚Ì‘ŠŠÖ
        if (0 <= cameraPosy && cameraPosy < 20)
        {
            this.generator.GetComponent<RockGenerator>().SetParameter(1.0f, 1000.0f);
        }
        else if (20 <= cameraPosy && cameraPosy < 90)
        {
            this.generator.GetComponent<RockGenerator>().SetParameter(0.9f, 2.2f);
        }
        else if (90 <= cameraPosy && cameraPosy < 155)
        {
            this.generator.GetComponent<RockGenerator>().SetParameter(0.8f, 1.7f);
        }
        else if (155 <= cameraPosy && cameraPosy < 225)
        {
            this.generator.GetComponent<RockGenerator>().SetParameter(0.7f, 1.3f);
        }
        else if (225 <= cameraPosy && cameraPosy < 245)
        {
            this.generator.GetComponent<RockGenerator>().SetParameter(1.1f, 1000.0f);
        }

    }
}
