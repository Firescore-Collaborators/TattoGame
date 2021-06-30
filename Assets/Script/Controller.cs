using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
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
    public Material materialLine;
    public GameObject Fill;
    public GameObject Line;
    public GameObject FillPrefab;
    public GameObject TattoMachine;
    public GameObject Trimmer;
    public GameObject sprayBottle;
    public GameObject Cloth;
    public GameObject MainUi;
    public GameObject Water;
    public ParticleSystem waterSpray;
    public ParticleSystem HairParticle;

    public static Color selectedColor = Color.black;
    public static string mode;
    public static float zdistance;
    public static int trimCount = 0;
    public bool trim;
    void Start()
    {
        mode = "trim";
        zdistance = 1.45f;
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
        
      //  yield return new WaitForSeconds(0.2f);
        Tatto.SetActive(true);
        
        Trimmer.SetActive(true);
    }


    private void Update()
    {
        if(mode == "fill")
        {
            if (Input.GetMouseButtonDown(0) && !IsPointerOverUIObject())
            {
                CreateFill();
            }

            if (Input.GetMouseButton(0) && !IsPointerOverUIObject())
            {

                Fill.transform.localScale = Fill.transform.localScale * 1.05f;
            }
        }

        if (mode == "spray")
        {
            if(Input.GetMouseButtonDown(0))
            {
                waterSpray.Play();
            }
        }

        if (mode == "trim")
        {
            if(Input.GetMouseButton(0))
            {
                HairParticle.gameObject.SetActive(true);
            }

            if (Input.GetMouseButtonUp(0))
            {
                HairParticle.gameObject.SetActive(false);
            }
        }



        TattoMachine.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(20f, 20f, 1f));
        Cloth.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(20f, 20f, 1f));
        sprayBottle.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(20f, -300f, 1f));
        Trimmer.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0f, -200f, 1.4f));

        if(trimCount == 25)
        {
            StartCoroutine(SpraySTart());
            trimCount++;
        }
    }

    IEnumerator SpraySTart()
    {
        yield return new WaitForSeconds(2f);
        sprayBottle.SetActive(true);
        mode = "spray";
        Trimmer.SetActive(false);
        yield return new WaitForSeconds(1f);
        Water.SetActive(true);
        yield return new WaitForSeconds(5f);
        Cloth.SetActive(true);
        sprayBottle.SetActive(false);
        yield return new WaitForSeconds(4f);
        Water.SetActive(false);
        yield return new WaitForSeconds(2f);
        Cloth.SetActive(false);
        StartCoroutine(TattoSTart());
    }


    IEnumerator TattoSTart()
    {
        yield return new WaitForSeconds(2f);
        TattoMachine.SetActive(true);
        MainUi.SetActive(true);
        ObjectTatoo.SetActive(true);
        Trimmer.SetActive(false);
    }

    public void ChangeColor(Image spriteColor)
    {

        selectedColor = spriteColor.color;
    }


    void CreateFill()
    {
        Fill = Instantiate(FillPrefab, Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0f, 0f, zdistance)), Quaternion.identity);
        Fill.GetComponent<SpriteRenderer>().color = selectedColor;
        zdistance -= 0.005f;
    }



    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }

    public void FillMode()
    {
        mode = "fill";

    }

}
