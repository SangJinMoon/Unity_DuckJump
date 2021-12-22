
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    public Vector2 move_dir = Vector2.right;
    public float distance = 2.0f;
    public float move_time = 4.0f;

    public bool arrived = false; // 플랫폼이 이동을 완료 했을때 Flag가 True로 되는 변수입니다.


    public void Activate(float time)
    {
        StartCoroutine(MoveInTime((Vector2)transform.position + move_dir * distance, time));
    }

    IEnumerator MoveInTime(Vector2 targetPosition, float timeLimit)
    {
        float elapseTime = 0.0f;
        Vector2 originalPosition = transform.position;
        while (elapseTime < timeLimit)
        {
            Vector2 new_pos = Vector2.Lerp(originalPosition, targetPosition, elapseTime / timeLimit);
            transform.position = new_pos;
            elapseTime += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }

        arrived = true;
    }

    //// Start is called before the first frame update
    //void Start()
    //{
    //    StartCoroutine(MoveInTime((Vector2)transform.position + move_dir * distance, move_time));
    //}

    //IEnumerator MoveInTime(Vector2 targetPosition, float timeLimit)
    //{
    //    float elapseTime = 0.0f;
    //    Vector2 originalPosition = transform.position;
    //    while (elapseTime < timeLimit)
    //    {
    //        Vector2 new_pos = Vector2.Lerp(originalPosition, targetPosition, elapseTime / timeLimit);
    //        transform.position = new_pos;
    //        elapseTime += Time.deltaTime;
    //        yield return new WaitForSeconds(Time.deltaTime);
    //    }

    //    Arrived();
    //}

    // 반대쪽으로 이동 (반복)
    //public void Arrived()
    //{
    //    move_dir *= -1.0f;
    //    StartCoroutine(MoveInTime((Vector2)transform.position + move_dir * distance, move_time));
    //}
}



//    // 설명
//    //public float move_distance = 30.0f;  // 발판은 move distance에 입력된 값만큼 이동한 후 반대 방향으로 이동하게 된다.
//    //float moved_distance = 0.0f;
//    //// 발판이 움직인 거리를 저장해 두었다가! move_distance 만큼 움직이면 값을 0으로 바꾸고 다시 move_distance만큼 움직였을 때를 체크하기 위해서 존재함.
//    //Vector2 move_dir = Vector2.right; // 발판의 최초 이동방향!
//    //public float speed = 0.5f; // 발판의 이동 속도이다. 높이면 더 빠르게 움직인다.

//    //void Update()
//    //{
//    //    Vector2 new_pos = (Vector2)transform.position + (move_dir * speed);
//    //    // 움직이려는 방향 벡터에 속력값을 곱해주면! 이번 Frame에 이동할 거리와 방향이 나온다.
//    //    // 계산 결과를 transform.position! 현재 위치에 더해주면! 
//    //    // 이동 한 후의 위치 값이 new_pos 에 저장된다.
//    //    transform.position = new_pos;  // 저장된 새로운 위치 값을! transform.position에 넣어주면! 현재 위치가 바뀌게 된다.
//    //    moved_distance += speed;
//    //    // 이번 Frame에 움직인 거리를 저장해둔다. 
//    //    // += 이라는 연산자는! a = a + b 를 축약시킨 것이다. 
//    //    // ex) a = a + b -> a += b  ||||||    c = c + d -> c += d 이런식이다!

//    //    if (moved_distance >= move_distance) // 만약에! 이동한 거리 값(moved_distance)이 미리 정해둔 이동해야할 거리 값보다 커지면!
//    //    {
//    //        moved_distance = 0.0f;  // 이동한 거리를 0으로 초기화 시켜주고!
//    //        if (move_dir == Vector2.right) // 현재 이동 방향이 Vector2.Right 오른쪽 이었다면! 
//    //        {
//    //            move_dir = Vector2.left; // 현재 이동 방향을 Vector2.Left! 왼쪽으로 바꾸어주고!
//    //        }
//    //        else if (move_dir == Vector2.left) // 만약에 이동 방향이 Vector2.Left 였다면!
//    //        {
//    //            move_dir = Vector2.right; // 오른쪽으로 바꿔주어라!
//    //        }
//    //    }
//    //}
//    //[출처]
//    //[유니티2D 안드로이드 모바일 게임 만들기 #10] Update() & transform.position [GameObject 움직이기]|작성자 유니티쳐

//}
