using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyObject : MonoBehaviour
{
    private void Awake()
    {
        // 이 스크립트의 오브젝트들을 모두 불러옴
        var objs = FindObjectsOfType<DontDestroyObject>();

        // 오브젝트 : InventoryCanvas, ItemDBManager, ChatCanvas
        if (objs.Length == 3)
        {
            DontDestroyOnLoad(gameObject);
        }
        // 오브젝트가 하나 이상이라면 생성된 게임 오브젝트를 파괴
        else
        {
            Destroy(gameObject);
        }
    }
}
