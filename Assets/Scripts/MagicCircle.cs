using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCircle : MonoBehaviour
{
    [SerializeField] GameObject p2;
    [SerializeField] Vector2 p2Spawn;
    public void InstantiateP2()
    {
        Vector2 spawnPos = (Vector2)transform.position + p2Spawn;
        Instantiate(p2, spawnPos, Quaternion.identity);
        Destroy(this.gameObject);
    }

}
