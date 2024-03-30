using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEmoji : MonoBehaviour
{
    public GameObject emojiPrefab;

    public GameObject SpawnPoint;

    public void Spawn()
    {
        Transform spawnPoint = SpawnPoint.transform;
        Instantiate(emojiPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
