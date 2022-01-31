using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 대화창에 들어가는 텍스트의 종류
// 1. 배경 오브젝트 설명 -> 각 오브젝트의 설명을 출력
// 2. 아이템 설명 -> 아이템의 설명을 출력, 획득 메시지
// 3. 대사 -> 주인공과 에너미가 나누는 대화
// 4. 스테이지 종료 메시지

public class ChatManager : MonoBehaviour
{
    public bool isAction;
    // 대화창에 띄울 텍스트
    public Text talkText;
    // 플레이어가 조사한 오브젝트
    public PickUpItem item;
    // 대화창 
    public GameObject talkPanel; 

    // 처음 시작할 때 대화창 안보이도록 비활성화
    private void Start() 
    {
        talkPanel.SetActive(false);
    }

    // 1. 오브젝트의 설명을 출력하는 함수
    public void Action(string _name) 
    {
        // 대화창 비활성화
        if (isAction)
        {
            isAction = false;
        }
        else 
        {
            // 대화창 활성화
            isAction = true;     
            talkText.text = "이것의 이름은 " + _name + "이라고 한다.";
            // 대화 중에 플레이어 움직이지 못하도록 -> playerController 스크립트
        }
        // 대화창 이미지도 같이 활/비활성화
        talkPanel.SetActive(isAction);
    }
}
