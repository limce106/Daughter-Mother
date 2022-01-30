using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour
{
    bool isPickUp;
    // 아이템에 가까워지면 space를 누르라는 안내 문구
    [SerializeField] Text pickUpText;
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
            // 다시 스페이스를 눌러서 비활성화 시켜도 아이템이 사라지지는 않음.
            // 이후에 아이템과 단순 오브젝트를 나누어서 구현할 것.
        }
    }

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
        Destroy(gameObject);
    }

}
