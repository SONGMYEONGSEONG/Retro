using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectButton : MonoBehaviour
{
    public delegate void SelectButtonDelegate(int Value);
    public static event SelectButtonDelegate SelectButtonHandler;

    [SerializeField] int value = 1; //�������� ���� ��ġ

    public void Select()
    {
        SelectButtonHandler.Invoke(value);
    }
}
