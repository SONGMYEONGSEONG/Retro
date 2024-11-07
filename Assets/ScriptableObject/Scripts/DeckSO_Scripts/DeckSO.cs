using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "DeckSO", menuName = "DeckSO/DefaultDeck", order = 0)]
public class DeckSO : ScriptableObject
{
    public int CardCount = 20;
    public List<DefaultCardSO> cards;
}
