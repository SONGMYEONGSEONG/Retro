using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "DeckSO", menuName = "DeckSO/DefaultDeck", order = 0)]
public class DeckSO : ScriptableObject
{
    public int CardCount = 20; //덱의 총 카드 갯수
    public List<DefaultCardSO> cards; // 덱의 카드데이터를 저장하는 컨테이너
}
