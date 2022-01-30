using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieButt : MonoBehaviour
{
    public List<GameObject> Activators;

    public delegate void OnButtonPressed();
    public event OnButtonPressed ButtonPressed;

    enum State { Normal, Pressed };
    State _state = State.Normal;

    float _init_y;
    float _height;

    void Awake()
    {
        _init_y = transform.position.y;
        _height = GetComponent<MeshRenderer>().bounds.size.y;
    }

    State CurrentState
    {
        get { return _state; }
        set
        {
            _state = value;
            switch (value)
            {
                case State.Normal:
                    StartCoroutine(MoveVertically(_init_y));
                    break;

                case State.Pressed:
                    StartCoroutine(MoveVertically(_init_y - (_height / 3)));
                    break;
            }
        }
    }

    IEnumerator MoveVertically(float y)
    {
        while (!Mathf.Approximately(transform.position.y, y))
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                new Vector3(transform.position.x, y, transform.position.z),
                1.0f * Time.deltaTime
            );
            yield return new WaitForEndOfFrame();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (Activators.Contains(other.gameObject))
        {
            CurrentState = State.Pressed;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (Activators.Contains(other.gameObject))
        {
            CurrentState = State.Normal;
        }
    }
}
