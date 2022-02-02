using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    // 인스턴스 만들기
    public static PlayerStat instance;

    // 플레이어 속성
    public int HP;
    public int currentHP;
    public int AKT;
    public int DEF;
    public Item weapon; 
    public Item shield; 

    void Start() 
    {
        instance = this;
    }

    // Enemy에게 공격당했을 때
    public void Hit(int _enemyAtk) 
    {
        // 에너미 공격력 에서 플레이어 방어력을 제외한 만큼 데미지를 입음
        int dmg = _enemyAtk - DEF;
        currentHP -= dmg;
        // HP 0 -> 게임 오버
        if (currentHP < 0)
        {
            // 1초동안 화면 멈추기
            // 페이드 아웃
            // 게임오버 씬 불러오기
            Debug.Log("체력 0미만, 게임오버!!!");
            // 플레이어 스탯 초기화하기
            // 인벤토리 초기화 하기
            // 혹은 세이브 포인트에서 시작하기
        }

        // 데미지 입었을 때 음향, 이미지 효과들 적용

    }
}
