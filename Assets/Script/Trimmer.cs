using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trimmer : MonoBehaviour
{

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("trim"))
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
           Controller.trimCount++;
            print(Controller.trimCount);
        }
    }
}
