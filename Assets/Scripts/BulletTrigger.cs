using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player" || other.gameObject.name.Contains("Bullet"))
        {
            return;
        }
        if (other.gameObject.name.Contains("SpawnedAsteroid"))
        {
            Debug.Log($"Asteroid destroyed {other.name}");
            UpdateScore();
            other.gameObject.GetComponent<AsteroidDispose>().Invoke("Dispose", 0);
        }
        Destroy(gameObject);
    }
    private void UpdateScore()
    {
        GameObject.Find("EventSystem").GetComponent<Score>().Invoke("AddScoreOfAsteroid", 0);
    }
}
