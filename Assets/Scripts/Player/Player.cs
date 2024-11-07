using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//해당 클래스는 게임에서 유저의 데이터 및 조작을 담당합니다.
public class Player : MonoBehaviour
{
    private DeckController currentDeck; //캐릭터의 덱
    public DeckController CurrentDeck { get { return currentDeck; } }

    private void Awake()
    {
        //플레이어의 자식 오브젝트에 있는 Deck컴포넌트 호출하여 참조
        currentDeck = GetComponentInChildren<DeckController>();

        if (currentDeck == null)
        {
            Debug.Log($"{currentDeck.name}이 null 입니다. Player의 자식오브젝트를 확인해 주십시오.");
            return;
        }
    }

    private void Update()
    {
        //Debug
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log($"{currentDeck.name} 카드뽑기!");
            currentDeck.GetCard();
        }
    }


}
