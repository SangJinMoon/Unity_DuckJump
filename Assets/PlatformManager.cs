using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public GameObject prefab_PlatformGroup;

    Vector2 pos_WillCreatePlatformGroup;
    public float heightBetweenPlatform = 3.0f;
    private void Awake()
    {
        pos_WillCreatePlatformGroup = prefab_PlatformGroup.transform.position;
    }
    private void Start()
    {
        AddNewPlatform();
    }
    public void AddNewPlatform()
    {
        GameObject added_platformGroup = Instantiate(prefab_PlatformGroup);
        added_platformGroup.transform.position = pos_WillCreatePlatformGroup;

        pos_WillCreatePlatformGroup = new Vector2(pos_WillCreatePlatformGroup.x, pos_WillCreatePlatformGroup.y + heightBetweenPlatform);
    }
}



//public class PlatformManager : MonoBehaviour
//{
//    public GameObject prefab_PlatformGroup;  // ���縦 ���ؼ� Prefab�� �����صΰ�! AddNewPlatform�Լ��� ȣ���Ҷ�����
//                                             // prefab�� �Ȱ��� �༮�� �����Ұſ���!

//    Vector2 pos_WillCreatePlatformGroup;   // �̰Ŵ� �������� ������ '����'�� ��ġ�� �����صδ� �ſ���!
//                                           // ������ ������ ���Ǻ��� �� ���� ��ġ�� �����ϱ� ��������! 
//    public float heightBetweenPlatform = 3.0f;  // ���� ���� ����! �� ���ǻ����� ������ ���ؿ�! 3.0f ��ŭ�� 
//                                                // �����ٰ� �������ִ°���! �� ���� ���̸� �Է��ϸ� ������ �� �������ſ���!
//    private void Awake()
//    {  // Awake() �Ʊ� ��������?! ��� ���� �̴ϴ�! (�Ʒ� ��ũ ����) 
//        pos_WillCreatePlatformGroup = prefab_PlatformGroup.transform.position; // �����ص� ���� Prefab�� ��ġ��
//                                                                               // ���� ��ġ�� ���� �صΰ�!
//                                                                               // �� ��ġ�κ��� ���ݾ� ���� �����ϴ°ſ���!
//    }
//    private void Start()
//    {
//        AddNewPlatform();  // ���� ���۰� ���ÿ� ù��° '����'�� ��ġ�ϴ°���!
//    }
//    public void AddNewPlatform()
//    { // �̰� ���� �����Լ�����! 
//        GameObject added_platformGroup = Instantiate(prefab_PlatformGroup);  // Instantiate�Լ��� Prefab�� �־��ָ�!
//                                                                             // Prefab�� �Ȱ��� GameObject�� �����ϰ�!
//                                                                             // �� ��(���� ������ GameObject)�� ��ȯ�����!
//        added_platformGroup.transform.position = pos_WillCreatePlatformGroup; // ���� ������ '����'GameObject�� ��ġ�� 
//                                                                              // �Ʊ� �����ص� ��ġ�� �̵������ִ°���!
//                                                                              // transform.position�� ���� �����ϸ�!
//                                                                              // GameObject�� �̵���ų �� �־��!

//        pos_WillCreatePlatformGroup = new Vector2(pos_WillCreatePlatformGroup.x, pos_WillCreatePlatformGroup.y + heightBetweenPlatform);
//        // �̵��� ������ ������ ������ ������ ��ġ��
//        // ���� ������ �������� heightBetweenPlatform ��ŭ �����ؼ� �����صδ°���!
//        // �̷��� �ϸ� ���� ������ �����ɶ� 3.0f ��ŭ ���ʿ� �����ǰ� �ǰ���!
//    }
//}
//[��ó]
//[����Ƽ2D �ȵ���̵� ����� ���� ����� #14] Prefab & Instantiate!!|�ۼ��� ����Ƽ��

