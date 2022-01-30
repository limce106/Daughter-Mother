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


    void Start() 
    {
        // 아이템에 가까워지면 space를 누르라는 안내 문구 비활
        pickUpText.gameObject.SetActive(false);
    }

    void Update() 
    {
        if (isPickUp && Input.GetKeyDown(KeyCode.Space))
        {
            // 대화창을 활성화 시킨다.
            chatManager.Action("어쩌구저쩌구"); 
            // if (비활성화 되었을 때) -> 스페이스로 활성화 시킨 후 다시 비활 시킨 것.
            if (chatManager.isAction == false)
            {
                // 단순 오브젝트라면 아이템이 사라지지 않음. 
                // item에 해당할 경우
                PickUp();
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

    // 인벤토리에 넣는 아이템일 경우 삭제시키고 인벤토리에 넣는다. 
    void PickUp()
    {
        // 인벤토리에 추가
        Inventory.instance.GetAnItem(itemID);
        // 아이템 삭제
        Destroy(gameObject);
    }

}
