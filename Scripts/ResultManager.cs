using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
    //タイトルに戻る
    public void BackTitleButton()
    {
        SceneManager.LoadScene(0);
    }
}
