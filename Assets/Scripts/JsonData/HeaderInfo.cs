using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class HeaderInfo
{
    public List<HeaderInfoList> data;
}

public class HeaderInfoList
{
    public string backFunctionName;
    public string titleName;
    public string button1Name;
    public string button1SpriteUrl;
    public string button1FunctionName;
    public string button2Name;
    public string button2SpriteUrl;
    public string button2FunctionName;
}
