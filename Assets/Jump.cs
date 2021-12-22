using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] private LayerMask platformLayerMask;
    BoxCollider2D boxCollider2D;
    private GameObject player, npc;

    public float JumpPower = 200.0f;
    public int JumpLevel = 2;

    private int AvailableJumpCnt = 0;

    private void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        player = GameObject.FindGameObjectWithTag(tag: "Player");

        //npc = GameObject.FindGameObjectWithTag(tag: "NPC");
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        IsGrounded();
        if (Input.GetMouseButtonDown(0) == true)
        {
            //AvailableJumpCnt > 0
            if (AvailableJumpCnt > 0) //IsGrounded())
            {
                AvailableJumpCnt--;
                player.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, JumpPower));
                //npc.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, JumpPower * 1.5f));
            }
        }
    }

    // 땅 위에 있는지 체크
    public bool IsGrounded()
    {
        float extraHeight = .1f;
        RaycastHit2D raycastHit = Physics2D.Raycast(boxCollider2D.bounds.center, Vector2.down, boxCollider2D.bounds.extents.y + extraHeight, platformLayerMask);
        Color rayColor;
        if (raycastHit.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }

        Debug.DrawRay(boxCollider2D.bounds.center, Vector2.down * (boxCollider2D.bounds.extents.y + extraHeight), rayColor);
        Debug.Log(raycastHit.collider);

        if (raycastHit.collider != null)
        {
            AvailableJumpCnt = JumpLevel; // 점프 초기화
            return true;
        }
        else
        {
            return false;
        }
    }


    // 설명
    public bool IsGrounded2()
    // ( public : 누구나 나에게 물어보라 ) 
    // ( bool : 진실인지 거짓인지 알려주마 ) 
    // ( IsGrounded(=함수의 이름) : 주인공이 땅위에 있니? )
    {
        float extraHeight = 0.1f; // 
        // float이라는 형태의 'extraheight'라는 상자(변수)를 생성하고 
        // 그안에 데이터 0.1f를 담아라!

        // 변수의 선언 (데이터를 저장하기 위함)
        // (데이터의 형태) (이름)    =   (저장할 데이터)
        // (float은 소수점을 포함하는 숫자를 말함)

        // 변수를  선언하는  예
        // ex) 인간 '김민호'   = 남성.  
        // 인간의 형태를 띄고 있는 '김민호'라는 상자를 하나 만들고! 그 안에 남성이라는 데이터를 담아라.

        // ex) 과자 '최애과자' = 홈런볼 
        // 과자의 형태를 띄고 있는 최애과자라는 상자를 하나 만들고! 그 안에 홈런볼이라는 데이터를 담아라.

        RaycastHit2D raycastHit =      // (변수의 형태 : 검침봉 검사 ) (검사의 이름 : raycastHit)
                       Physics2D.Raycast(   // 물리 관련 함수 집합(Physics2D) 에서 검침(RayCast) 함수를 꺼내서 동작시킨다.
                                boxCollider2D.bounds.center,  // 검침 시작 위치를 RayCast함수에 알려준다. ( 충돌박스의 중앙점)
                                Vector2.down,                 // 검침 방향을 RayCast함수에 알려준다. ( 아래 방향 )
                                boxCollider2D.bounds.extents.y + extraHeight,  // 검침 길이를 RayCast 함수에 알려준다. 충돌 박스의 절반길이 + 추가 검침 길이
                                platformLayerMask);  //  검침할 지형의 분류를 RayCast 함수에 알려준다.

        Color rayColor; // 검침봉 색깔 ( Color(변수 형태) rayColor(변수 이름) )
        if (raycastHit.collider != null)
        // 만약에(if) 검침봉 검사(raycastHit)의 충돌 결과(collider)가 비어있지(NULL) 않다면!
        {
            rayColor = Color.green;
            // 검침봉 색깔의 데이터를 녹색(색깔중에 녹색)으로 하여라!
        }
        else // 위의 조건에 해당하지 않는 모든 경우에는!  
        {
            rayColor = Color.red;
            // 검침봉 색깔의 데이터를 빨간색(색깔중의 빨강)으로 하여라!
        }

        Debug.DrawRay(   // 조사관(Debug)을 불러서 Ray(광선)을 발사하라고 하여라
                         boxCollider2D.bounds.center,  // 충돌박스의 중앙점으로부터
                         Vector2.down * (boxCollider2D.bounds.extents.y + extraHeight), // 아래 방향으로 충돌박스의 절반 값에 추가적인 검침봉의 길이를 더한만큼
                         rayColor); // 위에서 정한 검침봉의 색깔로!)

        Debug.Log(raycastHit.collider);
        // 조사관(Debug)을 불러서 조사일지에 기록하라고 하여라 
        // ( 검침봉이 충돌한 결과를! 
        // ex1) '땅'과 충돌했습니다. 
        // ex2) '아무것도' 충돌하지 않았습니다. )

        if (raycastHit.collider != null)
        // 만약에(if) 검침봉 검사(raycastHit)의 충돌 결과(collider)가 비어있지(NULL) 않다면!
        {
            return true;
            // 진실이라는 답변을 전해주어라!
        }
        else
        {
            return false;
            // 거짓이라는 답변을 전해주어라!
        }
    }

}
