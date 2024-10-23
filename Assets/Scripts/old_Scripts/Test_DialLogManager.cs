using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_DialLogManager : MonoBehaviour
{
    [SerializeField] DialogDB dialogDB;

    private void Awake()
    {

        for (int index = 0; index < dialogDB.Stage1.Count; index++)
        {
            Debug.Log("==============����================");

            Debug.Log("���� �̸� : " + dialogDB.Stage1[index].fileName);
            Debug.Log("�ش� ���� ĳ���� ON : " + dialogDB.Stage1[index].pos);
            Debug.Log("�ش� ���� ĳ���� OFF : " + dialogDB.Stage1[index].offPos);
            Debug.Log("�̸� : " + dialogDB.Stage1[index].name);
            Debug.Log("���� : " + dialogDB.Stage1[index].talkData);
            Debug.Log("��ȭ �ӵ� : " + dialogDB.Stage1[index].talkSpeed);
            Debug.Log("Bgm ���� : " + dialogDB.Stage1[index].bgmName);
            Debug.Log("Sfx ���� : " + dialogDB.Stage1[index].sfxName);

            Debug.Log("==============��================");
        }
    }


}
