using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    // UI에 나타나는 요소들
    public Image icon;
    public Text itemNametext;
    public Text itemDescriptionText;
    // 아이템 선택 시 배경 색 변화
    public GameObject selectedItem;

    // 아이템을 인벤토리 UI에 추가
    public void AddItem(Item _item)
    {
        // 텍스트에 매개변수로 받은 item의 정보를 넣는다.
        itemNametext.text = _item.itemName;
        icon.sprite = _item.itemIcon;
        itemDescriptionText.text = _item.itemDescription;
    }
    // 아이템을 인벤토리 UI에서 제거
    public void RemoveItem()
    {
        // 요소들 초기화
        itemNametext.text = "";
        icon.sprite = null;
        itemDescriptionText.text = "";
    }

}
