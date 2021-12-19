using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Bullet : MonoBehaviour
{
    // 弾オブジェクト（Inspectorでオブジェクトを指定）
    [SerializeField] // Inspectorで操作できるように属性を追加します
    private GameObject bullet;
    // 弾オブジェクトのRigidbody2Dの入れ物
    private Rigidbody2D rb2d;
    // 弾オブジェクトの移動係数（速度調整用）
    float bulletSpeed = 15.0f;
    public float bulletDirection = 0;

    void Start()
    {
        // オブジェクトのRigidbody2Dを取得
        rb2d = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        // 弾オブジェクトの移動関数
        BulletMove();
    }
    // 弾オブジェクトの移動関数
    void BulletMove()
    {

        // 弾オブジェクトの移動量ベクトルを作成（数値情報）
        Vector2 bulletMovement = new Vector2(bulletDirection, 0).normalized;
        //Vector3 bulletMovement = new Vector3(1,0,0);
        // Rigidbody2D に移動量を加算する
        rb2d.velocity = bulletMovement * bulletSpeed;
    }
    // ENEMYと接触したときの関数
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            rb2d.gravityScale = 20;
        }
        Debug.Log(collision.gameObject.tag);
        Destroy(gameObject);
    }
}