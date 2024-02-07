using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
            { "Walk", new AnimationClip("Walk", "Pistol") },
            { "Idle", new AnimationClip("Idle", "Pistol") },
            { "Jump", new AnimationClip("Jump") },
            { "Pistol", new AnimationClip("Pistol") },
            { "Sword", new AnimationClip("Sword") }
        };
    }

    void Update()
    {
        Animate();
    }

    public void TryAnimation(string animationName)
    {
        if (currentAnimation == "")
        {
            animations[animationName].Status = true;
            currentAnimation = animationName;
        }
        else if (currentAnimation != animationName && !animations[animationName].HigherPriority.Contains(currentAnimation) || !animations[currentAnimation].Status)
        {
            animations[currentAnimation].Status = false;
            animations[animationName].Status = true;
            currentAnimation = animationName;
        }
       
    }

    private void Animate()
    {
        foreach (string key in animations.Keys)
        {
            animator.SetBool(key, animations[key].Status);
        }
    }

    public void OnAnimationDone(string animationName)
    {
        animations[animationName].Status = false;
    }
}
