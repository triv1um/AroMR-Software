using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TogglePoke : MonoBehaviour
{
    private Toggle toggle;
    private ObjectSpawner PT;
    void Start()
    {
        toggle = GetComponent<Toggle>();
        PT = GetComponent<ObjectSpawner>();
        toggle.onValueChanged.AddListener(OnToggleValueChanged);
    }

    private void OnToggleValueChanged(bool isOn)
    {
        // 检查Toggle的新值是否为true（选中状态）
        if (isOn)
        {
            PT.Spawn();
        }
    }
}
