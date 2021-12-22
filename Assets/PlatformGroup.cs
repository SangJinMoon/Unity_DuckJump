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
//    Platform[] platforms;   // []은 배열이라는 것인데요! Platform 여러개를 한꺼번에 저장하기 위해서 필요해요! 'C# 배열'이라고 검색해보세요~!
//    bool missionComplete = false; // platformGroup의 임무는 발판을 이동시켜서 하늘을 막는거잖아요? 그 작업이 진행중인지 끝난 것인지 확인하기 위해서 이 <bool> missionCompleted를 사용한 거에요!
//    private void Awake() // Awake함수는 GameObject가 생성되자마자 호출이 되어져요! 
//    {
//        platforms = GetComponentsInChildren<Platform>(); // 생성되지마자! 아까 플랫폼의 아래쪽에 L_platform R_Platform을
//                                                         // 넣어 주었죠? 그 녀석들이 Children 자식들인 거에요!
//                                                         // 그 자식들이 갖고 있는 구성요소 <Platform>을 가져와라!
//                                                         // 가져온 <Platform>을 platforms에 저장해라 라는 겁니다!
//                                                         // 저장하는 이유는 왼쪽 오른쪽 Platform이 모두 목적지에
//                                                         // 도착했는지 안했는지를 확인하기 위함이에요!
//    }

//    private void Start() // GameObject에서 Awake() 다음에 자동으로 실행되는 함수가 바로 Start()인데요!
//    {
//        Activate(); // 게임이 시작되면! Activate! 발판들을 활성화 시켜라! 이겁니닷!
//    }

//    public void Activate()
//    {
//        float randomPlatformMovingTime = GetRandTime(); // 자세히 관찰하셨다면 아시겠지만! 
//                                                        // 현재 발판들이 몰려오는 속도가 매번 다른거 아시나요?
//                                                        // 그게 GetRandTime()이라는 함수에서 매번 다른 float 값을
//                                                        // 가져왔기 때문이에요!
//        foreach (Platform platform in platforms)        // foreach함수는 platforms 배열에 저장된 모든 platforms를 
//                                                        // 한명씩 차례로 만나겠다는 것을 의미해요!
//        {
//            platform.Activate(randomPlatformMovingTime);  // 그렇게 만나는 platform들을 활성화 시켜주는거죠!
//        }
//    }
//    public float GetRandTime()                       // 이게 Random한 Float값을 가져와 주는 함수에요!
//    {
//        float minTime = 0.7f;                        // 최소 0.7f부터
//        float maxTime = 1.3f;                        // 최대 1.3f까지!
//        return UnityEngine.Random.Range(minTime, maxTime);   //  UnityEngine이라는 Package의
//                                                             //  Random 클래스에서
//                                                             //  Range함수를 (최소 0.7f 최대 1.3f) 값을 넘겨서 호출 하면
//                                                             //  0.7f ~ 1.3f 사이의 값을 무작위로 가져와요!
//                                                             //  그렇게 가져온 값을 return! 
//                                                             //  함수를 호출한 녀석에게 돌려주는거죠!
//    }

//    public void Update()
//    {
//        if (missionComplete == false && CheckPlatformsDeactivate())  // Update함수에서 발판들이 도착했는지를 계속 체크해요!
//                                                                     // CheckPlatformsDeactivate가 바로 '도착여부'를
//                                                                     // 확인해주는 함수에요!
//                                                                     // && 이거는 And 연산자 라고 부르는데요!
//                                                                     // missionComplete == false 라는 <첫번째 조건>
//                                                                     // CheckPlatformDeactivate() 라는 <두번째 조건>
//                                                                     // 이 모두 충족되었을때
//                                                                     // if 안의 코드들을 수행하라고 조건을 거는 거에요! 
//                                                                     // 저희 조건을 해석하자면!
//                                                                     // 발판의 미션이 달성되지 않은 상태에서
//                                                                     // 자식 발판들이 모두 Deactivate (도착) 했다면!
//                                                                     // 코드를 수행하라! 라는거죠!                                                                     
//        {
//            missionComplete = true;    // 조건을 뚫고 들어왔다면 '미션 달성'을 true값으로 저장해주고요!
//            FindObjectOfType<PlatformManager>().AddNewPlatform(); // PlatformManager라는 Object를 찾아서! 
//                                                                  // AddNewPlatform() 새로운 발판을 추가해라!
//                                                                  // 라고 명령을 내리는겁니닷!
//                                                                  // 여기에서 이제 새로운 발판이 추가되는 거죠!
//                                                                  // 1. 기존 발판이 미션을 완수한다.
//                                                                  // 2. 다음 발판이 생성된다.
//        }
//    }

//    public bool CheckPlatformsDeactivate()
//    {       // 이 코드가 모든 발판들이 멈췄는지 확인하는 코드에요!
//            // 직접해석해보세요! 어렵지않아요
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