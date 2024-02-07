using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationClip
{
    private string Name;
    public bool Status;
    public string[] HigherPriority;

    public AnimationClip(string Name, params string[] higherPriority)
    {
        this.Name = Name;
        this.HigherPriority = higherPriority;
    }
}
