using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    // 아이템 리스트
    // 이 곳에 아이템들을 등록함
    public List<Item> itemList = new List<Item>();

    private void Start() {
        // 아이템 리스트에 아이템 추가 (Add)
        itemList.Add(new Item("candy", "놀이터 한 가운데에 떨어져 있던 사탕. 딸기맛과 레몬맛이다.", Item.ItemType.Potion));

    }

}