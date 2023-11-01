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

    float upForce = 0.75f; // �㏸���x
    float maxUpSpeed = 7.5f; // �ō��㏸���x
    float sideForce = 2.5f; // ���E�ړ����x
    Vector3 worldDir;

    //�J�n���̃J�E���g�_�E��
    float countdown = 4f;
    int count;
    float time = 0;

    float characterWidth = 1f; // ���@�̕�
    float screenWidth = 4.7f; // ��ʕ�

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
        //�J�n���J�E���g�_�E��
        if (countdown >= 1)
        {
            countdown -= Time.deltaTime;
            count = (int)countdown;
            this.countdownText.GetComponent<TextMeshProUGUI>().text = this.count.ToString("");
        }

        //�J�E���g�_�E����Q�[���X�^�[�g
        if (countdown <= 1)
        {
            Destroy(this.countdownText); //�J�E���g�_�E���e�L�X�g�̏���

            //�X�}�z�����̑���A�^�b�v�ʒu�̎擾
            if (Input.GetMouseButtonDown(0))
            {
                worldDir = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }

            //��ʂ���w�𗣂�������W��0��
            else if (Input.GetMouseButtonUp(0))
            {
                worldDir = new Vector3(0, 0, 0);
            }

            this.time += Time.deltaTime; //�o�ߎ���
            this.timerText.GetComponent<TextMeshProUGUI>().text = this.time.ToString("F1"); //UI�Ɏ��Ԃ�\��

            float speedy = Mathf.Abs(this.rigid2D.velocity.y); //�v���C���̏�������x

            if (speedy < maxUpSpeed) //������X�s�[�h����
            {
                this.rigid2D.AddForce(transform.up * this.upForce);
            }

            // ���E�ړ�
            int key = 0;
            if (Input.GetKey(KeyCode.RightArrow) || worldDir.x > 0) key = 1; //���E�A�܂��͉�ʉE���^�b�v�ŉE��
            if (Input.GetKey(KeyCode.LeftArrow) || worldDir.x < 0) key = -1; //��󍶁A�܂��͉�ʍ����^�b�v�ō���

            this.rigid2D.AddForce(transform.right * key * this.sideForce);

            //�ȉ�chatGPT�Q�l
            Vector2 currentPosition = this.transform.position; //���݂̈ʒu

            // ���[�ɒ�������E�[��
            if (currentPosition.x < -screenWidth / 2 - characterWidth / 2)
            {
                float newPositionX = screenWidth / 2 + characterWidth / 2;
                this.transform.position = new Vector2(newPositionX, currentPosition.y);
            }

            // �E�[�ɒ������獶�[��
            else if (currentPosition.x > screenWidth / 2 + characterWidth / 2)
            {
                float newPositionX = -screenWidth / 2 - characterWidth / 2;
                this.transform.position = new Vector2(newPositionX, currentPosition.y);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) //�S�[���o�[�ɐG�ꂽ�Ƃ�
    {
        float goaltime = Mathf.Floor(this.time * 10.0f) / 10.0f; //�S�[���^�C���̏�����2�ʈȉ��̐؂�̂�
        Debug.Log(goaltime);
        
        PlayerPrefs.SetFloat("GoalTime", goaltime); //�S�[���^�C���̐ݒ�

        GetComponent<AudioSource>().Play(); //�S�[�����Ɋ���

        //�S�[����0.9�b�ŃN���A�V�[���J��
        IEnumerator DelayedAction()
        {
            yield return new WaitForSeconds(0.9f);
            SceneManager.LoadScene("ClearScene");
        }
        StartCoroutine(DelayedAction());
    }
}
