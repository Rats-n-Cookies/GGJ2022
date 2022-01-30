using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatedStairs : MonoBehaviour
{
    public List<CookieButt> cookieButts;

    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();

        foreach (CookieButt cookieButt in cookieButts)
        {
            cookieButt.ButtonPressed += OnButtonPressed;
            cookieButt.ButtonReleased += OnButtonReleased;
        }
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
