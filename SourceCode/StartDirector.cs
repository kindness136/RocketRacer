using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartDirector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //スペースキー、画面タップでゲームシーンへ
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            GetComponent<AudioSource>().Play();//決定音を鳴らす

            //0.3秒後にゲームシーン遷移
            IEnumerator DelayedAction()
            {
                yield return new WaitForSeconds(0.3f);
                SceneManager.LoadScene("GameScene");
            }
            StartCoroutine(DelayedAction());
        }
    }
}
