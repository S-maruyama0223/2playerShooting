using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1 : PlayerManager
{
    public override void Guard()
    {
        this.shield.SetActive(true);
    }
}
