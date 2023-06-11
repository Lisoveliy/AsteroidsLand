using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidDispose : MonoBehaviour
{
    public Sprite texture;
    public void Dispose()
    {
        StartCoroutine(MakeBoom());
    }
    IEnumerator MakeBoom()
    {
        GameObject.Find("EventSystem").GetComponent<SoundEngine>().Invoke("InvokeBoom", 0);
        Destroy(GetComponent<Rigidbody2D>());
        Destroy(GetComponent<Collider2D>());
        GetComponent<SpriteRenderer>().sprite = texture;
        transform.Translate(Vector3.back);
        transform.localScale = Vector2.one * 0.2f;
        yield return new WaitForSeconds(0.2f);
        transform.localScale = Vector2.one * 0.1f;
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }
}
