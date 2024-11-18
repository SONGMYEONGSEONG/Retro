using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_DialogSelectWindow : UIBase
{
    [SerializeField] List<Text> SelectTxts;

    public void PrintSelectData(Dictionary<string, object> TalkData)
    {
        for (int i = 0; i < SelectTxts.Count; i++)
        {
            SelectTxts[i].text = TalkData["talkData"].ToString();
        }
    }
}
