using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//�ش� Ŭ������ ���ӿ��� ������ ������ �� ������ ����մϴ�.
public class Player : MonoBehaviour
{
    private DeckController currentDeck; //ĳ������ ��
    public DeckController CurrentDeck { get { return currentDeck; } }

    private void Awake()
    {
        //�÷��̾��� �ڽ� ������Ʈ�� �ִ� Deck������Ʈ ȣ���Ͽ� ����
        currentDeck = GetComponentInChildren<DeckController>();

        if (currentDeck == null)
        {
            Debug.Log($"{currentDeck.name}�� null �Դϴ�. Player�� �ڽĿ�����Ʈ�� Ȯ���� �ֽʽÿ�.");
            return;
        }
    }

    private void Update()
    {
        //Debug
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log($"{currentDeck.name} ī��̱�!");
            currentDeck.GetCard();
        }
    }


}
