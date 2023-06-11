using System.Collections;
using System.Threading;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    public GameObject bullet;
    public GameObject gun;
    public int speed = 500;
    Timer timer;
    // Start is called before the first frame update
    Coroutine coroutine;
    Coroutine coroutinetouch;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            coroutine = StartCoroutine(CorutineShoot());
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            StopCoroutine(coroutine);
        }
    }
    IEnumerator CorutineShoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            GameObject.Find("EventSystem").GetComponent<SoundEngine>().Invoke("InvokeBlast", 0);
            GameObject spawnedBullet = Instantiate(bullet, gun.transform);
            spawnedBullet.name = "Bullet";
            spawnedBullet.AddComponent<DisposeTimer>();
            var collider = spawnedBullet.AddComponent<BoxCollider2D>();
            collider.isTrigger = true;
            var collider2 = spawnedBullet.AddComponent<BoxCollider2D>();
            collider2.size *= 0.2f;
            var sbrb = spawnedBullet.AddComponent<Rigidbody2D>();
            sbrb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
            sbrb.gravityScale = 0;
            spawnedBullet.AddComponent<BulletTrigger>();
            sbrb.AddRelativeForce(Vector2.up * speed);
        }
    }
}
