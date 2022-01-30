using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    // 아이템 활성화시 true, 인벤토리창 활성화랑 같이 가져가서 써도 되지 않나?
    bool activeItem;

    // 키 입력 제한 (포션 먹을 때 확인 질문 -> 키 입력 방지)
    bool stopKetInput;
    // 중복실행 제한
    bool preventExec;

    /* 함수 */
    // 시작 : 인벤토리창 초기화
    void Start() 
    {
        // 초기화 진행
        inventoryItemList = new List<Item>(); //인벤토리 아이템 리스트 초기화
        slots = tf.GetComponentsInChildren<InventorySlot>(); // 그리드의 자식객체인 slot 프리팹들이 slots에 들어감

        inventoryPanel.SetActive(activeInventory); //인벤토리 UI 활성화

        // TEST : 아이템 획득 한 경우
        inventoryItemList.Add(new Item(1, "사탕", "놀이터 한 가운데에 떨어져 있던 사탕. 딸기맛과 레몬맛이다.", Item.ItemType.Potion));
        inventoryItemList.Add(new Item(2, "장난감방패", "만화영화 핏치피치어벤저스에서 주인공이 사용하는 방패이다.", Item.ItemType.Weapon));
    }

    void Update()
    {
        // 키 입력을 받을 수 있는 상태
        if (!stopKetInput)
        {
            // 키보드 C를 눌러서 인벤토리 UI를 열고닫는다. 
            if (Input.GetKeyDown(KeyCode.C))
            {
                activeInventory = !activeInventory;
                inventoryPanel.SetActive(activeInventory);
            }

            // 방향키로 인벤토리의 아이템들을 확인할 수 있다. 
            // 인벤토리가 활성화 된 경우에
            if (activeInventory)
            {
                // 누르는 키보드에 따라서..
                // 오른쪽 방향키 -> 인벤토리 선택
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    // 인벤토리창의 총 개수 내에서 
                    if (selectedItem < inventoryItemList.Count - 1)
                    {
                        // 인벤토리 창 한칸 오른쪽으로
                        selectedItem++;
                    }
                }
                // 왼쪽 방향키
                else if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    // 인벤토리창의 총 개수 내에서 
                    if (selectedItem > 0)
                    {
                        // 인벤토리 창 한 칸 왼쪽으로
                        selectedItem--;
                    }
                }
                // 위쪽 방향키
                else if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    // 인벤토리의 제일 윗줄에서는 제외
                    if (selectedItem > 4)
                    {
                        // 인벤토리 창 한 줄 올라감
                        selectedItem -= 4;
                    }
                }
                // 아래쪽 방향키
                else if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    // 인벤토리의 제일 아래줄에서는 제외
                    if (selectedItem < inventoryItemList.Count - 4)
                    {
                        // 인벤토리 창 한 줄 내려감
                        selectedItem += 4;
                    }
                }
                // 스페이스 혹은 엔터, 마우스 클릭 -> 장착 혹은 복용
                else if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)) && !preventExec)
                {
                    // 선택한 아이템이 포션이라면 사용 여부 선택지 
                    if (inventoryItemList[selectedItem].itemType == Item.ItemType.Potion)
                    {
                        // 키 입력을 제한한다. 포션 사용 여부를 묻기 위함
                        stopKetInput = true;
                        // 포션 사용 여부 선택지 호출
                    }
                    // 무기나 방어구라면
                    else 
                    {
                        // 장비 장착
                    }
                    
                }

                // 스페이스 혹은 엔터를 떼면
                if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.Return))
                {
                    // 다시 방향키를 사용할 수 있다. 
                    preventExec = false; 
                }
            }
        }
        

    }

    // 아이템 슬롯 초기화 (할 필요 있나?)
    public void RemoveSlot()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            // InventorySlots 초기화
            slots[i].RemoveItem();
            slots[i].gameObject.SetActive(false);
        }
    }

    // 아이템 활성화 (invenrotyItemList에 아이템들을 넣어주고, 출력)
    public void ShowItem()
    {
        // 맨 처음 selectedItem은 0번째 
        selectedItem  = 0;
        // 인벤토리 아이템 리스트의 내용을, 인벤토리 슬롯에 추가
        for(int i = 0; i < inventoryItemList.Count; i++) // 인벤토리 아이템 슬롯 개수만큼
        {
            // 활성화
            slots[i].gameObject.SetActive(true);
            // slots[i].AddItem(inventoryItemList[i]);
        }
        // 선택된 아이템 슬롯의 색상 변경
        SelectedItem();
    }

    // 선택된 아이템 슬롯의 색상 변경
    public void SelectedItem()
    {
        // 첫번째 아이템 슬롯의 색상 변경
        Color color = slots[0].selectedItem.GetComponent<Image>().color;
        color = new Color(193, 153, 243, 130);
        // 선택된 아이템 슬롯의 색상 변경
        // 선택된 아이템의 이름, 설명 텍스트를 띄움
        NameText.text = inventoryItemList[selectedItem].itemName;
        DescriptionText.text = inventoryItemList[selectedItem].itemDescription;
    }
}
