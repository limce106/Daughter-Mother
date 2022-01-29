using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldItem : MonoBehaviour
{
    // 어떤 아이템인지
    public Item item; 
    // 아이템에 맞는 이미지
    public SpriteRenderer image; 

    // 아이템을 선택할 때 현재의 Item으로 초기화하는 매소드
    public void SetItem(Item _item)
    {
        item.itemName = _item.itemName; 
        item.itemIcon = _item.itemIcon; 
        item.itemType = _item.itemType; 
        // 아이템에 맞춰서 sprite도 바꿈
        image.sprite = item.itemIcon; 
    }

    // 아이템을 획득했을 때
    public Item GetItem()
    {
        return item;
    }

    // 아이템을 획득하면 필드에서 아이템 파괴
    public void DestroyItem()
    {
        Destroy(gameObject);
    }
    
}
