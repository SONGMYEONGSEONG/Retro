using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : Singleton<GameManager>
{
    //게임을 플레이하는 유저 변수 -> Player
    private Player player;
    public Player Player { get { return player; } set { player = value; } }

    //게임에서 사용되는 캐릭터 -> CharacterController
    private CharacterController[] characterControllers = new CharacterController[2];

    protected override void Awake()
    {
        base.Awake();
        characterControllers[0] = Resources.Load<CharacterController>("Prefebs/Character/HanDoLee");
        
    }

    private void Start()
    {
        //캐릭터 스탠딩 오브젝트 생성
        Instantiate(characterControllers[0]);
    }
}
