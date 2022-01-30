using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    // SetName 씬에서 이름을 받는다.
    public InputField inputName; 
    // 이름을 저장하고 불러오는 함수
    // PlayerPrefs를 이용해 클라이언트에 데이터 저장
     public void Save() 
    {
        // 지정한 키(Name)로 String 타입의 값을 저장
        PlayerPrefs.SetString("Name", inputName.text);
    }
    public void Load() 
    {
        // 지정한 String 타입의 키(Name) 값을 로드
        inputName.text = PlayerPrefs.GetString("Name");
    }

    // 씬 전환 함수들
    public void ChangeToNameScene()
    {
        SceneManager.LoadScene("SetName");
    }
    public void ChangeSToExplainScene()
    {
        SceneManager.LoadScene("ExplainGame");
    }
    public void ChangeSToBedroomScene()
    {
        SceneManager.LoadScene("BedRoom");
    }
    // 게임종료
    public void GameOut()
    {
        Application.Quit();
    }
}