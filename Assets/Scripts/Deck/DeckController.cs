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
    public Queue<CardController> Deck = new Queue<CardController>();
    public DeckSO deckListData;

    [SerializeField] private CardPos[] cardPositions; //카드개 배치되는 좌표의 위치
    private int index = 0;

    private void Start()
    {
        if (deckListData == null)
        {
            deckListData = Resources.Load<DeckSO>("ScriptableObject/DeckSO");
        }

        for (int i = 0; i < deckListData.CardCount; i++)
        {
            CardController deckCard = CardCreateManager.Instance.CreateCard(deckListData.cards[i]);
            
            Deck.Enqueue(deckCard);
        }

    }

    //CardDataSeeting 기능입니다. 디버그목적으로 사용하는거라 수정이 필요합니다.
    private void DebugCardDataSetting()
    {

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
