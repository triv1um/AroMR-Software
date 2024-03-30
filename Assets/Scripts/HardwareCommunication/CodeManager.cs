using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CodeManager : MonoBehaviour
{
    private Dictionary<string, string> currentObjectCodes = new Dictionary<string, string>();//定义字典来存储objectName和对应的objectCode
    public TextMeshPro objectInfo;


    public void StoreCode(string objectName, string code)
    {
        if (!currentObjectCodes.ContainsKey(objectName))
        {
            currentObjectCodes.Add(objectName, code);
            Debug.Log($"Stored code {code} for object {objectName}");
        }

        objectInfo.text = GetAllCodesAsString();
    }

    public void DeleteCode(string objectName)
    {
        if (currentObjectCodes.ContainsKey(objectName))
        {
            currentObjectCodes.Remove(objectName);
            Debug.Log($"Deleted code for object {objectName}");
        }

        objectInfo.text = GetAllCodesAsString();
    }

    // 示例方法，用于获取当前存储的所有代码
    public void SendCurrentObjectCodes()
    {
        Debug.Log(GetAllCodesAsString());
    }

    public string GetAllCodesAsString()
    {
        string result = "";
        foreach (var pair in currentObjectCodes)
        {
            // 每个键值对之间用换行符分隔
            result += $"Object Name: {pair.Key}, Code: {pair.Value}\n";
        }
        return result;
    }
}
