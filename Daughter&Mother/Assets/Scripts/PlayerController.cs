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

    // 플레이어 공격력
    public int attackPower = 3;

    // 플레이어 방어력
    public int defendPower;

    float currentAttackDelay;

    // 공격 딜레이 시간
    public float attackDelay = 1f;

    public GameObject Player;
    public GameObject Enemy;

    // 대화창
    public ChatManager chatManager;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        Attack();
        ChangeObject();
    }

    void Move()
    {
        // 따로 방향키 누르지 않으면 플레이어는 움직이지 않음으로 설정
        playerMoving = false;
        playerAttacking = false;

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
                // 만일, 플레이어의 hp가 0 이하라면...
                if (hp <= 0)
                {
                    // 플레이어의 애니메이션을 멈춘다.
                    anim.SetBool("isMove", false);
                    anim.SetBool("isAttack", false);
                }
                else
                {
                    transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
                    playerMoving = true;
                    lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
                }
            }

            // 상하로 움직이기
            if (Input.GetAxisRaw("Vertical") > 0f || Input.GetAxisRaw("Vertical") < 0f)
            {
                // 만일, 플레이어의 hp가 0 이하라면...
                if (hp <= 0)
                {
                    // 플레이어의 애니메이션을 멈춘다.
                    anim.SetBool("isMove", false);
                    anim.SetBool("isAttack", false);
                }
                else
                {
                    transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
                    playerMoving = true;
                    lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
                }
            }
        }
        

        anim.SetFloat("DirX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("DirY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("isMove", playerMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);
    }

    void Attack()
    {
        playerMoving = false;
        playerAttacking = false;
        EnemyController ec = GameObject.Find("Enemy").GetComponent<EnemyController>();
        // Enemy2Controller ec = GameObject.Find("Enemy").GetComponent<Enemy2Controller>();
        // Enemy3Controller ec = GameObject.Find("Enemy").GetComponent<Enemy3Controller>();

        if (Input.GetKeyDown(KeyCode.Z))
        {
            currentAttackDelay = attackDelay;
            // 공격 애니메이션 활성화
            playerAttacking = true;
            playerMoving = false;
            anim.SetFloat("DirX", Input.GetAxisRaw("Horizontal"));
            anim.SetFloat("DirY", Input.GetAxisRaw("Vertical"));
            anim.SetBool("isAttack", playerAttacking);
            if (Input.GetAxisRaw("Horizontal") > 0f || Input.GetAxisRaw("Horizontal") < 0f)
            {
                transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
                playerMoving = true;
                lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
            }
            // 플레이어와 에너미의 거리가 1보다 작을 때 플레이어가 공격하면
            if (Vector2.Distance(Player.transform.position, Enemy.transform.position) <= 1)
            {
                // 에너미의 hp가 플레이어의 공격력만큼 줄어든다.
                ec.hp -= attackPower;
            }
            // 막타를 치면(에너미의 hp가 0이면) 기억 장면을 불러온다.
            if (ec.hp <= 0)
            {
                StartCoroutine(LastHitProcess());
            }
        }

        else
        {
            currentAttackDelay -= Time.deltaTime;
            if (currentAttackDelay <= 0)
            {
                anim.SetBool("isAttack", false);
                playerAttacking = false;
            }
        }
    }

    IEnumerator LastHitProcess()
    {
        EnemyController ec = GameObject.Find("Enemy").GetComponent<EnemyController>();
        // Enemy2Controller ec = GameObject.Find("Enemy").GetComponent<Enemy2Controller>();
        // Enemy3Controller ec = GameObject.Find("Enemy").GetComponent<Enemy3Controller>();

        yield return new WaitForSeconds(0.5f);

        // 1. 기억 장면 UI를 활성화한다.
        ec.memory.SetActive(true);

        // 2. 5초간 대기한다.
        yield return new WaitForSeconds(5f);

        // 3. 기억 장면 UI를 비활성화한다.
        ec.memory.SetActive(false);
    }

    // 플레이어의 피격 함수
    public void DamageAction(int damage)
    {
        // 에너미의 공격력만큼 플레이어의 체력을 깎는다.
        hp -= damage - defendPower;

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

    void ChangeObject()
    {
        // 임의로 M을 누를 시 마법봉을 지니도록 함.
        // 이후 인벤토리에서 마법봉 선택 시 마법봉을 지니는 애니메이션으로 변경되도록 조건을 수정해야 함.
        if(Input.GetKeyDown(KeyCode.M))
        {
            anim.SetBool("isChange", true);
            attackPower = 5;
        }
        else
        {
            return;
        }
    }
}
