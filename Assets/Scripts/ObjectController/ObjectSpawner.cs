using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject ObjectToSpawn;
    // 定义字典来存储objectName和对应的objectCode
    private Dictionary<string, string> objectCodes = new Dictionary<string, string>
    {
        {"PottedPlant(Clone)", "code1"},
        {"Forest(Clone)", "code2"},
        {"YellowBro(Clone)", "code3"}
    };
    public Transform spawnPoint;
    public CodeManager codeManager; // 添加对CodeManager的公共引用

    public void Spawn()
    {
        GameObject plant = GameObject.Instantiate(ObjectToSpawn);
        plant.transform.position = spawnPoint.position;
        // 通过名称查找游戏物体
        objectCodes.TryGetValue(plant.name, out string objectCode);
        codeManager.StoreCode(plant.name, objectCode);
    }

}
