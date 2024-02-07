using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputActions
{
    private Player player;
    List<Command> commandList = new List<Command>();
    
    public InputActions(Player player)
    {
        this.player = player;
        commandList = new List<Command>
        {
            new Jump(player,KeyCode.Space),
            new PistolAttack(player,KeyCode.LeftControl),
            new WeaponSwap(player,Weapons.Pistol,KeyCode.Alpha1),
            new WeaponSwap(player, Weapons.Sword, KeyCode.Alpha2)
        };
    }

    public void HandleInputs()
    {
        foreach(Command command in commandList) 
        {
            if(Input.GetKeyDown(command.key))
            {
                command.GetKeyDown();
            }

            if (Input.GetKeyUp(command.key))
            {
                command.GetKeyUp();
            }

            if (Input.GetKey(command.key))
            {
                command.GetKey();
            }
        }
    }
     
}
