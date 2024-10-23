using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private DeckController currentDeck;

    private void Awake()
    {
        if(currentDeck == null)
        {
            currentDeck = GetComponentInChildren<DeckController>();
            Debug.Log($"{currentDeck.name} 컴포넌트 활성화!");
        }
        
    }

    private void Update()
    {
        /*Debug*/
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log($"{currentDeck.name} 카드뽑기!");
            currentDeck.GetCard();
        }
    }
}
