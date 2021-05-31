using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public GameObject LookPos;
    public GameObject Character;
    public GameObject ObjectTatoo;
    public GameObject camera;
    public GameObject TattoColor;
    void Start()
    {
        StartCoroutine(LookatPos());   
    }
    
    IEnumerator LookatPos()
    {
        yield return new WaitForSeconds(0.5f);
        LeanTween.rotate(Character, new Vector3(0, 180f, 0), 0.5f);
        yield return new WaitForSeconds(3f);
        LeanTween.move(camera, camera.transform.forward * 3.2f, 0.5f);
        yield return new WaitForSeconds(0.5f);
        ObjectTatoo.SetActive(true);
    }


    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            TattoColor.SetActive(true);
            TattoColor.transform.position = Input.mousePosition;
            TattoColor.transform.localScale = TattoColor.transform.localScale *1.1f;
        }
    }
}
