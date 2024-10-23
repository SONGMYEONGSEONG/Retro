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
            Debug.Log("==============시작================");

            Debug.Log("파일 이름 : " + dialogDB.Stage1[index].fileName);
            Debug.Log("해당 방향 캐릭터 ON : " + dialogDB.Stage1[index].pos);
            Debug.Log("해당 방향 캐릭터 OFF : " + dialogDB.Stage1[index].offPos);
            Debug.Log("이름 : " + dialogDB.Stage1[index].name);
            Debug.Log("내용 : " + dialogDB.Stage1[index].talkData);
            Debug.Log("대화 속도 : " + dialogDB.Stage1[index].talkSpeed);
            Debug.Log("Bgm 제목 : " + dialogDB.Stage1[index].bgmName);
            Debug.Log("Sfx 제목 : " + dialogDB.Stage1[index].sfxName);

            Debug.Log("==============끝================");
        }
    }


}
