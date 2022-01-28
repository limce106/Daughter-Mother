using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat : MonoBehaviour
{
    // 필드
    [SerializeField]
    protected int _HP;
    [SerializeField]
    protected int _ATK;
    [SerializeField]
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
