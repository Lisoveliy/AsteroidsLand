using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitAndroidControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
#if UNITY_ANDROID
        GameObject.Find("LeftRot").SetActive(true);
        GameObject.Find("RightRot").SetActive(true);
        GameObject.Find("Up").SetActive(true);
        GameObject.Find("Down").SetActive(true);
        GameObject.Find("Blast").SetActive(true);
        GameObject.Find("Reset").SetActive(false);
        GameObject.Find("Exit").SetActive(false);
#endif
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
