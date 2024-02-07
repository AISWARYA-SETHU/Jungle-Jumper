using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : Command
{
    private Player player;

    public Jump(Player player, KeyCode key) : base(key)
    {
        this.player = player;
    }

    public override void GetKeyDown()
    {
        player.Actions.PlayerJump();
        Debug.Log("Jumping");
    }
}
