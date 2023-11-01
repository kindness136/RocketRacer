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
        //�X�y�[�X�L�[�A��ʃ^�b�v�ŃQ�[���V�[����
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            GetComponent<AudioSource>().Play();//���艹��炷

            //0.3�b��ɃQ�[���V�[���J��
            IEnumerator DelayedAction()
            {
                yield return new WaitForSeconds(0.3f);
                SceneManager.LoadScene("GameScene");
            }
            StartCoroutine(DelayedAction());
        }
    }
}
