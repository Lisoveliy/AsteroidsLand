using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathColliderTrigger : MonoBehaviour
{
    public bool EnableBlackList = false;
    public bool DisposeAsteroids = false;
    public bool AsteroidToGameOver = false;
    public GameObject[] BlackList;
    private void OnTriggerEnter2D(Collider2D other)
    {
        try
        {
            if (other.gameObject.name.Contains("SpawnedAsteroid") && DisposeAsteroids)
            {
                if (AsteroidToGameOver)
                    GameObject.Find("EventSystem").GetComponent<GameOver>().Invoke("Invoke", 0);
                Debug.Log("Asteroid detected");
                other.gameObject.GetComponent<AsteroidDispose>().Invoke("Dispose", 0);
            }
            bool isBlackListed = false;
            foreach (GameObject @object in BlackList)
            {
                isBlackListed = @object.gameObject.name.Contains(other.gameObject.name);
                if (isBlackListed)
                {
                    break;
                }
            }
            if ((EnableBlackList && isBlackListed) || !EnableBlackList)
                GameObject.Find("EventSystem").GetComponent<GameOver>().Invoke("Invoke", 0);
        }
        catch (Exception)
        {

        }
    }
}
