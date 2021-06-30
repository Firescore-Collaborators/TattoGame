using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trimmer : MonoBehaviour
{

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("trim"))
        {
            gameObject.SetActive(false);
           Controller.trimCount++;
            print(Controller.trimCount);
        }
    }
}
