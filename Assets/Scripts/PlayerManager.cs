using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Unity.Mathematics;
using UnityEngine;

public abstract class PlayerManager : MonoBehaviour
{
    private bool isGround = false;

    float flap = 850.0f;
    protected Rigidbody2D rb2d;

    public float speed = 1.0f;
    public GroundCheck ground;
    public FloatingJoystick joystick;
    public GameObject player;
    protected float bulletDirection;
    public float playerDirection;
    [SerializeField] protected int bulletNum = 1;


    [SerializeField] private GameObject bullet; //レーザープレハブを格納
    [SerializeField] protected GameObject shield;

    public abstract void Guard();

    void Start()
    {
        this.bulletDirection = 0.5f;
        this.playerDirection = 1;
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGround = ground.IsGround();
        float y = joystick.Vertical / 10;
        if (y > 0.05)
        {
            if (ground.enableJumped == 1 && isGround)
            {
                Jump();
                ground.enableJumped = ground.enableJumped - 1;
                this.isGround = false;
            }
        }
        if (y < -0.05 && isGround)
        {
            Guard();
        }
        else
        {
            this.shield.SetActive(false);
        }

    }

    private void Update()
    {
        float x = joystick.Horizontal / 8;
        Vector2 lscale = player.transform.localScale; //playerの向き
        if (lscale.x > 0 && x < 0)//左に向く
        {
            lscale.x *= -1;
            player.transform.localScale = lscale;
            this.playerDirection = -math.abs(this.playerDirection);
            this.bulletDirection = -math.abs(bulletDirection);
        }
        else if (lscale.x < 0 && x > 0)//右に向く
        {
            lscale.x *= -1;
            player.transform.localScale = lscale;
            this.playerDirection = 1f;
            this.bulletDirection = math.abs(this.bulletDirection);
        }
        if (CanMove())
        {
            transform.position += new Vector3(x, 0, 0);
        }

    }

    private void Jump()
    {
        rb2d.AddForce(Vector2.up * this.flap);

    }

    public void Shot()
    {
        if (this.bulletNum > 0)
        {
            Vector3 playerVector = new Vector3(transform.position.x + this.bulletDirection, transform.position.y, transform.position.z);
            GameObject genaretedBullet = Instantiate(bullet, playerVector, transform.rotation);
            Bullet bulletScript = genaretedBullet.GetComponent<Bullet>();
            bulletScript.bulletDirection = this.playerDirection;
            this.bulletNum -= 1;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Debug.Log("撃たれた！");
            this.joystick.gameObject.SetActive(false);
        }
    }

    bool CanMove()
    {
        Vector2 startPostion = transform.position;
        Vector2 endPostion = new Vector2(transform.position.x + this.bulletDirection, transform.position.y);
        transform.GetChild(0).gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        RaycastHit2D hit2D = Physics2D.Linecast(startPostion, endPostion);
        transform.GetChild(0).gameObject.GetComponent<CapsuleCollider2D>().enabled = true;

        if (hit2D.transform == null)
        {
            return true;
        }
        return false;
    }


}
