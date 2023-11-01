using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ClearDirector : MonoBehaviour
{
    GameObject timeText;
    float goaltime;
    // Start is called before the first frame update
    void Start()
    {
        this.timeText = GameObject.Find("Time");
    }

    // Update is called once per frame
    void Update()
    {
        goaltime = PlayerPrefs.GetFloat("GoalTime", 0f); //ゴールタイムの取得
        this.timeText.GetComponent<TextMeshProUGUI>().text = "Time: " + this.goaltime.ToString("F1"); //ゴールタイムの表示

        //スペースキー、画面タップでスタートシーン遷移
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            GetComponent<AudioSource>().Play();//決定音を鳴らす

            //0.3秒後にスタートシーン遷移
            IEnumerator DelayedAction()
            {
                yield return new WaitForSeconds(0.3f);
                SceneManager.LoadScene("StartScene");
            }
            StartCoroutine(DelayedAction());
        }
    }
}
