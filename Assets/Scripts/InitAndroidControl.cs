using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitAndroidControl : MonoBehaviour
{
    public GameObject leftRotation;
    public GameObject rightRotation;
    public GameObject Up;
    public GameObject Down;
    public GameObject Blast;
    public GameObject Reset;
    public GameObject Exit;
    public GameObject Pause;
    // Start is called before the first frame update
    void Start()
    {
#if UNITY_ANDROID
        leftRotation.SetActive(true);
        rightRotation.SetActive(true);
        Up.SetActive(true);
        Down.SetActive(true);
        Blast.SetActive(true);
        Pause.SetActive(true);
        Reset.SetActive(false);
        Exit.SetActive(false);
#endif
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
