using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : Singleton<GameManager>
{
    //������ �÷����ϴ� ���� ���� -> Player
    private Player player;
    public Player Player { get { return player; } set { player = value; } }

    //���ӿ��� ���Ǵ� ĳ���� -> CharacterController
    private CharacterController[] characterControllers = new CharacterController[2];

    protected override void Awake()
    {
        base.Awake();
        characterControllers[0] = Resources.Load<CharacterController>("Prefebs/Character/HanDoLee");
        
    }

    private void Start()
    {
        //ĳ���� ���ĵ� ������Ʈ ����
        Instantiate(characterControllers[0]);
    }
}
