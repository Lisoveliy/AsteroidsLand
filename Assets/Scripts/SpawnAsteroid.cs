using System;
using System.Collections;
using UnityEngine;

public class SpawnAsteroid : MonoBehaviour
{
    public float SpawnSpeed = 0.3f;
    public float MovementSpeed = 50f;
    public GameObject spawner;
    public GameObject asteroid;
    void Start()
    {
        StartCoroutine(SpawnAsteroidCorutine());
        MovementSpeed *= PlayerPrefs.GetFloat("AsteroidSpeed");
    }
    IEnumerator SpawnAsteroidCorutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(SpawnSpeed);
            UnityEngine.Random.InitState(DateTime.Now.Millisecond);
            int randCount = UnityEngine.Random.Range(0, 100);
            randCount = randCount < 30 ? 0 : Mathf.RoundToInt(randCount / 30);
            for (int i = 0; i < randCount; i++)
            {
                int rand = UnityEngine.Random.Range(-800, 800);
                Vector2 SpawnerLocation = spawner.transform.position;
                SpawnerLocation += new Vector2((float)rand / 100, 0);
                Debug.Log($"Spawn astroid on {SpawnerLocation}");
                var asteroidGO = Instantiate(asteroid, SpawnerLocation, Quaternion.identity);
                asteroidGO.name = "SpawnedAsteroid";
                var rb = asteroidGO.AddComponent<Rigidbody2D>();
                asteroidGO.AddComponent<CircleCollider2D>();
                //ﬂ Õ≈ «Õ¿¿¿¿¿¿¿¿¿¿¿¿ﬁ œŒ◊≈Ã””
                float angle = Vector2.SignedAngle(new Vector2(0, 1), SpawnerLocation);
                Debug.Log(angle);
                rb.rotation += angle / 2;
                rb.gravityScale = 0;
                rb.AddRelativeForce(Vector2.down * MovementSpeed);
            }
        }
    }
}
