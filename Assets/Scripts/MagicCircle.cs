using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCircle : MonoBehaviour
{

    public static MagicCircle instance;

    [SerializeField] GameObject p2;
    [SerializeField] Vector2 p2Spawn;
    bool invoked;

    private void Awake() => instance = this;

    private void OnDestroy() => instance = null;

    private void Start() => invoked = false;





    public void InstantiateP2()
    {
        if (invoked) return;
        Vector2 spawnPos = (Vector2)transform.position + p2Spawn;
        Transform parent = P1AnimationHandler.instance.transform;
        Instantiate(p2, spawnPos, Quaternion.identity);
        transform.parent = parent;
        invoked = true;

    }
    public void DestroyPortal() => Destroy(this.gameObject);
}
