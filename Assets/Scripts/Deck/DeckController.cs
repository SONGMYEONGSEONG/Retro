using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct CardPos
{
    public bool IsCard;
    public Vector2 Position;
}

//ī�带 �����̳ʷ� �����ϰ� �ְ� ���� ī�带 ���忡 �������ִ� Ŭ�����Դϴ�.
public class DeckController : MonoBehaviour
{
    public Queue<CardController> Deck = new Queue<CardController>();
    public DeckSO deckListData;

    [SerializeField] private CardPos[] cardPositions; //ī�尳 ��ġ�Ǵ� ��ǥ�� ��ġ
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

    //CardDataSeeting ����Դϴ�. ����׸������� ����ϴ°Ŷ� ������ �ʿ��մϴ�.
    private void DebugCardDataSetting()
    {

    }

    public CardController GetCard()
    {
        if(Deck.Count <= 0)
        {
            Debug.Log("Deck�� ī�尡 �����ϴ�.");
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
