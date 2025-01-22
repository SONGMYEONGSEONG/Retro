using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : Singleton<GameManager>
{
    //게임을 플레이하는 유저 변수 -> Player
    private Player player;
    public Player Player { get { return player; } set { player = value; } }

    private CharacterController[] characterPrefebs;
    //게임에서 사용되는 캐릭터 -> CharacterController
    private List<CharacterController> characterControllers = new List<CharacterController>();

    protected override void Awake()
    {
        base.Awake();
        characterPrefebs = Resources.LoadAll<CharacterController>("Prefebs/Character");
        //캐릭터 스탠딩 오브젝트 생성
        for (int i = 0; i < characterPrefebs.Length; i++)
        {
            characterControllers.Add(Instantiate(characterPrefebs[i]));
        }
    }

    private void Start()
    {

        
    }
}
