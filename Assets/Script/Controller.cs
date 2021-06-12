using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public GameObject LookPos;
    public GameObject Character;
    public GameObject ObjectTatoo;
    public GameObject camera;
    public GameObject TattoColor;
    public GameObject CameraLastPos;
    public GameObject Tatto;
    public GameObject Line;
    public GameObject Fill;


    void Start()
    {
        StartCoroutine(LookatPos());   
    }
    
    IEnumerator LookatPos()
    {
        yield return new WaitForSeconds(0.5f);
        LeanTween.rotate(Character, new Vector3(0, 180f, 0), 0.5f);
        yield return new WaitForSeconds(3f);
        LeanTween.move(camera,CameraLastPos.transform.position, 0.5f);
        yield return new WaitForSeconds(0.4f);
        Character.SetActive(false);
        // ObjectTatoo.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        Tatto.SetActive(true);
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TattoColor.SetActive(true);
        }

        if (Input.GetMouseButton(0))
        {
            TattoColor.SetActive(true); 
            TattoColor.transform.localScale = TattoColor.transform.localScale *1.1f;
        }
    }

    public void ChangeColor(Image spriteColor)
    {
        Line.GetComponent<LineRenderer>().sharedMaterial.color = spriteColor.color;
        Fill.GetComponent<SpriteRenderer>().color = spriteColor.color;
    }
}
