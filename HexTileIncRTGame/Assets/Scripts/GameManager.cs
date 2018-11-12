using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public bool IsOnMobile { get; set; }

    private void Awake()
    {
        instance = this;
        CheckIfOnMobile();
    }

    private void CheckIfOnMobile()
    {
#if UNITY_ANDROID || UNITY_IOS
        IsOnMobile = true;
#endif
#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBGL
        IsOnMobile = false;
#endif
    }
}
