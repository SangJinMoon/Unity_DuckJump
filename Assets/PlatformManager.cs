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
//    public GameObject prefab_PlatformGroup;  // 복사를 위해서 Prefab을 저장해두고! AddNewPlatform함수를 호출할때마다
//                                             // prefab과 똑같은 녀석을 생성할거에요!

//    Vector2 pos_WillCreatePlatformGroup;   // 이거는 다음번에 생성될 '발판'의 위치를 저장해두는 거에요!
//                                           // 저번에 생성된 발판보다 더 높은 위치에 생성하기 위함이죠! 
//    public float heightBetweenPlatform = 3.0f;  // 높이 사이 발판! 즉 발판사이의 간격을 말해요! 3.0f 만큼씩 
//                                                // 위에다가 생성해주는거죠! 더 높은 사이를 입력하면 간격이 더 벌어질거에요!
//    private void Awake()
//    {  // Awake() 아까 설명드렸죠?! 계속 나올 겁니닷! (아래 링크 참고) 
//        pos_WillCreatePlatformGroup = prefab_PlatformGroup.transform.position; // 저장해둔 발판 Prefab의 위치를
//                                                                               // 최초 위치로 저장 해두고!
//                                                                               // 이 위치로부터 조금씩 위에 생성하는거에요!
//    }
//    private void Start()
//    {
//        AddNewPlatform();  // 게임 시작과 동시에 첫번째 '발판'을 설치하는거죠!
//    }
//    public void AddNewPlatform()
//    { // 이게 발판 생성함수에요! 
//        GameObject added_platformGroup = Instantiate(prefab_PlatformGroup);  // Instantiate함수에 Prefab을 넣어주면!
//                                                                             // Prefab과 똑같은 GameObject를 생성하고!
//                                                                             // 그 값(새로 생성된 GameObject)을 반환해줘요!
//        added_platformGroup.transform.position = pos_WillCreatePlatformGroup; // 새로 생성된 '발판'GameObject의 위치를 
//                                                                              // 아까 저장해둔 위치로 이동시켜주는거죠!
//                                                                              // transform.position의 값을 조절하면!
//                                                                              // GameObject를 이동시킬 수 있어요!

//        pos_WillCreatePlatformGroup = new Vector2(pos_WillCreatePlatformGroup.x, pos_WillCreatePlatformGroup.y + heightBetweenPlatform);
//        // 이동이 끝나면 다음에 생성될 발판의 위치를
//        // 현재 생성된 지점보다 heightBetweenPlatform 만큼 높게해서 저장해두는거죠!
//        // 이렇게 하면 다음 발판이 생성될때 3.0f 만큼 위쪽에 생성되게 되겠죠!
//    }
//}
//[출처]
//[유니티2D 안드로이드 모바일 게임 만들기 #14] Prefab & Instantiate!!|작성자 유니티쳐

