using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    // 플레이어 게임 오브젝트
    private GameObject Player; 
    // 어떤 씬으로 이동하는 통로인지.
    public string NextScene; 

    private void Awake() 
    {
        Player = GameObject.Find("Player");
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            if (NextScene == "LivingRoom")
            {
                // 플레이어를 적당한 곳에 위치시키는 코드
                PlayerPosition();
                SceneManager.LoadScene("LivingRoom");
            }
            else if (NextScene == "BedRoom")
            {
                PlayerPosition();
                SceneManager.LoadScene("BedRoom");
            }
            else if (NextScene == "Kitchen")
            {
                PlayerPosition();
                SceneManager.LoadScene("Kitchen");   
            }
            else if (NextScene == "Road")
            {
                Player.transform.position = new Vector3(-2.5f, -2, 0);
                SceneManager.LoadScene("Road");
            }
            else if (NextScene == "Enemy1")
            {
                PlayerPosition();
                SceneManager.LoadScene("Enemy1");
            }
            else if (NextScene == "Enemy2")
            {
                PlayerPosition();
                SceneManager.LoadScene("Enemy2");
            }
            else if (NextScene == "Enemy3")
            {
                PlayerPosition();
                SceneManager.LoadScene("Enemy3");
            }
            
            
        }
    }

    // 문을 통한 씬 이동 후 위치 잡는 함수
    void PlayerPosition()
    {
        Player.transform.position = new Vector3(0, 0, 0);
    }
}
