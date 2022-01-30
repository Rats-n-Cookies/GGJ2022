using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatedStairs : MonoBehaviour
{
    public CookieButt cookieButt;

    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
        cookieButt.ButtonPressed += OnButtonPressed;
        cookieButt.ButtonReleased += OnButtonReleased;
    }

    void OnButtonPressed()
    {
        animator.Play("Activated");
    }

    void OnButtonReleased()
    {
        animator.Play("Deactivated");
    }
}
