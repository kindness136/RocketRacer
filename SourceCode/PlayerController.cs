using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    GameObject countdownText;
    GameObject timerText;

    float upForce = 0.75f; // 上昇速度
    float maxUpSpeed = 7.5f; // 最高上昇速度
    float sideForce = 2.5f; // 左右移動速度
    Vector3 worldDir;

    //開始時のカウントダウン
    float countdown = 4f;
    int count;
    float time = 0;

    float characterWidth = 1f; // 自機の幅
    float screenWidth = 4.7f; // 画面幅

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.countdownText = GameObject.Find("CountDown");
        this.timerText = GameObject.Find("Time");
    }

    // Update is called once per frame
    void Update()
    {
        //開始時カウントダウン
        if (countdown >= 1)
        {
            countdown -= Time.deltaTime;
            count = (int)countdown;
            this.countdownText.GetComponent<TextMeshProUGUI>().text = this.count.ToString("");
        }

        //カウントダウン後ゲームスタート
        if (countdown <= 1)
        {
            Destroy(this.countdownText); //カウントダウンテキストの消去

            //スマホ向けの操作、タップ位置の取得
            if (Input.GetMouseButtonDown(0))
            {
                worldDir = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }

            //画面から指を離したら座標を0へ
            else if (Input.GetMouseButtonUp(0))
            {
                worldDir = new Vector3(0, 0, 0);
            }

            this.time += Time.deltaTime; //経過時間
            this.timerText.GetComponent<TextMeshProUGUI>().text = this.time.ToString("F1"); //UIに時間を表示

            float speedy = Mathf.Abs(this.rigid2D.velocity.y); //プレイヤの上方向速度

            if (speedy < maxUpSpeed) //上方向スピード制限
            {
                this.rigid2D.AddForce(transform.up * this.upForce);
            }

            // 左右移動
            int key = 0;
            if (Input.GetKey(KeyCode.RightArrow) || worldDir.x > 0) key = 1; //矢印右、または画面右側タップで右へ
            if (Input.GetKey(KeyCode.LeftArrow) || worldDir.x < 0) key = -1; //矢印左、または画面左側タップで左へ

            this.rigid2D.AddForce(transform.right * key * this.sideForce);

            //以下chatGPT参考
            Vector2 currentPosition = this.transform.position; //現在の位置

            // 左端に着いたら右端へ
            if (currentPosition.x < -screenWidth / 2 - characterWidth / 2)
            {
                float newPositionX = screenWidth / 2 + characterWidth / 2;
                this.transform.position = new Vector2(newPositionX, currentPosition.y);
            }

            // 右端に着いたら左端へ
            else if (currentPosition.x > screenWidth / 2 + characterWidth / 2)
            {
                float newPositionX = -screenWidth / 2 - characterWidth / 2;
                this.transform.position = new Vector2(newPositionX, currentPosition.y);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) //ゴールバーに触れたとき
    {
        float goaltime = Mathf.Floor(this.time * 10.0f) / 10.0f; //ゴールタイムの小数第2位以下の切り捨て
        Debug.Log(goaltime);
        
        PlayerPrefs.SetFloat("GoalTime", goaltime); //ゴールタイムの設定

        GetComponent<AudioSource>().Play(); //ゴール時に歓声

        //ゴール後0.9秒でクリアシーン遷移
        IEnumerator DelayedAction()
        {
            yield return new WaitForSeconds(0.9f);
            SceneManager.LoadScene("ClearScene");
        }
        StartCoroutine(DelayedAction());
    }
}
