using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWall : MonoBehaviour
{
    public GameObject WholeWall;
    public GameObject BrokenWall;

    void BreakWall()
    {
        WholeWall.SetActive(false);
        BrokenWall.SetActive(true);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            BreakWall();
        }
    }
}
