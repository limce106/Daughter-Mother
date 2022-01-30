using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Inventory : MonoBehaviour
{
    /* 변수 */
    // 아이템을 선택 했을 때의 이름
    public Text NameText; 
    // 아이템을 선택 했을 때의 설명 
    public Text DescriptionText; 
    // 선택된 아이템의 번호, 어떤 아이템을 선택했는지?
    private int selectedItem; 

    // 인벤토리 슬롯들
    private InventorySlot[] slots; 
    // 플레이어가 소지한 아이템 리스트 
    private List<Item> inventoryItemList; 
    // Slot의 부모 객체. (그리드 슬롯) 
    // 부모 객체의 자식 객체들 즉, slot. InventorySlot[] 안에 넣음
    public Transform tf; 

    // 인벤토리창
    public GameObject inventoryPanel;
    // 인벤토리창 활성화시 true
    bool activeInventory = false;

    // 중복실행 제한
    bool preventExec;

    /* 함수 */
    // 시작 : 인벤토리창 초기화
    void Start() 
    {
        // 초기화 진행
        inventoryItemList = new List<Item>(); //인벤토리 아이템 리스트 초기화
        // 이 둘이 결국은 같은 오브젝트인데... 클래스가 다르지만... 
        slots = tf.GetComponentsInChildren<InventorySlot>(); // 그리드의 자식객체인 slot들이 배열 slots에 들어감

        inventoryPanel.SetActive(activeInventory); //인벤토리 UI 활성화 여부

        // TEST : 아이템 획득 한 경우
        inventoryItemList.Add(new Item(1, "사탕", "놀이터 한 가운데에 떨어져 있던 사탕. 딸기맛과 레몬맛이다.", Item.ItemType.Potion));
        inventoryItemList.Add(new Item(2, "장난감방패", "만화영화 핏치피치어벤저스에서 주인공이 사용하는 방패이다.", Item.ItemType.Weapon));
    }

    void Update()
    {

        // 키보드 C를 눌러서 인벤토리 UI를 열고닫는다. 
        if (Input.GetKeyDown(KeyCode.C))
        {
            activeInventory = !activeInventory;
            inventoryPanel.SetActive(activeInventory);
        }
        // 인벤토리가 활성화 된 경우에
        // 마우스 왼쪽 버튼으로 slot을 클릭하면 정보를 확인할 수 있다.
        // 더블클릭 혹은 스페이스를 누르면 장착/사용 할 수 있다.  
        if (activeInventory)
        {
            // 아이템 슬롯에 보유 아이템을 띄운다. (아이템 활성화)
            ShowItem();
        }
    }

    // 아이템 활성화 (invenrotyItemList에 아이템들을 넣어주고, 출력)
    public void ShowItem()
    {
        // 맨 처음 selectedItem 0으로 초기화 
        selectedItem  = 0;
        // 인벤토리 아이템 리스트의 내용을, 인벤토리 슬롯에 추가 
        for(int i = 0; i < inventoryItemList.Count; i++) // 소지한 아이템의 개수만큼
        {
            // 활성화
            slots[i].gameObject.SetActive(true); 
            // slots 배열에 소지한 아이템을 넣음. 
            slots[i].AddItem(inventoryItemList[i]);
        }
    }

    // 슬롯을 마우스로 한 번 눌렀을 때 -> 아이템의 이름과 정보를 띄운다. 
    public void OnClickButton() 
    {
        // 방금 클릭한 버튼 오브젝트를 가져와서 저장
        GameObject clickedButton = EventSystem.current.currentSelectedGameObject;
        // 아이템 슬롯의 개수만큼 탐색한다. 
        for (int i =0; i < slots.Length; i++) 
        {
            // 만약 보유한 아이템의 수보다 적은 인덱스(버튼의 이름)의 슬롯 버튼을 클릭했을 때,
            // 클릭한게 i번째라면 (버튼 오브젝트의 이름을 미리 변경)
            if ((i < inventoryItemList.Count) && (clickedButton.name == ("Slot" + i)))
            {
                // 선택한 아이템의 인덱스를 i로 바꾸어 주고
                selectedItem = i;
                // selectedItem 번째의 슬롯으로 아이템 이름 및 설명 텍스트 바꾼다. 
                PrintText();
            }
            // 선택한 버튼이 아이템의 수보다 적은 인덱스의 슬롯 버튼일 때, 
            else if (clickedButton.name == ("Slot" + i))
            {
                // 빈 텍스트를 나타낸다. 
                PrintEmptyText();
            }
        }
    }

    // 아이템 이름과 설명 텍스트를 공백으로
    public void PrintEmptyText()
    {
        Debug.Log("PrintEmptyText 호출");
        NameText.text = " ";
        DescriptionText.text = " ";
    }
    // 아이템 이름과 설명을 선택한 아이템의 것으로
    public void PrintText()
    {
        Debug.Log("PrintText 호출");
        NameText.text = inventoryItemList[selectedItem].itemName; 
        DescriptionText.text = inventoryItemList[selectedItem].itemDescription; 
    }
}
