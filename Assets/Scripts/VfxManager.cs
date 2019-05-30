using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VfxManager : Singleton<VfxManager>
{
    ///TODO: Implement object pooling with indexed effects
    public GameObject SpawnEffect(GameObject effectPrefab, Vector3 position, float time = 1)
    {
        GameObject effectInstance = Instantiate(effectPrefab, position, Quaternion.identity, transform);
        StartCoroutine(DestroyCoroutine(effectInstance, time));

        return effectInstance;
    }

    private IEnumerator DestroyCoroutine(GameObject instance, float time)
    {
        yield return new WaitForSeconds(time);
        if(instance != null)
        {
            Destroy(instance);
        }
    }
}