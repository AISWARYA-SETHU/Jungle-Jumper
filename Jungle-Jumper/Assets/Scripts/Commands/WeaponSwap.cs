using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Weapons
{
    Pistol,
    Sword
}

public class WeaponSwap : Command
{
    private Player player;
    private Weapons weapon;
    public WeaponSwap(Player player,Weapons weapon, KeyCode key) : base(key)
    {
        this.player = player;
        this.weapon = weapon;
    }

    public override void GetKeyDown()
    {
        player.Actions.TryWeapon(weapon);
    }
}
