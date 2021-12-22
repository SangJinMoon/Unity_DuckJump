
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    public Vector2 move_dir = Vector2.right;
    public float distance = 2.0f;
    public float move_time = 4.0f;

    public bool arrived = false; // �÷����� �̵��� �Ϸ� ������ Flag�� True�� �Ǵ� �����Դϴ�.


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

    // �ݴ������� �̵� (�ݺ�)
    //public void Arrived()
    //{
    //    move_dir *= -1.0f;
    //    StartCoroutine(MoveInTime((Vector2)transform.position + move_dir * distance, move_time));
    //}
}



//    // ����
//    //public float move_distance = 30.0f;  // ������ move distance�� �Էµ� ����ŭ �̵��� �� �ݴ� �������� �̵��ϰ� �ȴ�.
//    //float moved_distance = 0.0f;
//    //// ������ ������ �Ÿ��� ������ �ξ��ٰ�! move_distance ��ŭ �����̸� ���� 0���� �ٲٰ� �ٽ� move_distance��ŭ �������� ���� üũ�ϱ� ���ؼ� ������.
//    //Vector2 move_dir = Vector2.right; // ������ ���� �̵�����!
//    //public float speed = 0.5f; // ������ �̵� �ӵ��̴�. ���̸� �� ������ �����δ�.

//    //void Update()
//    //{
//    //    Vector2 new_pos = (Vector2)transform.position + (move_dir * speed);
//    //    // �����̷��� ���� ���Ϳ� �ӷ°��� �����ָ�! �̹� Frame�� �̵��� �Ÿ��� ������ ���´�.
//    //    // ��� ����� transform.position! ���� ��ġ�� �����ָ�! 
//    //    // �̵� �� ���� ��ġ ���� new_pos �� ����ȴ�.
//    //    transform.position = new_pos;  // ����� ���ο� ��ġ ����! transform.position�� �־��ָ�! ���� ��ġ�� �ٲ�� �ȴ�.
//    //    moved_distance += speed;
//    //    // �̹� Frame�� ������ �Ÿ��� �����صд�. 
//    //    // += �̶�� �����ڴ�! a = a + b �� ����Ų ���̴�. 
//    //    // ex) a = a + b -> a += b  ||||||    c = c + d -> c += d �̷����̴�!

//    //    if (moved_distance >= move_distance) // ���࿡! �̵��� �Ÿ� ��(moved_distance)�� �̸� ���ص� �̵��ؾ��� �Ÿ� ������ Ŀ����!
//    //    {
//    //        moved_distance = 0.0f;  // �̵��� �Ÿ��� 0���� �ʱ�ȭ �����ְ�!
//    //        if (move_dir == Vector2.right) // ���� �̵� ������ Vector2.Right ������ �̾��ٸ�! 
//    //        {
//    //            move_dir = Vector2.left; // ���� �̵� ������ Vector2.Left! �������� �ٲپ��ְ�!
//    //        }
//    //        else if (move_dir == Vector2.left) // ���࿡ �̵� ������ Vector2.Left ���ٸ�!
//    //        {
//    //            move_dir = Vector2.right; // ���������� �ٲ��־��!
//    //        }
//    //    }
//    //}
//    //[��ó]
//    //[����Ƽ2D �ȵ���̵� ����� ���� ����� #10] Update() & transform.position [GameObject �����̱�]|�ۼ��� ����Ƽ��

//}
