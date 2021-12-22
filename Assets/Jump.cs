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

    // �� ���� �ִ��� üũ
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
            AvailableJumpCnt = JumpLevel; // ���� �ʱ�ȭ
            return true;
        }
        else
        {
            return false;
        }
    }


    // ����
    public bool IsGrounded2()
    // ( public : ������ ������ ����� ) 
    // ( bool : �������� �������� �˷��ָ� ) 
    // ( IsGrounded(=�Լ��� �̸�) : ���ΰ��� ������ �ִ�? )
    {
        float extraHeight = 0.1f; // 
        // float�̶�� ������ 'extraheight'��� ����(����)�� �����ϰ� 
        // �׾ȿ� ������ 0.1f�� ��ƶ�!

        // ������ ���� (�����͸� �����ϱ� ����)
        // (�������� ����) (�̸�)    =   (������ ������)
        // (float�� �Ҽ����� �����ϴ� ���ڸ� ����)

        // ������  �����ϴ�  ��
        // ex) �ΰ� '���ȣ'   = ����.  
        // �ΰ��� ���¸� ��� �ִ� '���ȣ'��� ���ڸ� �ϳ� �����! �� �ȿ� �����̶�� �����͸� ��ƶ�.

        // ex) ���� '�־ְ���' = Ȩ���� 
        // ������ ���¸� ��� �ִ� �־ְ��ڶ�� ���ڸ� �ϳ� �����! �� �ȿ� Ȩ�����̶�� �����͸� ��ƶ�.

        RaycastHit2D raycastHit =      // (������ ���� : ��ħ�� �˻� ) (�˻��� �̸� : raycastHit)
                       Physics2D.Raycast(   // ���� ���� �Լ� ����(Physics2D) ���� ��ħ(RayCast) �Լ��� ������ ���۽�Ų��.
                                boxCollider2D.bounds.center,  // ��ħ ���� ��ġ�� RayCast�Լ��� �˷��ش�. ( �浹�ڽ��� �߾���)
                                Vector2.down,                 // ��ħ ������ RayCast�Լ��� �˷��ش�. ( �Ʒ� ���� )
                                boxCollider2D.bounds.extents.y + extraHeight,  // ��ħ ���̸� RayCast �Լ��� �˷��ش�. �浹 �ڽ��� ���ݱ��� + �߰� ��ħ ����
                                platformLayerMask);  //  ��ħ�� ������ �з��� RayCast �Լ��� �˷��ش�.

        Color rayColor; // ��ħ�� ���� ( Color(���� ����) rayColor(���� �̸�) )
        if (raycastHit.collider != null)
        // ���࿡(if) ��ħ�� �˻�(raycastHit)�� �浹 ���(collider)�� �������(NULL) �ʴٸ�!
        {
            rayColor = Color.green;
            // ��ħ�� ������ �����͸� ���(�����߿� ���)���� �Ͽ���!
        }
        else // ���� ���ǿ� �ش����� �ʴ� ��� ��쿡��!  
        {
            rayColor = Color.red;
            // ��ħ�� ������ �����͸� ������(�������� ����)���� �Ͽ���!
        }

        Debug.DrawRay(   // �����(Debug)�� �ҷ��� Ray(����)�� �߻��϶�� �Ͽ���
                         boxCollider2D.bounds.center,  // �浹�ڽ��� �߾������κ���
                         Vector2.down * (boxCollider2D.bounds.extents.y + extraHeight), // �Ʒ� �������� �浹�ڽ��� ���� ���� �߰����� ��ħ���� ���̸� ���Ѹ�ŭ
                         rayColor); // ������ ���� ��ħ���� �����!)

        Debug.Log(raycastHit.collider);
        // �����(Debug)�� �ҷ��� ���������� ����϶�� �Ͽ��� 
        // ( ��ħ���� �浹�� �����! 
        // ex1) '��'�� �浹�߽��ϴ�. 
        // ex2) '�ƹ��͵�' �浹���� �ʾҽ��ϴ�. )

        if (raycastHit.collider != null)
        // ���࿡(if) ��ħ�� �˻�(raycastHit)�� �浹 ���(collider)�� �������(NULL) �ʴٸ�!
        {
            return true;
            // �����̶�� �亯�� �����־��!
        }
        else
        {
            return false;
            // �����̶�� �亯�� �����־��!
        }
    }

}
