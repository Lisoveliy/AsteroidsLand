using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverLabel;
    public GameObject gameOverTitleLabel;
    public GameObject player;
    public GameObject Reset;
    public GameObject Exit;
    public Sprite DeathTexture;
    public bool IsGameOver { private set; get; } = false;
    public void Invoke()
    {
        if (!IsGameOver)
        {
            GameObject.Find("EventSystem").GetComponent<SoundEngine>().Invoke("InvokeEnd", 0);
            IsGameOver = true;
            Debug.LogWarning("GameOver Invoked");
            gameOverLabel.SetActive(true);
            StartCoroutine(InvokeTitleAndRemovePlayer());
            try
            {
                if (PlayerPrefs.GetInt("Score") < GetComponent<Score>().score)
                    PlayerPrefs.SetInt("Score", GetComponent<Score>().score);
            }
            catch (Exception)
            {

            }
        }
    }
    IEnumerator InvokeTitleAndRemovePlayer()
    {
#if UNITY_ANDROID
        GameObject.Find("LeftRot").SetActive(false);
        GameObject.Find("RightRot").SetActive(false);
        GameObject.Find("Up").SetActive(false);
        GameObject.Find("Down").SetActive(false);
        GameObject.Find("Blast").SetActive(false);
        GameObject.Find("Pause").SetActive(false);
        Reset.SetActive(true);
        Exit.SetActive(true);
#endif
        Destroy(player.GetComponent<Rigidbody2D>());
        player.GetComponent<Rigidbody2D>().position = Vector3.zero;
        player.GetComponent<SpriteRenderer>().sprite = DeathTexture;
        transform.Translate(Vector3.back);
        transform.localScale = Vector2.one * 0.2f;
        yield return new WaitForSeconds(0.2f);
        transform.localScale = Vector2.one * 0.1f;
        yield return new WaitForSeconds(0.2f);
        Destroy(player.gameObject);
        yield return new WaitForSeconds(1);
        gameOverTitleLabel.SetActive(true);
        gameOverTitleLabel.GetComponent<TMP_Text>().text += $"\nHigh Score: {PlayerPrefs.GetInt("Score")}";
    }
    private void Update()
    {
        if(IsGameOver)
        {
            if (Input.GetKey(KeyCode.R))
            {
                onReload();
            }
            if(Input.GetKey(KeyCode.Escape))
            {
                onReset();
            }
        }
    }
    public void onReset()
    {

        SceneManager.LoadScene(0);
    }
    public void onReload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
