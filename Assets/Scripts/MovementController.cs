using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementController : MonoBehaviour
{
    public float RotationSensivity = 0.3f;
    public GameObject fireAnimation;
    private bool Pause = false;
#pragma warning disable CS0108 // „лен скрывает унаследованный член: отсутствует новое ключевое слово
    Rigidbody2D rigidbody;
#pragma warning restore CS0108 // „лен скрывает унаследованный член: отсутствует новое ключевое слово
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    private float DeltaTime;
    // Update is called once per frame
    void Update()
    {
        if (!GameObject.Find("EventSystem").GetComponent<GameOver>().IsGameOver)
        {
            var touch = InputWrapper();
            float angle = rigidbody.rotation;
            angle = Mathf.Repeat(angle + 180, 360) - 180;
            DeltaTime = Time.deltaTime * 1000;
            float X = touch[0] * DeltaTime;
            float Y = touch[1] * DeltaTime;
            rigidbody.AddRelativeForce(new Vector2(0, Y));
            rigidbody.rotation += X * RotationSensivity;
            if (X != 0 || Y > 0)
            {
                fireAnimation.SetActive(true);
            }
            else fireAnimation.SetActive(false);
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Pause = !Pause;
            }
            if (Pause)
            {
                Time.timeScale = 0;
            }
            else Time.timeScale = 1;
        }else
        {
            Destroy(fireAnimation);
        }
    }
    float[] InputWrapper()
    {
        float X = 0;
        float Y = 0;
        try
        {
            X += GameObject.Find("LeftRot").GetComponent<TouchWrapper>().pressed ? 1 : 0;
            X -= GameObject.Find("RightRot").GetComponent<TouchWrapper>().pressed ? 1 : 0;
            Y += GameObject.Find("Up").GetComponent<TouchWrapper>().pressed ? 1 : 0;
            Y -= GameObject.Find("Down").GetComponent<TouchWrapper>().pressed ? 1 : 0;
        }
        catch (NullReferenceException)
        {
            X = -Input.GetAxis("Horizontal");
            Y = Input.GetAxis("Vertical");
        }
        return new[] { X, Y };
    }
}
