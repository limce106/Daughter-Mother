using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceBlock : MonoBehaviour
{
    void Update()
    {
        EnemyController ec = GameObject.Find("Enemy").GetComponent<EnemyController>();
        // Enemy2Controller ec = GameObject.Find("Enemy2").GetComponent<Enemy2Controller>();
        // Enemy3Controller ec = GameObject.Find("Enemy3").GetComponent<Enemy3Controller>();
        if (ec.hp <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            return;
        }
    }
}
