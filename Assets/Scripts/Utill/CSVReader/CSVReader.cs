using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class CSVReader
{
    static string SPLIT_RE = @",(?=(?:[^""]*""[^""]*"")*(?![^""]*""))";
    static string LINE_SPLIT_RE = @"\r\n|\n\r|\n|\r";
    static char[] TRIM_CHARS = { '\"' };

    public static List<Dictionary<string, object>> Read(string file)
    {
        List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
        TextAsset data = Resources.Load(file) as TextAsset;

        string[] lines = Regex.Split(data.text, LINE_SPLIT_RE);

        if (lines.Length <= 1) return list;

        string[] header = Regex.Split(lines[0], SPLIT_RE);
        for (int i = 1; i < lines.Length; i++)
        {

            string[] values = Regex.Split(lines[i], SPLIT_RE);
            if (values.Length == 0 || values[0] == "") continue;

            Dictionary<string, object> entry = new Dictionary<string, object>();
            for (int j = 0; j < header.Length && j < values.Length; j++)
            {
                string value = values[j];
                value = value.TrimStart(TRIM_CHARS).TrimEnd(TRIM_CHARS).Replace("\\", "");
                object finalvalue = value;

                int n;
                float f;
                bool b;
                if (int.TryParse(value, out n))
                {
                    finalvalue = n;
                }
                else if (float.TryParse(value, out f))
                {
                    finalvalue = f;
                }
                else if (bool.TryParse(value, out b))
                {
                    finalvalue = b;
                }
                entry[header[j]] = finalvalue;
            }
            list.Add(entry);
        }
        return list;
    }
}
