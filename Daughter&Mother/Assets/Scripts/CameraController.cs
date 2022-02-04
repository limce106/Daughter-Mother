using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // 카메라가 따라갈 대상
    private GameObject target;
    // 카메라가 따라갈 속도
    public float moveSpeed;
    // 대상의 현재 위치
    private Vector3 targetPosition;

    void Start()
    {
        // DontDestroyOnLoad(this.gameObject); // 게임 오브젝트 파괴금지
        // 2월4일 수정
        target = GameObject.Find("Player");
    }

    void Update()
    {
        // 대상이 있는지 체크
        if (target.gameObject != null)
        {
            // this는 카메라를 의미 (z값은 카메라값을 그대로 유지)
            targetPosition.Set(target.transform.position.x, target.transform.position.y, this.transform.position.z);

            // vectorA -> B까지 T의 속도로 이동
            this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }
}
