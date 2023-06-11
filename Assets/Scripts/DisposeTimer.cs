using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class DisposeTimer : MonoBehaviour
{
    public float speed = 2f;
    void Start()
    {
        Debug.Log("Timer inited");
        StartCoroutine(Dispose());
    }

    IEnumerator Dispose()
    {
        yield return new WaitForSeconds(speed);
        Debug.Log("Object Disposed");
        Destroy(gameObject);
        yield return null;
    }
}
