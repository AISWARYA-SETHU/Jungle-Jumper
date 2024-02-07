using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimManager : MonoBehaviour
{
    public static AnimManager instance;
    private Animator animator;
    private Dictionary<string, AnimationClip> animations = new Dictionary<string, AnimationClip>();
    private string currentAnimation = string.Empty;

    void Awake()
    {
        this.animator = GetComponent<Animator>();
        if ((instance != null) && (instance != this))
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }


    void Start()
    {
        animations = new Dictionary<string, AnimationClip>
        {
            { "Walk", new AnimationClip("Walk") },
            { "Idle", new AnimationClip("Idle") },
            { "Jump", new AnimationClip("Jump") },
            { "Pistol", new AnimationClip("Pistol") },
            { "Sword", new AnimationClip("Sword") }
        };
    }

    void Update()
    {

    }

    public void TryAnimation(string animationName)
    {
        if (currentAnimation == "")
        {
            animations[animationName].Status = true;
            currentAnimation = animationName;
        }
        else if (currentAnimation != animationName)
        {
            animations[currentAnimation].Status = false;
            animations[animationName].Status = true;
            currentAnimation = animationName;
        }
        Animate();
    }

    private void Animate()
    {
        foreach (string key in animations.Keys)
        {
            animator.SetBool(key, animations[key].Status);
        }
    }
}
