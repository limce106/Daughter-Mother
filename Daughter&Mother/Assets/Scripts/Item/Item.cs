using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// MonoBehaviour을 상속 받지 않는 일반 C# 클래스의 멤버들을 유니티의 Inspector 슬롯으로 띄워주려면
[System.Serializable]
public class Item 
{
    // 아이템 속성
    public string itemName; //아이템 이름(ID역할)
    public string itemDescription; //아이템 설명(대화창, 인벤토리창)
    public Sprite itemIcon; //아이템 이미지
    public ItemType itemType; //아이템 종류 중 1가지 값을 가짐

    // 아이템타입 열거 (무기, 방어구, 체력회복아이템)
    public enum ItemType
    {
        Weapon,
        Shield,
        Potion
    }

    // 생성자
    public Item(string _itemName, string _itemDescription, ItemType _itemType)
    {
        // 아이템 속성 초기화 
        itemName = _itemName;
        itemDescription = _itemDescription;
        itemType = _itemType;
        // resources 파일 내부에 있는 파일의 이름 = 아이템의 이름
        // resources 파일에 있는 이미지를 가져온다. 
        itemIcon = Resources.Load("ItemIcon/" + _itemName, typeof(Sprite)) as Sprite;
    }

    // 아이템 사용 여부를 반환하는 메소드
    public bool Use()
    {
        return false;
    }
}