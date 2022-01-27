using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NameButton : MonoBehaviour
{
    public InputField inputName;

    public void Save() 
    {
        // 지정한 키로 String 타입의 값을 저장
        PlayerPrefs.SetString("Name", inputName.text);
    }
    public void Load() 
    {
        // 지정한 String 타입의 키 값을 로드
        inputName.text = PlayerPrefs.GetString("Name");
    }
    public void ChangeScene2Explain()
    {
        SceneManager.LoadScene("ExplainGame");
    }
}
