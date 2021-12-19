using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private bool isGround = false;
    private bool isGroundEnter, isGroundStay, isGroundExit;
    public int enableJumped = 1;


    public bool IsGround()
    {
        if (isGroundEnter || isGroundStay)
        {
            this.isGround = true;
            this.enableJumped = 1;
        }
        else if (isGroundExit)
        {
            isGround = false;
        }

        isGroundEnter = false;
        isGroundStay = false;
        isGroundExit = false;

        return isGround;
    }

    // Start is called before the first frame update
    void Start(){}

    // Update is called once per frame
    void Update(){}

    /**
     *Unity側から呼ばれるメソッド
     *実行の条件は
     *１、IsTriggerな2Dコライダーがそのゲームオブジェクトもしくは子オブジェクトについている。
     *２、そのゲームオブジェクト 、もしくは親、もしくは相手の方にRigidbody2Dがついている
     *３、IsTrggerな2Dコライダーの判定内に別の2Dコライダーが侵入した。
     *
     */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground" || collision.tag == "player")
        {
            isGroundEnter = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Ground" || collision.tag == "player")
        {
            isGroundStay = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ground" || collision.tag == "player")
        {
            isGroundExit = true;
        }
    }
}
