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
        cookieButt.ButtonPressed += OnButtonReleased;
    }

    void Start()
    {
        animator.Play("Activated");
    }

    void OnButtonPressed()
    {
        animator.Play("Activated");
    }

    void OnButtonReleased()
    {
        animator.Play("Released");
    }
}
