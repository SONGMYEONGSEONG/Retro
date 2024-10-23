using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Linq;

public enum CharacterPos
{
    NONE = 0, LEFT = 1 , RIGHT = 2 , All = 3
}




public class TextFileStream : MonoBehaviour
{
    TextAsset textFile;
    StringReader stringReader;

    List<TalkData> talkDatas;

    public void Initialize()
    {
        talkDatas = new List<TalkData>();

        textFile = Resources.Load("Text/TestTalkData") as TextAsset;
        stringReader = new StringReader(textFile.text);
    }

    private bool ReadLineCheck(out string StrLine)
    {
        string aLine = stringReader.ReadLine();
        if(aLine == null) 
        {
            StrLine = "";
            return false; 
        }

        StrLine = aLine;
        return true;
    }

    public void LoadTextFile()
    {
        string[] split_text;

        while (ReadLineCheck(out string Line))
        {
            split_text = Line.Split('/');
            TalkData talkData = new TalkData();

            
            talkData.fileName = split_text[0];  
            talkData.pos = (CharacterPos)int.Parse(split_text[1]);
            talkData.offPos = (CharacterPos)int.Parse(split_text[2]);
            talkData.name = split_text[3];
            talkData.talkData = split_text[4];
            talkData.talkSpeed = float.Parse(split_text[5]);
            talkData.bgmName = split_text[6];
            talkData.sfxName = split_text[7];

            talkDatas.Add(talkData);

            //Debug.Log("파일 이름 : "  + talkDatas.Last().fileName);
            //Debug.Log("이름 : " + talkDatas.Last().name);
            //Debug.Log("내용 : " + talkDatas.Last().talkData);
            //Debug.Log("대화 속도 : " + talkDatas.Last().talkSpeed);
        }
    }

    public TalkData GetTalkData(int index)
    {
        return talkDatas[index];
    }

    public int GetTalkDataSize()
    {
        return talkDatas.Count;
    }
}
