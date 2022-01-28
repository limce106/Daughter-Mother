using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    // 다른 클래스에서 접근 가능
    public static ItemDatabase instance;
    private void Awake() 
    {
        instance = this;
    }
    // 아이템 리스트
    public List<Item>itemDB = new List<Item>();
    // FieldItem 프리팹을 복제하는 GameObject
    public GameObject fieldItemPrefab;
    // 생성할 위치를 정하는 Vector3
    public Vector3[] pos;

    private void Start() 
    {
        // FieldItem의 item을 itemDB 중 한 개로 초기화
        GameObject go = Instantiate(fieldItemPrefab, pos[1], Quaternion.identity);
        // 랜덤으로 할 생각은 없는데...
        go.GetComponent<FieldItem>().SetItem(itemDB[Random.Range(0,3)]);
    }

}