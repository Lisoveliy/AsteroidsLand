using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
#pragma warning disable CS0108 // „лен скрывает унаследованный член: отсутствует новое ключевое слово
    public GameObject camera;
#pragma warning restore CS0108 // „лен скрывает унаследованный член: отсутствует новое ключевое слово
    public void Start()
    {
        if (PlayerPrefs.GetFloat("AsteroidSpeed") == 0)
        {
            PlayerPrefs.SetFloat("AsteroidSpeed", 1f);
        }
        UpdateSpeed();
    }
    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }
    public void ResetGame()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetFloat("AsteroidSpeed", 1f);
        UpdateSpeed();
        SceneManager.LoadScene(0);
        GetComponent<SoundEngine>().Invoke("InvokeBlast", 0);
    }
    public void ApplicationQuit()
    {
        GetComponent<SoundEngine>().Invoke("InvokeBlast", 0);
        Application.Quit();
    }
    private Color color;
    private bool increase = false;
    public void Update()
    {
        color = camera.GetComponent<Camera>().backgroundColor;
        if (increase)
        {
            color.r += 0.1f * Time.deltaTime;
            if (color.r > 0.2f)
            {
                increase = false;
            }
        }
        else
        {
            color.r -= 0.1f * Time.deltaTime;
            if (color.r <= 0f)
            {
                increase = true;
            }
        }
        camera.GetComponent<Camera>().backgroundColor = color;

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            GameObject.Find("KeyMappings").GetComponent<TMP_Text>().text = "Mappings:\nW S - Engine front and reverse\nA D - Rotation\nSpace - Blast to asteroid";
        }

        if (Input.GetKeyUp(KeyCode.Tab))
        {
            GameObject.Find("KeyMappings").GetComponent<TMP_Text>().text = "Press TAB for Key Mappings";
        }
    }
    public void SpeedDown()
    {

        float asteroidspd = PlayerPrefs.GetFloat("AsteroidSpeed");
        if (asteroidspd > 0.9f)
        {
            PlayerPrefs.SetFloat("AsteroidSpeed", asteroidspd - 0.1f);
            UpdateSpeed();
        }
        GetComponent<SoundEngine>().Invoke("InvokeBlast", 0);
    }
    public void SpeedUp()
    {

        float asteroidspd = PlayerPrefs.GetFloat("AsteroidSpeed");
        if (asteroidspd < 2.5f)
        {
            PlayerPrefs.SetFloat("AsteroidSpeed", asteroidspd + 0.1f);
            UpdateSpeed();
        }
        GetComponent<SoundEngine>().Invoke("InvokeBlast", 0);
    }
    void UpdateSpeed()
    {
        GameObject.Find("AsteroidsSpeedLabel").GetComponent<TMP_Text>().text = Convert.ToString(PlayerPrefs.GetFloat("AsteroidSpeed"));
    }

}
