using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ColliderAssigner : MonoBehaviour
{
    public bool makeConvex = true; // 是否将碰撞体设置为凸形

    void Start()
    {
        AddCollidersToChildren();
    }

    void AddCollidersToChildren()
    {
        // 遍历所有子物体
        foreach (Transform child in transform)
        {
            MeshFilter meshFilter = child.GetComponent<MeshFilter>();
            MeshRenderer meshRenderer = child.GetComponent<MeshRenderer>();

            // 确保子物体有 Mesh Filter 和 Mesh Renderer
            if (meshFilter != null && meshRenderer != null)
            {
                // 为子物体添加 Mesh Collider
                MeshCollider meshCollider = child.gameObject.AddComponent<MeshCollider>();
                meshCollider.sharedMesh = meshFilter.sharedMesh;

                // 如果需要，设置碰撞体为凸形
                meshCollider.convex = makeConvex;
            }
        }
    }
}
