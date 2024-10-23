using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogSelectWindow : MonoBehaviour
{
    [SerializeField] List<Text> SelectTxts;
    //ExcelImporter 사용 변수
    /*
    public void PrintSelectData(TalkData talkData)
    {
        for(int i =0; i < SelectTxts.Count; i++)
        {
            SelectTxts[i].text = talkData.talkData;
        }
    }
    */

    public void PrintSelectData(Dictionary<string,object> TalkData)
    {
        for (int i = 0; i < SelectTxts.Count; i++)
        {
            SelectTxts[i].text = TalkData["talkData"].ToString();
        }
    }
}
