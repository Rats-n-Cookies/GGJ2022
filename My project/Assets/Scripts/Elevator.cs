using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    private float startHeight;
    private bool weighted = false;

    // Start is called before the first frame update
    private void Start() {
        startHeight = transform.position.y;
    }

    private void FixedUpdate() {
        if (weighted && transform.position.y > 0.05f) {
            transform.position -= new Vector3(0.0f, 0.02f, 0.0f);
        } else if (!weighted && transform.position.y < startHeight) {
            transform.position += new Vector3(0.0f, 0.08f, 0.0f);
        }
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.name == "PlayerAbundance" && weighted == false) {
                weighted = true;

        }
    }

    private void OnTriggerExit(Collider collider) {
        Debug.Log("Exit");
        if (collider.name == "PlayerAbundance" && weighted == true) {
                weighted = false;

        }

    }



}
