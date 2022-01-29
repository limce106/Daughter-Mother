using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Fire : MonoBehaviour
{
    // 달고나 조각 생산할 공장
    public GameObject DalgonaFactory;

    // 발사 위치
    public GameObject firePosition;

    void Update()
    {
        // 일정 시간마다 달고나 조각을 발사하고 싶다.
        // (if문)
        // 달고나 조각 공장에서 달고나 조각을 만든다.
        if(Input.GetKey(KeyCode.F))
        {
            GameObject DalgonaPiece = Instantiate(DalgonaFactory);

            // 달고나 조각을 발사한다.(달고나 조각을 발사 위치로 가져다 놓기)
            DalgonaPiece.transform.position = firePosition.transform.position;
        }
    }
}
