using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerActions playerActions;
    public PlayerActions Actions
    {
        get
        {
            return playerActions;
        }
    }

    private InputActions inputActions;

    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private float walkSpeed; //100
    [SerializeField] private float playerScaleValue; //0.4
    [SerializeField] private float force; //5
    [SerializeField] private Collider2D collider2d;
    [SerializeField] private LayerMask layer;
    [SerializeField] private GameObject[] playerWeapons;

    public Collider2D playerCollider
    {
        get { return collider2d; }
    }

    public Rigidbody2D RigidBody
    {
        get { return rigidBody; }
    }

    public GameObject[] PlayerWeapons { get => playerWeapons; set => playerWeapons = value; }

    void Awake()
    {
        
    }

    void Start()
    {
        playerActions = new PlayerActions(this,walkSpeed, playerScaleValue, force, layer);
        inputActions = new InputActions(this);
    }

    
    void Update()
    {
        inputActions.HandleInputs();
    }

    void FixedUpdate()
    {
        playerActions.PlayerMovement();
    }
}
