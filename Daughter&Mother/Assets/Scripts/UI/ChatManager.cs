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
    // 대화창 활성화 여부
    public bool isAction;
    // 대화창에 띄울 텍스트
    public Text talkText;
    // 플레이어가 조사한 오브젝트
    public PickUpItem item;
    // 대화창 
    public GameObject talkPanel;

    // 아이템데이터베이스에 접근
    public ItemDatabase theDatabase;



    // 처음 시작할 때 대화창 안보이도록 비활성화
    private void Start() 
    {
        talkPanel.SetActive(false);
        theDatabase = FindObjectOfType<ItemDatabase>(); // ItemDataBase 스크립트
    }

    // 1. 배경 오브젝트의 설명을 대화창에 띄우는 함수
    public void ActionObjDesc(string _name) 
    {
        // Space를 눌렀을 때 (PickUpItem 스크립트)
        // 대화창이 활성화 되어있다면 
        if (isAction)
        {
            isAction = false; //대화창 비활성화
        }
        // 대화창이 비활성화 되어 있다면 
        else 
        {
            isAction = true; // 대화창 활성화
            talkText.text = "이것의 이름은 " + _name + "이라고 한다.";
            // 대화 중에 플레이어 움직이지 못하도록 -> playerController 스크립트 
        }
        // 대화창 이미지도 같이 활/비활성화
        talkPanel.SetActive(isAction);
    }

    // 2.아이템 습득시 아이템 설명을 대화창에 띄우는 함수
    public void ActionItemDesc(int _itemID) // 아이템 객체를 인자로 받아서 
    {
        // Space를 눌렀을 때 (PickUpItem 스크립트)
        // 대화창이 활성화 되어있다면 
        if (isAction)
        {
            isAction = false; //대화창 비활성화
        }
        // 대화창이 비활성화 되어 있다면
        else
        {
            // 데이터베이스 검색 
            // 데이터 베이스의 아이템 리스트 크기만큼 반복하며 ID를 찾음
            for (int i = 0; i < theDatabase.itemList.Count; i++)
            {
                Debug.Log("데이터베이스에서 아이템 ID 검색 중 : " + i);
                if (_itemID == theDatabase.itemList[i].itemID) //베이스에서 ID를 찾으면
                {
                    Debug.Log("데이터베이스에서 아이템 ID를 찾았습니다.");
                    isAction = true; // 대화창 활성화
                    // 해당 아이템ID에 맞는 이름과 설명을 대화창에 출력
                    talkText.text = theDatabase.itemList[i].itemName + ". " + theDatabase.itemList[i].itemDescription ;
                    break;
                }
            }
            // 만약 데이터베이스에서 해당 ID의 아이템을 발견하지 못하면 에러창을 띄움.
            Debug.LogError("데이터베이스에 해당 ID를 가진 아이템이 존재하지 않습니다.");
        }
        // 대화창 이미지도 같이 활/비활성화
        talkPanel.SetActive(isAction);
    }

    // 3. npc(에너미)와 나우는 대화를 대화창에 띄우는 함수
    // -> 채은님
}
