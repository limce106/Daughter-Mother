using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Fire : MonoBehaviour
{
    // 달고나 조각 생산할 공장
    public GameObject DalgonaFactory;
    // 발사 위치
    public GameObject firePosition; 

    //현재시간
    float currentTime;
    //일정시간
    public float createTime = 5;
    
    void Update()
    {
        // 일정 시간마다 달고나 조각을 발사하고 싶다.
        // (if문)
        // 달고나 조각 공장에서 달고나 조각을 만든다.

        //1.시간이 흐르다가
        currentTime += Time.deltaTime;
        //2.만약 현재시간이 일정시간이 되면
        if (currentTime > createTime)
        {
            //총알 공장에서 총알을 만든다.
            GameObject bullet = Instantiate(DalgonaFactory);
            //총알을 발사한다
            bullet.transform.position = firePosition.transform.position;
            //현재시간을 0으로 초기화
            currentTime = 0;
        }
    }
}
