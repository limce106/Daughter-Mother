using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType 
{
    Weapons,
    Shield, 
    Consumables
}

// Serializable attribute 추가
// 다시 객체를 사용할 수 있도록 객체의 상태를 저장
[System.Serializable]
public class Item 
{
    public ItemType itemType;
    public string itemName;
    public Sprite itemImage;

    // 아이템 사용 여부를 반환하는 메소드
    public bool Use()
    {
        return false;
    }
}
