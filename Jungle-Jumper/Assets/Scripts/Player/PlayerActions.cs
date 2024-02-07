using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions
{
    private Player player;
    private float walkSpeed;
    private float playerScaleValue;
    private float force;
    private LayerMask layer;

    public PlayerActions(Player player, float walkSpeed, float playerScaleValue, float force, LayerMask layer)
    {
        this.player = player;
        this.walkSpeed = walkSpeed;
        this.playerScaleValue = playerScaleValue;
        this.force = force;
        this.layer = layer;
    }

    //For Player Left and Right Movements
    public void PlayerMovement()
    {
        player.RigidBody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * walkSpeed * Time.deltaTime, player.RigidBody.velocity.y);
        if(Input.GetAxisRaw("Horizontal") != 0)
        {
            player.transform.localScale = new Vector3(Input.GetAxisRaw("Horizontal") < 0 ? -(playerScaleValue) : playerScaleValue, playerScaleValue, playerScaleValue);
            AnimManager.instance.TryAnimation("Walk");
        }
        else if(player.RigidBody.velocity == Vector2.zero)
        {
            AnimManager.instance.TryAnimation("Idle");
        }
    }

    public void PlayerJump()
    {
        if(IsGrounded())
        {
            player.RigidBody.AddForce(new Vector2(0, force), ForceMode2D.Impulse);
            AnimManager.instance.TryAnimation("Jump");
        }
        
    }

    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.BoxCast(player.playerCollider.bounds.center, player.playerCollider.bounds.size, 0,Vector2.down, 0.1f, layer);
        return (hit.collider != null);
    }

    public void TryWeapon(Weapons weapon)
    {
        for(int i = 0; i<player.PlayerWeapons.Length; i++)
        {
            player.PlayerWeapons[i].SetActive(false);
        }

        player.PlayerWeapons[(int)weapon].SetActive(true);
    }
}
