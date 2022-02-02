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
    public void ActionStuffDesc(int _itemID) // 아이템 객체를 인자로 받아서 
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
            for (int i = 100; i < (theDatabase.stuffList.Count + 100); i++)
            {
                Debug.Log( "stuff 리스트 개수 : " + theDatabase.stuffList.Count);
                Debug.Log("for문 도는 중~!");
                if (_itemID == theDatabase.stuffList[i-100].stuffID) //베이스에서 ID를 찾으면
                {
                    isAction = true; // 대화창 활성화
                    // 해당 아이템ID에 맞는 이름과 설명을 대화창에 출력
                    talkText.text = theDatabase.stuffList[i-100].stuffDescription;
                    break;
                }
            }
        }
        // 대화창 이미지도 같이 활/비활성화
        talkPanel.SetActive(isAction);
    }

    // 2.아이템 습득시 아이템 설명을 대화창에 띄우는 함수
    public void ActionItemDesc(int _itemID) // 아이템 아이디를 인자로 받는다.
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
                if (_itemID == theDatabase.itemList[i].itemID) //베이스에서 ID를 찾으면
                {
                    isAction = true; // 대화창 활성화
                    // 해당 아이템ID에 맞는 이름과 설명을 대화창에 출력
                    talkText.text = theDatabase.itemList[i].itemName + ". " + theDatabase.itemList[i].itemDescription ;
                    break;
                }
            }
        }
        // 대화창 이미지도 같이 활/비활성화
        talkPanel.SetActive(isAction);
    }

    // 3. npc(에너미)와 나우는 대화를 대화창에 띄우는 함수
    // -> 채은님
}
 