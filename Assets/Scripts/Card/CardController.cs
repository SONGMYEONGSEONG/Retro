using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;



public class CardController : MonoBehaviour
{
    public TextMeshPro Name;
    public TextMeshPro Desc;
    public TextMeshPro Value;

    [SerializeField] private DefaultCardSO cardSO;
    public DefaultCardSO CardSO { get => cardSO; set => cardSO = value; }

    [SerializeField] private float moveSpeed = 2.0f;
    [SerializeField] private SpriteRenderer renderer;

    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        InputController.OnEventCardClick += UseCard;
    }

    public void CardDataPrint()
    {
        //카드 오브젝트에 표기
        Name.text = CardSO.Name;
        Desc.text = CardSO.Description;
        Value.text = CardSO.Value.ToString();
        if (CardSO.CardSprite != null)
        {
            renderer.sprite = CardSO.CardSprite;
        }
    }

    //카드가 클릭 되었을때 효과가 사용되는 메서드입니다.
    public void UseCard()
    {
        Debug.Log($"{cardSO.Name} 카드 클릭! ");
    }

    //카드가 이동할시 동작하는 로직입니다.
    public void MoveCard(Vector2 end)
    {
        StartCoroutine(CardMove(transform.position, end, moveSpeed));
    }

    private void Update()
    {

    }
    private void OnDisable()
    {
        InputController.OnEventCardClick -= UseCard;
    }

    IEnumerator CardMove(Vector2 start, Vector2 end, float Speed)
    {
        float elspedTime = 0f;
        while (Vector2.Distance(transform.position, end) > 0.1f)
        {
            elspedTime += Time.deltaTime;
            transform.position = Vector2.Lerp(start, end, Speed * elspedTime);

            yield return null;
        }

    }
}
