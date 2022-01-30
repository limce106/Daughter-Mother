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
        itemList.Add(new Item(1, "마법봉장난감", "놀이터 한 가운데에 떨어져 있던 사탕. 딸기맛과 레몬맛이다.", Item.ItemType.Weapon));
        itemList.Add(new Item(2, "국자", "만화영화 핏치피치어벤저스에서 주인공이 사용하는 방패이다.", Item.ItemType.Weapon));
        itemList.Add(new Item(3, "가위", "만화영화 핏치피치어벤저스에서 주인공이 사용하는 방패이다.", Item.ItemType.Weapon));
        itemList.Add(new Item(4, "낡은 옷", "만화영화 핏치피치어벤저스에서 주인공이 사용하는 방패이다.", Item.ItemType.Shield));
        itemList.Add(new Item(5, "장난감방패", "만화영화 핏치피치어벤저스에서 주인공이 사용하는 방패이다.", Item.ItemType.Shield));
        itemList.Add(new Item(6, "싸구려 목걸이", "만화영화 핏치피치어벤저스에서 주인공이 사용하는 방패이다.", Item.ItemType.Shield));
        itemList.Add(new Item(7, "사과", "만화영화 핏치피치어벤저스에서 주인공이 사용하는 방패이다.", Item.ItemType.Potion));
        itemList.Add(new Item(8, "빵", "만화영화 핏치피치어벤저스에서 주인공이 사용하는 방패이다.", Item.ItemType.Potion));
        itemList.Add(new Item(9, "사탕", "놀이터 한 가운데에 떨어져 있던 사탕. 딸기맛과 레몬맛이다.", Item.ItemType.Potion));
        itemList.Add(new Item(10, "쿠키", "만화영화 핏치피치어벤저스에서 주인공이 사용하는 방패이다.", Item.ItemType.Potion));
    }

    public void Update() 
    {
        Debug.Log("itemList.Count : " + itemList.Count);
        // 왜 자꾸 20이 나오는 거야?
    }

}