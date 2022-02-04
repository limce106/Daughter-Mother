using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    // 아이템데이터베이스에 접근
    public ItemDatabase theDatabase;
    // 대화데이터베이스에 접근
    public TalkManager talkManager;

    // 대화창 
    // 기본 대화창
    public GameObject talkPanel;
    // 플레이어 기본 대화창
    public GameObject playerPanel1;
    // 플레이어의 엄마 기본 대화창
    public GameObject motherPanel1;
    // 플레이어 웃는 대화창
    public GameObject playerPanel2;
    // 플레이어의 엄마 웃는 대화창
    public GameObject motherPanel2;
    // 플레이어 우는 대화창
    public GameObject playerPanel3;
    // 플레이어의 엄마 우는 대화창
    public GameObject motherPanel3;

    GameObject npc;

    int talkIndex = 0;

    // 처음 시작할 때 대화창 안보이도록 비활성화
    private void Start()
    {
        talkPanel.SetActive(false);
        theDatabase = FindObjectOfType<ItemDatabase>(); // ItemDataBase 스크립트
        ShowDialogue();
        PlayerController.instance.chatManager = GameObject.FindObjectOfType<ChatManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShowDialogue();
        }
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
                Debug.Log("여기가문제");
                if (_itemID == theDatabase.stuffList[i - 100].stuffID) //베이스에서 ID를 찾으면
                {
                    isAction = true; // 대화창 활성화
                    // 해당 아이템ID에 맞는 이름과 설명을 대화창에 출력
                    talkText.text = theDatabase.stuffList[i - 100].stuffDescription;
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
                    talkText.text = theDatabase.itemList[i].itemName + ". " + theDatabase.itemList[i].itemDescription;
                    break;
                }
            }
        }
        // 대화창 이미지도 같이 활/비활성화
        talkPanel.SetActive(isAction);
    }

    // 3. npc(에너미, 엄마)와 나누는 대화를 대화창에 띄우는 함수
    public void ShowDialogue()
    {
        List<string> talkData;

        // Stage1S
        if (SceneManager.GetActiveScene().name == "Home1")
        {
            talkData = talkManager.GetTalk(talkManager.Talk1, talkIndex);
            //if (talkData == null)
            //{
            //    talkPanel.SetActive(false);
            //    talkIndex = 0;
            //    return;
            //}
            if (Input.GetKeyDown(KeyCode.Space) && talkIndex <= 2)
            {
                talkText.text = talkData[talkIndex];
                talkPanel.SetActive(true);
                talkIndex++;
            }
            else
            {
                talkPanel.SetActive(false);
                talkIndex = 0;
                return;
            }

            // 쪽지를 읽은 후
            //if ()
            //{
            //    talkPanel.SetActive(true);
            //    talkText.text = talkData[4];\
            // 
            //    Inventory.instance.currentNote.getNote = false;
            //}

            // 마법봉을 주으면
            //if ()
            //{
            //    talkPanel.SetActive(true);
            //    talkText.text = talkData[3];
            //}
        }

        // Stage2
        if (SceneManager.GetActiveScene().name == "Road1")
        {
            talkData = talkManager.GetTalk(talkManager.Talk2, talkIndex);
            if (talkData == null)
            {
                talkPanel.SetActive(false);
                talkIndex = 0;
                return;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                talkText.text = talkData[talkIndex];
                talkPanel.SetActive(true);
                talkIndex++;
            }
        }


        if (SceneManager.GetActiveScene().name == "Playground") 
        {
            // 에너미에게 말 걸었을 때 실행
            if (Input.GetKeyDown(KeyCode.Space))
            {
                talkData = talkManager.GetTalk(talkManager.Talk3, talkIndex);
                if (talkData == null)
                {
                    talkPanel.SetActive(false);
                    talkIndex = 0;
                    return;
                }
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    talkText.text = talkData[talkIndex];
                    talkPanel.SetActive(true);
                    talkIndex++;
                }
            }

            EnemyController ec = GameObject.Find("Enemy").GetComponent<EnemyController>();
            // 전투가 끝난 후
            if (ec.hp <= 0)
            {
                talkData = talkManager.GetTalk(talkManager.Talk4, talkIndex);
                if (talkData == null)
                {
                    talkPanel.SetActive(false);
                    talkIndex = 0;
                    return;
                }
                // 자동으로 뜨도록 수정
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    talkPanel.SetActive(true);
                    talkText.text = talkData[0];
                }
                // 쪽지를 읽은 후
                //if ()
                //{
                //    talkPanel.SetActive(true);
                //    talkText.text = talkData[1];
                //}
            }
        }

        // Stage3
        if (SceneManager.GetActiveScene().name == "StationaryStore")
        {
            talkData = talkManager.GetTalk(talkManager.Talk5, talkIndex);
            if (talkData == null)
            {
                talkPanel.SetActive(false);
                talkIndex = 0;
                return;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                talkText.text = talkData[talkIndex];
                talkPanel.SetActive(true);
                talkIndex++;
            }

            // 에너미에게 말 걸었을 때 실행
            if (Input.GetKeyDown(KeyCode.Space))
            {
                talkData = talkManager.GetTalk(talkManager.Talk6, talkIndex);
                if (talkData == null)
                {
                    talkPanel.SetActive(false);
                    talkIndex = 0;
                    return;
                }
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    talkText.text = talkData[talkIndex];
                    talkPanel.SetActive(true);
                    talkIndex++;
                }
            }

            EnemyController ec = GameObject.Find("Enemy").GetComponent<EnemyController>();
            if (ec.hp <= 0)
            {
                talkData = talkManager.GetTalk(talkManager.Talk7, talkIndex);
                if (talkData == null)
                {
                    talkPanel.SetActive(false);
                    talkIndex = 0;
                    return;
                }
                if (Input.GetKeyDown(KeyCode.Space) && talkIndex <= 1)
                {
                    talkText.text = talkData[talkIndex];
                    talkPanel.SetActive(true);
                    talkIndex++;
                }
                // 쪽지를 읽은 후
                //if ()
                //{
                //    talkPanel.SetActive(true);
                //    talkText.text = talkData[2];
                //}
            }
        }

        // Stage4
        if (SceneManager.GetActiveScene().name == "School")
        {
            talkData = talkManager.GetTalk(talkManager.Talk8, talkIndex);
            if (talkData == null)
            {
                talkPanel.SetActive(false);
                talkIndex = 0;
                return;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                talkText.text = talkData[talkIndex];
                talkPanel.SetActive(true);
                talkIndex++;
            }

            // 에너미에게 말 걸었을 때 실행
            if (Input.GetKeyDown(KeyCode.Space))
            {
                talkData = talkManager.GetTalk(talkManager.Talk9, talkIndex);
                if (talkData == null)
                {
                    talkPanel.SetActive(false);
                    talkIndex = 0;
                    return;
                }
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    talkText.text = talkData[talkIndex];
                    talkPanel.SetActive(true);
                    talkIndex++;
                }
            }

            EnemyController ec = GameObject.Find("Enemy").GetComponent<EnemyController>();
            if (ec.hp <= 0)
            {
                talkData = talkManager.GetTalk(talkManager.Talk10, talkIndex);
                if (talkData == null)
                {
                    talkPanel.SetActive(false);
                    talkIndex = 0;
                    return;
                }
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    talkText.text = talkData[talkIndex];
                    talkPanel.SetActive(true);
                    talkIndex++;
                }
            }
        }

        // Stage5
        if (SceneManager.GetActiveScene().name == "Test_Talking")
        {
            talkData = talkManager.GetTalk(talkManager.Talk11, talkIndex);
            if (talkData == null)
            {
                talkPanel.SetActive(false);
                talkIndex = 0;
                return;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                talkText.text = talkData[talkIndex];
                talkPanel.SetActive(true);
                talkIndex++;
            }
        }
    }

    // 4. 쪽지의 내용을 대화창에 띄우는 함수
    public void ActionNoteCont(int _itemID) // 아이템 객체를 인자로 받아서 
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
            for (int i = 1001; i < (theDatabase.NoteList.Count + 1001); i++)
            {
                if (_itemID == theDatabase.NoteList[i - 1001].noteID) //베이스에서 ID를 찾으면
                {
                    isAction = true; // 대화창 활성화
                    // 해당 아이템ID에 맞는 이름과 설명을 대화창에 출력
                    talkText.text = theDatabase.NoteList[i - 1001].noteContent;
                    break;
                }
            }
        }
        // 대화창 이미지도 같이 활/비활성화
        talkPanel.SetActive(isAction);
    }

}
