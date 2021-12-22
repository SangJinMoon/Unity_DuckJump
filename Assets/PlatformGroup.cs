using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGroup : MonoBehaviour
{
    Platform[] platforms;
    bool missionComplete = false;
    private void Awake()
    {
        platforms = GetComponentsInChildren<Platform>();
    }

    private void Start()
    {
        Activate();
    }

    public void Activate()
    {
        float randomPlatformMovingTime = GetRandTime();
        foreach (Platform platform in platforms)
        {
            platform.Activate(randomPlatformMovingTime);
        }
    }
    public float GetRandTime()
    {
        float minTime = 0.7f;
        float maxTime = 1.3f;
        return UnityEngine.Random.Range(minTime, maxTime);
    }

    public void Update()
    {
        if (missionComplete == false && CheckPlatformsDeactivate())
        {
            missionComplete = true;
            FindObjectOfType<PlatformManager>().AddNewPlatform();
        }
    }

    public bool CheckPlatformsDeactivate()
    {
        bool deactivate = true;
        foreach (Platform platform in platforms)
        {
            if (platform.arrived == false)
            {
                deactivate = false;
                break;
            }
        }
        return deactivate;
    }
}



//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlatformGroup : MonoBehaviour
//{
//    Platform[] platforms;   // []�� �迭�̶�� ���ε���! Platform �������� �Ѳ����� �����ϱ� ���ؼ� �ʿ��ؿ�! 'C# �迭'�̶�� �˻��غ�����~!
//    bool missionComplete = false; // platformGroup�� �ӹ��� ������ �̵����Ѽ� �ϴ��� ���°��ݾƿ�? �� �۾��� ���������� ���� ������ Ȯ���ϱ� ���ؼ� �� <bool> missionCompleted�� ����� �ſ���!
//    private void Awake() // Awake�Լ��� GameObject�� �������ڸ��� ȣ���� �Ǿ�����! 
//    {
//        platforms = GetComponentsInChildren<Platform>(); // ������������! �Ʊ� �÷����� �Ʒ��ʿ� L_platform R_Platform��
//                                                         // �־� �־���? �� �༮���� Children �ڽĵ��� �ſ���!
//                                                         // �� �ڽĵ��� ���� �ִ� ������� <Platform>�� �����Ͷ�!
//                                                         // ������ <Platform>�� platforms�� �����ض� ��� �̴ϴ�!
//                                                         // �����ϴ� ������ ���� ������ Platform�� ��� ��������
//                                                         // �����ߴ��� ���ߴ����� Ȯ���ϱ� �����̿���!
//    }

//    private void Start() // GameObject���� Awake() ������ �ڵ����� ����Ǵ� �Լ��� �ٷ� Start()�ε���!
//    {
//        Activate(); // ������ ���۵Ǹ�! Activate! ���ǵ��� Ȱ��ȭ ���Ѷ�! �̴̰ϴ�!
//    }

//    public void Activate()
//    {
//        float randomPlatformMovingTime = GetRandTime(); // �ڼ��� �����ϼ̴ٸ� �ƽð�����! 
//                                                        // ���� ���ǵ��� �������� �ӵ��� �Ź� �ٸ��� �ƽó���?
//                                                        // �װ� GetRandTime()�̶�� �Լ����� �Ź� �ٸ� float ����
//                                                        // �����Ա� �����̿���!
//        foreach (Platform platform in platforms)        // foreach�Լ��� platforms �迭�� ����� ��� platforms�� 
//                                                        // �Ѹ� ���ʷ� �����ڴٴ� ���� �ǹ��ؿ�!
//        {
//            platform.Activate(randomPlatformMovingTime);  // �׷��� ������ platform���� Ȱ��ȭ �����ִ°���!
//        }
//    }
//    public float GetRandTime()                       // �̰� Random�� Float���� ������ �ִ� �Լ�����!
//    {
//        float minTime = 0.7f;                        // �ּ� 0.7f����
//        float maxTime = 1.3f;                        // �ִ� 1.3f����!
//        return UnityEngine.Random.Range(minTime, maxTime);   //  UnityEngine�̶�� Package��
//                                                             //  Random Ŭ��������
//                                                             //  Range�Լ��� (�ּ� 0.7f �ִ� 1.3f) ���� �Ѱܼ� ȣ�� �ϸ�
//                                                             //  0.7f ~ 1.3f ������ ���� �������� �����Ϳ�!
//                                                             //  �׷��� ������ ���� return! 
//                                                             //  �Լ��� ȣ���� �༮���� �����ִ°���!
//    }

//    public void Update()
//    {
//        if (missionComplete == false && CheckPlatformsDeactivate())  // Update�Լ����� ���ǵ��� �����ߴ����� ��� üũ�ؿ�!
//                                                                     // CheckPlatformsDeactivate�� �ٷ� '��������'��
//                                                                     // Ȯ�����ִ� �Լ�����!
//                                                                     // && �̰Ŵ� And ������ ��� �θ��µ���!
//                                                                     // missionComplete == false ��� <ù��° ����>
//                                                                     // CheckPlatformDeactivate() ��� <�ι�° ����>
//                                                                     // �� ��� �����Ǿ�����
//                                                                     // if ���� �ڵ���� �����϶�� ������ �Ŵ� �ſ���! 
//                                                                     // ���� ������ �ؼ����ڸ�!
//                                                                     // ������ �̼��� �޼����� ���� ���¿���
//                                                                     // �ڽ� ���ǵ��� ��� Deactivate (����) �ߴٸ�!
//                                                                     // �ڵ带 �����϶�! ��°���!                                                                     
//        {
//            missionComplete = true;    // ������ �հ� ���Դٸ� '�̼� �޼�'�� true������ �������ְ��!
//            FindObjectOfType<PlatformManager>().AddNewPlatform(); // PlatformManager��� Object�� ã�Ƽ�! 
//                                                                  // AddNewPlatform() ���ο� ������ �߰��ض�!
//                                                                  // ��� ����� �����°̴ϴ�!
//                                                                  // ���⿡�� ���� ���ο� ������ �߰��Ǵ� ����!
//                                                                  // 1. ���� ������ �̼��� �ϼ��Ѵ�.
//                                                                  // 2. ���� ������ �����ȴ�.
//        }
//    }

//    public bool CheckPlatformsDeactivate()
//    {       // �� �ڵ尡 ��� ���ǵ��� ������� Ȯ���ϴ� �ڵ忡��!
//            // �����ؼ��غ�����! ������ʾƿ�
//        bool deactivate = true;
//        foreach (Platform platform in platforms)
//        {
//            if (platform.arrived == false)
//            {
//                deactivate = false;
//                break;
//            }
//        }
//        return deactivate;
//    }
//}