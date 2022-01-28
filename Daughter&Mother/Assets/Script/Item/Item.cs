using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Serializable attribute 추가
// 다시 객체를 사용할 수 있도록 객체의 상태를 저장
[System.Serializable]
public class Item 
{
    public string itemName; //아이템 이름
    public string itemDescription; //아이템 설명
    public Sprite itemIcon; // 아이템 아이콘
    public ItemType itemType; // 아이템 타입
    // 아이템 타입 열거 (무기/방어구/체력회복아이템)
    public enum ItemType
    {
    Weapon,
    Shield, 
    medicine
    } 

    // 생성자
    public Item(string _itemName, string _itemDescription, ItemType _itemType)
    {
        itemName = _itemName;
        itemDescription = _itemDescription;
        itemType = _itemType;
        // itemName = itemIcon의 파일 이름임
        // Resources 폴더의 해당 스프라이트를 가져옴
        itemIcon = Resources.Load("ItemIcon/ " + _itemName.ToString(), typeof(Sprite)) as Sprite;
    }


    // 아이템 사용 여부를 반환하는 메소드
    public bool Use()
    {
        return false;
    }
}
