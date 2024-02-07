using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolAttack : Command
{
    private Player player;

    public PistolAttack(Player player, KeyCode key) : base(key)
    {
        this.player = player;
    }

    public override void GetKeyDown()
    {
        player.Actions.PlayerPistolAttack();
    }
}
