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
        float backgroundPos = transform.position.y; //¶¬‚³‚ê‚½”wŒi‚ÌyÀ•W
        float cameraPos = this.MainCamera.transform.position.y; //ƒJƒƒ‰‚ÌyÀ•W

        //ƒJƒƒ‰‚Æ‹——£‚ª12—£‚ê‚½‚ç”jŠü
        if (cameraPos - backgroundPos > 12)
        {
            Destroy(gameObject);
        }
    }
}
