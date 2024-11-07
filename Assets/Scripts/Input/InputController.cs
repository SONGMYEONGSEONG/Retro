using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    //static�� �׽�Ʈ ����, ���߿� �ٲ���� 
    public static event Action OnEventCardClick;
    public LayerMask CardLayerMask;
    private void Start()
    {
        Debug.Log("����");
        CardLayerMask = 1 << 8;
    }

    public void OnSelect(InputValue value)
    {
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());//ȭ�� ��ǥ�迡 �ֱ⿡ ���� ��ǥ�� ��ȯ
        RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero, 0f, CardLayerMask);

        if (hit.collider != null)
        {
            Debug.Log(hit.transform.name);

            hit.transform.GetComponent<CardController>().UseCard();

            //OnEventCardClick?.Invoke();
        }
    }
    
    /*Debug*/
    private void Update()
    {
        
    }
    /*Debug*/
}
