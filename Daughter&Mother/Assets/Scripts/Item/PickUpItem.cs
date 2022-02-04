using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour
{
    public int itemID;
    bool isPickUp;
    // 아이템에 가까워지면 space를 누르라는 안내 문구
    public Text pickUpText; 
    // 대화창 띄울 변수
    public ChatManager chatManager; 
    // 아이템데이터베이스에 접근
    public ItemDatabase theDatabase; 


    void Start() 
    {
        // 아이템에 가까워지면 space를 누르라는 안내 문구 비활
        pickUpText.gameObject.SetActive(false);
    }

    void Update() 
    {
        if (isPickUp && Input.GetKeyDown(KeyCode.Space))
        {
            // 아이템의 종류에 따라 (장착 가능 여부) 대화창을 활성화 시킨다. 
            if (itemID >= 0)
            {
                // 장비가능한 item 의 ID는 0~99
                if (itemID < 100)
                {
                    chatManager.ActionItemDesc(itemID);
                    // if (비활성화 되었을 때) -> 스페이스로 활성화 시킨 후 다시 비활 시킨 것. 
                    if (chatManager.isAction == false)
                    {
                        // 인벤토리에 넣고 아이템 삭제
                        PickUp(); 
                    }
                }
                // 장비불가능한 stuff의 ID는 100~999
                else if (itemID < 1001)
                {
                    chatManager.ActionStuffDesc(itemID);
                }
                // 쪽지의 ID는 1001 ~ 1003
                else
                {
                    chatManager.ActionNoteCont(itemID);
                    if (chatManager.isAction == false)
                    {
                        PickUpNote();
                        // ispiclup 비활성화 후 쪽지를 얻었을 때 호출 : ShowDialogue();
                    }
                }
            }
            else
            {
                Debug.LogError("유효하지 않은 아이템 ID 입니다.");
            }
        }
    }

    // 콜라이더 추가해야 함. space를 누르라는 안내문구를 띄우기 위해
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            pickUpText.gameObject.SetActive(true);
            isPickUp = true;
        }
    }
    
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            pickUpText.gameObject.SetActive(false);
            isPickUp = false;
        }
    }

    // 인벤토리에 넣는 <아이템일 경우> 삭제시키고 인벤토리에 넣는다. 
    void PickUp()
    {
            // 인벤토리에 추가
            Inventory.instance.GetAnItem(itemID);
            // 아이템 삭제
            Destroy(gameObject);
    }

    // 쪽지를 인벤토리 장비창에 위치시킨다.
    void PickUpNote()
    {
        // 현재 노트를 저장
        Inventory.instance.GetANote(itemID);
        // 아이템 삭제
        Destroy(gameObject);
    }

}
