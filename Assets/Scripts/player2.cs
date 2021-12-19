using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2 : PlayerManager
{
    public override void Guard()
    {
        this.shield.SetActive(true);
    }

    void Start()
    {
        this.bulletDirection = -0.5f;
        this.playerDirection = -1;
        this.rb2d = GetComponent<Rigidbody2D>();
    }
}
