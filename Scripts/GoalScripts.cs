using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalScripts : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        //�v���C���[���G�ꂽ��
        if(collision.gameObject.tag == "Player")
        {
            //�S�[���V�[���Ɉڍs����
            SceneManager.LoadScene("ClearScene");
        }
    }
}
