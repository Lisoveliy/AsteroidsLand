using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public GameObject scoreLabel;
    public GameObject speedLabel;
    public GameObject player;
    private int _score = 0;
    public int score
    {
        get
        {
            return _score;
        }
        private set
        {
            if (!GetComponent<GameOver>().IsGameOver)
            {
                _score = value;
            }
        }
    }
    void Start()
    {
        UpdateLabel();
        StartCoroutine(AddScoreForTime());
        StartCoroutine(Speed());
        GameObject.Find("EventSystem").GetComponent<SoundEngine>().Invoke("InvokeStart", 0);
    }
    IEnumerator AddScoreForTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            AddScore(1000);
        }
    }
    void UpdateLabel()
    {
        scoreLabel.GetComponent<TMP_Text>().text = "Score: " + Convert.ToString(score);
    }
    void AddScore(int score)
    {
        this.score += score;
        UpdateLabel();
    }
    void AddScoreOfAsteroid()
    {
        AddScore(350);
    }

    IEnumerator Speed()
    {
        float prevX = 0;
        float prevY = 0;
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            float X = player.transform.position.x;
            float Y = player.transform.position.y;
            float speedX = (X - prevX) / 0.1f;
            float speedY = (Y - prevY) / 0.1f;
            prevX = X; prevY = Y;
            speedX = Mathf.Abs(Mathf.Round(speedX * 100) / 100);
            speedY = Mathf.Abs(Mathf.Round(speedY * 100) / 100);
            speedLabel.GetComponent<TMP_Text>().text = $"Movement speed: \nVertical: {speedY} \nHorizontal: {speedX}";
            if (speedX > 2 || speedY > 2)
            {
                speedLabel.GetComponent<TMP_Text>().text += "\nDangerous speed!";
            }
        }
    }
}
