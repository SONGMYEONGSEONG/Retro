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
        //ī�� ������Ʈ�� ǥ��
        Name.text = CardSO.Name;
        Desc.text = CardSO.Description;
        Value.text = CardSO.Value.ToString();
        if (CardSO.CardSprite != null)
        {
            renderer.sprite = CardSO.CardSprite;
        }
    }

    //ī�尡 Ŭ�� �Ǿ����� ȿ���� ���Ǵ� �޼����Դϴ�.
    public void UseCard()
    {
        Debug.Log($"{cardSO.Name} ī�� Ŭ��! ");
    }

    //ī�尡 �̵��ҽ� �����ϴ� �����Դϴ�.
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
