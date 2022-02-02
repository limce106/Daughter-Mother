using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    // 아이템 리스트
    // itemList에 아이템들을 등록함
    public List<Item> itemList = new List<Item>();
    // objList에 습득 불가능한 배경 오브젝트들을 등록
    public List<Stuff> stuffList = new List<Stuff>();
    // PlayerStat
    private PlayerStat thePlayerStat;

    private void Start() {
        // PlayerStat 스크립트
        thePlayerStat = FindObjectOfType<PlayerStat>();
        // 아이템 리스트에 아이템 추가 (Add)
        itemList.Add(new Item(1, "마법봉장난감", "놀이터 한 가운데에 떨어져 있던 사탕. 딸기맛과 레몬맛이다.\n\n공격력 +15", Item.ItemType.Weapon));
        itemList.Add(new Item(2, "국자", "만화영화 핏치피치어벤저스에서 주인공이 사용하는 방패이다.\n\n공격력 +10", Item.ItemType.Weapon));
        itemList.Add(new Item(3, "가위", "만화영화 핏치피치어벤저스에서 주인공이 사용하는 방패이다.", Item.ItemType.Weapon));
        itemList.Add(new Item(4, "낡은 옷", "만화영화 핏치피치어벤저스에서 주인공이 사용하는 방패이다.", Item.ItemType.Shield));
        itemList.Add(new Item(5, "장난감방패", "만화영화 핏치피치어벤저스에서 주인공이 사용하는 방패이다.", Item.ItemType.Shield));
        itemList.Add(new Item(6, "싸구려 목걸이", "만화영화 핏치피치어벤저스에서 주인공이 사용하는 방패이다.", Item.ItemType.Shield));
        itemList.Add(new Item(7, "사과", "만화영화 핏치피치어벤저스에서 주인공이 사용하는 방패이다.", Item.ItemType.Potion));
        itemList.Add(new Item(8, "빵", "만화영화 핏치피치어벤저스에서 주인공이 사용하는 방패이다.", Item.ItemType.Potion));
        itemList.Add(new Item(9, "사탕", "놀이터 한 가운데에 떨어져 있던 사탕. 딸기맛과 레몬맛이다.", Item.ItemType.Potion));
        itemList.Add(new Item(10, "쿠키", "만화영화 핏치피치어벤저스에서 주인공이 사용하는 방패이다.", Item.ItemType.Potion));
        
        // Stuff 리스트에 오브젝트 추가 (Add) 
        // Bedroom
        stuffList.Add(new Stuff(100, "일기장", "책상위에 알록달록한 필통과 그림일기장이 놓여있다."));
        stuffList.Add(new Stuff(101, "쓰레기통", "지우개 가루와 눈높이 학습지가 버려져있다."));
        stuffList.Add(new Stuff(102, "침대", "방금까지 자고 일어난 침대이다."));
        stuffList.Add(new Stuff(103, "스탠드", "잠 자기 전에 켜놓는 노란빛의 스탠드이다."));
        // Kitchen
        stuffList.Add(new Stuff(104, "냉장고", "냉장고 안에 생크림 케이크 조각이 있다."));
        stuffList.Add(new Stuff(105, "이름", "설명"));
        stuffList.Add(new Stuff(106, "이름", "설명"));
        stuffList.Add(new Stuff(107, "이름", "설명"));
        stuffList.Add(new Stuff(108, "이름", "설명"));
        stuffList.Add(new Stuff(109, "이름", "설명"));
        stuffList.Add(new Stuff(110, "이름", "설명"));
        stuffList.Add(new Stuff(111, "이름", "설명"));
        stuffList.Add(new Stuff(112, "이름", "설명"));
        stuffList.Add(new Stuff(113, "이름", "설명"));
        stuffList.Add(new Stuff(114, "이름", "설명"));
        stuffList.Add(new Stuff(115, "이름", "설명"));
        stuffList.Add(new Stuff(116, "이름", "설명"));
        stuffList.Add(new Stuff(117, "이름", "설명"));
        stuffList.Add(new Stuff(118, "이름", "설명"));
        stuffList.Add(new Stuff(119, "이름", "설명"));
        stuffList.Add(new Stuff(120, "이름", "설명"));
        stuffList.Add(new Stuff(121, "이름", "설명"));
        stuffList.Add(new Stuff(122, "이름", "설명"));
        stuffList.Add(new Stuff(123, "이름", "설명"));
        stuffList.Add(new Stuff(124, "이름", "설명"));
    }

    public void Update() 
    {
        Debug.Log("itemList.Count : " + itemList.Count);
    }

    // 아이템을 사용했을 때의 스탯 변화
    public void UseItem(int _itemID)
    {
        switch (_itemID)
        {
            // 무기
            case 1: // 마법봉 장난감
                // 스탯을 조정하는 코드
                thePlayerStat.AKT = 15;
                break;
            case 2: // 국자
                thePlayerStat.AKT = 10;
                break;
            case 3: // 가위
                break;
            // 방어구
            case 4: // 낡은 옷
                break;
            case 5: // 장난감 방패
                break;
            case 6: // 싸구려 목걸이
                break;
            // 체력회복아이템
            case 7: // 사과
                UsePotion(10);
                break;
            case 8: // 빵
                UsePotion(15);
                break;
            case 9: // 사탕
                UsePotion(20);
                break;
            case 10: // 쿠키
                UsePotion(30);
                break;
        }
    }

    // 체력회복아이템 먹었을 때 플레이어 스탯 조정
    public void UsePotion(int power)
    {
        // 아이템 복용 후 플레이어의 최대 HP를 넘으면 안된다. 
        if (thePlayerStat.HP >= thePlayerStat.currentHP + power)
        {
            thePlayerStat.currentHP += power;
        }
        else
        {
            thePlayerStat.currentHP = thePlayerStat.HP;
        }
    }
}