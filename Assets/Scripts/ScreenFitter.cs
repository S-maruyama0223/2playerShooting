using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenFitter : MonoBehaviour
{
    public Camera targetCamera;

    // Start is called before the first frame update
    void Start()
    {
        targetCamera = Camera.main;
        FillScreen();
        Debug.Log("ゲーム開始");
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FillScreen()
    {
        // orthographicSizeはカメラの垂直サイズの半分です。
        var worldHeight = targetCamera.orthographicSize * 2f;
        var worldWidth = worldHeight / Screen.height * Screen.width;
        transform.localScale = new Vector3(worldWidth, worldHeight);

        var tempPosition = Camera.main.transform.position;
        tempPosition.z = 0f;
        transform.position = tempPosition;
    }
}
