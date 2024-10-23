using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct CardPos
{
    public bool IsCard;
    public Vector2 Position;
}

//카드를 컨테이너로 저장하고 있고 사용시 카드를 월드에 생성해주는 클래스입니다.
public class DeckController : MonoBehaviour
{
    //[SerializeField] private int cardMax = 20;//덱에 들어갈수있는 카드 최대 매수
    public Queue<CardController> Deck;

    [SerializeField] private CardPos[] cardPositions; //카드개 배치되는 좌표의 위치
    private int index = 0;

    /*Debug*/
    [SerializeField] private CardController[] cardList; //테스트용으로 사용하는 카드리스트
    /*Debug*/



    private void Awake()
    {
        Deck = new Queue<CardController>();
        

        //for(int i = 0; i < cardMax; i++)
        for(int i = 0; i < cardList.Length; i++)
        {
            CardController card = Instantiate(cardList[i], transform);
            card.gameObject.SetActive(false);
            Deck.Enqueue(card); 
        }
    }

    public CardController GetCard()
    {
        if(Deck.Count <= 0)
        {
            Debug.Log("Deck에 카드가 없습니다.");
            return null;
        }

        CardController card = Deck.Dequeue();
        card.gameObject.SetActive(true);

        cardPositions[index].IsCard = true;
        card.MoveCard(cardPositions[index].Position);
        index++;
        return card;
    }


}
