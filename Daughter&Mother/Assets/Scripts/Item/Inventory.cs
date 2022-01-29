using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    // 인벤토리 슬롯들
    private InventorySlot[] slots;
    // 플레이어가 소지한 아이템 리스트
    private List<Item> inventoryItemList;
    // 아이템을 선택 했을 때의 설명
    public Text DescriptionText;
    // Slot의 부모 객체. (그리드)
    // 부모 객체의 자식 객체들 즉, slot. InventorySlot[] 안에 넣음
    //public Transform tf; // 이 스크립트를 어디다가 붙이는지가 문제인 것 같은데ㅔ...

    // 선택된 아이템의 번호
    private int selectedItem;
    // 인벤토리창
    public GameObject inventoryPanel;
    // 인벤토리창 활성화시 true
    bool activeInventory = false;
    // 아이템 활성화시 true
    bool activeItem;

    // 키 입력 제한 (포션 먹을 때 확인 질문 -> 키 입력 방지)
    bool stopKetInput;
    // 중복실행 제한
    bool preventExec;


    // 시작 : 인벤토리창 초기화
    void Start() 
    {
        // 초기화 진행
        inventoryItemList = new List<Item>(); //인벤토리 아이템 리스트 초기화
        //slots = tf.GetComponentsInChildren<InventorySlot>(); // 그리드의 자식객체인 slot 프리팹들이 slots에 들어감

        inventoryPanel.SetActive(activeInventory); //인벤토리 UI 활성화
    }
    
    void Update()
    {
        // 키보드 C를 눌러서 인벤토리 UI를 열고닫는다. 
        if (Input.GetKeyDown(KeyCode.C))
        {
            activeInventory = !activeInventory;
            inventoryPanel.SetActive(activeInventory);
            // 인벤토리가 활성화 된 경우에
            if (activeInventory)
            {
                // 오른쪽 방향키를 누른다면
                if(Input.GetKeyDown(KeyCode.RightArrow))
                {
                    
                }
            }
        }
    }

    // 
}
