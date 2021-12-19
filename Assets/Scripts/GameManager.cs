using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FillScreen()
    {
    }

    void Awake()
    {
        Debug.Log("ゲーム開始");
        Application.targetFrameRate = 60; //60FPSに設定
    }
}
