using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    // 定义一个GameObject数组，用于在Unity编辑器中存储预制件
    public GameObject[] prefabs;
    // 定义生成频率（每秒生成物体的数量）
    public float spawnRate = 1f;
    // 定义抛出物体的速度
    public float speed = 5f;

    // 定义下一个生成时间点的变量
    private float nextSpawnTime;
    // 定义一个标志，表示是否应该开始生成物体
    private bool isSpawning = false;

    // 公共方法，用于开始生成物体的过程
    public void StartSpawning()
    {
        isSpawning = true; // 将生成标志设置为true
        nextSpawnTime = Time.time; // 初始化下一个生成时间点为当前时间
    }

    // 公共方法，用于停止生成物体的过程
    public void StopSpawning()
    {
        isSpawning = false; // 将生成标志设置为false
    }

    // Update每帧调用一次
    void Update()
    {
        // 检查是否应该生成物体，并且当前时间已经达到下一个生成时间点
        if (isSpawning && Time.time >= nextSpawnTime)
        {
            Spawn(); // 调用生成方法
            nextSpawnTime = Time.time + 1f / spawnRate; // 计算下一个生成时间点
        }
    }

    // 私有方法，用于生成物体
    void Spawn()
    {
        // 随机选择一个预制件索引
        int index = Random.Range(0, prefabs.Length);
        // 实例化选中的预制件，在当前GameObject的位置，并且没有旋转（Quaternion.identity）
        GameObject instance = Instantiate(prefabs[index], transform.position, Quaternion.identity);

        // 随机生成一个单位球体内的点，用于确定抛出方向
        Vector3 randomDirection = Random.insideUnitSphere.normalized;
        // 获取实例化物体的Rigidbody组件，并设置其速度为随机方向乘以速度值
        instance.GetComponent<Rigidbody>().velocity = randomDirection * speed;
    }
}
