using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_SelectButton : UIBase
{
    //public delegate void SelectButtonDelegate(int Value);
    //public static event SelectButtonDelegate SelectButtonHandler;

    public static event Action<int> SelectButtonHandler;

    [SerializeField] int value = 1; //선택지에 대한 가치

    public void Select()
    {
        SelectButtonHandler?.Invoke(value);
    }


}
