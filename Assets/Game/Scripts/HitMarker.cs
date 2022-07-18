using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitMarker : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(DestroyHitMarker());
    }

    IEnumerator DestroyHitMarker()
    {
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }
}
