using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// MonoBehaviour을 상속 받지 않는 일반 C# 클래스의 멤버들을 유니티의 Inspector 슬롯으로 띄워주려면
[System.Serializable]
public class Stat
{
    // 스탯 속성
    protected int _HP;
    protected int _ATK;
    protected int _DEF;

    // 멤버 프로퍼티 
    public int HP {get{return _HP;} set{_HP = value;}}
    public int ATK {get{return _ATK;} set{_ATK = value;}}
    public int DEF {get{return _DEF;} set{_DEF = value;}}

    // 능력치 초기화
    private void Start()
    {
        _HP = 10;
        _ATK = 1;
        _DEF = 0;
    }
    
}
