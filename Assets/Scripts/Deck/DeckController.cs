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
    //[SerializeField] private int cardMax = 20;//���� �����ִ� ī�� �ִ� �ż�
    public Queue<CardController> Deck;

    [SerializeField] private CardPos[] cardPositions; //ī�尳 ��ġ�Ǵ� ��ǥ�� ��ġ
    private int index = 0;

    /*Debug*/
    [SerializeField] private CardController[] cardList; //�׽�Ʈ������ ����ϴ� ī�帮��Ʈ
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
