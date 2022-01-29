using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPiece : MonoBehaviour
{
    // 이동 속도
    public float speed = 3;

    void Update()
    {
        // 1. 방향을 구한다.
        Vector3 dir = Vector3.up;
        // 2. 이동하고 싶다. 공식 P = P0 + vt
        transform.position += dir * speed * Time.deltaTime;
    }
}
