using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_StatusPopUpWIndow : MonoBehaviour
{
    private CharacterController characterController;//�ش� ĳ������ ������ �о�������� ������

    public TextMeshProUGUI AtkText;
    public TextMeshProUGUI DefText;
    public TextMeshProUGUI BufText;

    private void Awake()
    {
        characterController = GetComponentInParent<CharacterController>();

        if (characterController == null)
        {
            Debug.Log($"{characterController.name}�� Null�Դϴ�.");
        }
    }

    private void OnEnable()
    {
        AtkText.text = characterController.CharacterData.Attack.ToString();
        DefText.text = characterController.CharacterData.Defence.ToString();
    }
}
