using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    private void Awake()
    {
        Player playerPrefeb = Resources.Load<Player>("Prefebs/Player/Player") ;

        if (playerPrefeb != null)
        {
            //�÷��̾� ������Ʈ�� ���̾��Ű�� ���� �� ���ӸŴ����� �ʱ�ȭ
            GameManager.Instance.Player = Instantiate(playerPrefeb);
        }
        else
        {
            Debug.Log($"{gameObject.name}�� {playerPrefeb.name}�� null �Դϴ�.");
        }

    }
}
