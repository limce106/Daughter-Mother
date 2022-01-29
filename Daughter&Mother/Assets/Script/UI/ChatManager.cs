using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 대화창에 들어가는 텍스트의 종류
// 1. 배경 오브젝트 설명 -> 각 오브젝트의 설명을 출력
// 2. 아이템 설명 -> 아이템의 설명을 출력, 획득 메시지
// 3. 대사 -> 주인공아니 에너미가 나누는 대화
// 4. 스테이지 종료 메시지

public class ChatManager : MonoBehaviour
{
    // 대화창에 띄울 텍스트
    public Text talkText;
    // 플레이어가 조사한 오브젝트
    public GameObject scanObject;

    // 1. 오브젝트의 설명을 출력하는 함수
    public void Action(GameObject _scanObject) 
    {
        scanObject = _scanObject;
        talkText.text = "이것의 이름은 " + scanObject.name + "이라고 한다.";
    }
    // 
}
