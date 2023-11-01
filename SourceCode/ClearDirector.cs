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
        goaltime = PlayerPrefs.GetFloat("GoalTime", 0f); //�S�[���^�C���̎擾
        this.timeText.GetComponent<TextMeshProUGUI>().text = "Time: " + this.goaltime.ToString("F1"); //�S�[���^�C���̕\��

        //�X�y�[�X�L�[�A��ʃ^�b�v�ŃX�^�[�g�V�[���J��
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            GetComponent<AudioSource>().Play();//���艹��炷

            //0.3�b��ɃX�^�[�g�V�[���J��
            IEnumerator DelayedAction()
            {
                yield return new WaitForSeconds(0.3f);
                SceneManager.LoadScene("StartScene");
            }
            StartCoroutine(DelayedAction());
        }
    }
}
