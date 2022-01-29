using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // 이동 속도
    public float moveSpeed;

    // 캐릭터 콘트롤러 변수
    CharacterController cc;

    // 플레이어 체력 변수
    public int hp;

    // 최대 체력 변수
    int maxHp;

    // Hit 효과 오브젝트
    public GameObject hitEffect;

    // 애니메이터 변수
    Animator anim;

    // 플레이어 움직임 확인
    bool playerMoving;

    // 마지막 움직임 방향 확인 변수
    Vector2 lastMove;

    // 플레이어 공격 확인
    bool playerAttacking;

    // 대화창
    public ChatManager chatManager;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // 따로 방향키 누르지 않으면 플레이어는 움직이지 않음으로 설정
        playerMoving = false;

        // Z키로 공격하기
        if (Input.GetKey(KeyCode.Z))
        {
            playerAttacking = true;
            anim.SetBool("isAttack(hand)", playerAttacking);
        }
        // 대화창이 활성화된 상태라면 플레이어는 움직이지 않는다.
        if (chatManager.isAction)
        {
            playerMoving = false;
        }
        else //대화창이 활성화되지 않았다면 플레이어는 움직일 수 있다. 
        {
            // 좌우로 움직이기
            if (Input.GetAxisRaw("Horizontal") > 0f || Input.GetAxisRaw("Horizontal") < 0f)
            {
                transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
                playerMoving = true;
                lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
            }

            // 상하로 움직이기
            if (Input.GetAxisRaw("Vertical") > 0f || Input.GetAxisRaw("Vertical") < 0f)
            {
                transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
                playerMoving = true;
                lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
            }
        }
        

        anim.SetFloat("DirX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("DirY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("isMove", playerMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);
    }

    // 플레이어의 피격 함수
    public void DamageAction(int damage)
    {
        // 에너미의 공격력만큼 플레이어의 체력을 깎는다.
        hp -= damage;

        // 만일, 플레이어의 체력이 0보다 크면 피격 효과를 출력한다.
        if (hp > 0)
        {
            // 피격 이펙트 코루틴을 시작한다.
            StartCoroutine(PlayHitEffect());
        }
    }

    // 피격 효과 코루틴 함수
    IEnumerator PlayHitEffect()
    {
        // 1. 피격 UI를 활성화한다.
        hitEffect.SetActive(true);

        // 2. 0.3초간 대기한다.
        yield return new WaitForSeconds(0.3f);

        // 3. 피격 UI를 비활성화한다.
        hitEffect.SetActive(false);
    }
}
