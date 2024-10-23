using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class CardController : MonoBehaviour
{
    [SerializeField] protected DefaultCardSO cardSO;

    [SerializeField] private float moveSpeed = 2.0f;
        
    protected virtual void Awake()
    {
        //InputController.OnEventCardClick += UseCard;
    }

    private void OnEnable()
    {
        InputController.OnEventCardClick += UseCard;
    }

    //ī�尡 Ŭ�� �Ǿ����� ȿ���� ���Ǵ� �޼����Դϴ�.
    public virtual void UseCard()
    {
        Debug.Log($"{cardSO.Name} ī�� Ŭ��! , �߻�Ŭ������ ���ٵ�");


    }

    //ī�尡 �̵��ҽ� �����ϴ� �����Դϴ�.
    public void MoveCard( Vector2 end)
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
