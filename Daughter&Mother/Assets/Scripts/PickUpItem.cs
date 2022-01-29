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
            chatManager.Action("어쩌구저쩌구");
            PickUp();
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

    void PickUp()
    {
        Destroy(gameObject);
    }

}
