using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public GameObject ver, hol, player , eim;
    public Camera _camera;
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) StartCoroutine(verticalCut());
        if(Input.GetMouseButtonDown(1))StartCoroutine(holizontalCut());
        if (Input.GetMouseButtonDown(2)) 
        {
            if(eim.activeSelf == true)eim.SetActive(false);
            else eim.SetActive(true);
        }
    }
    IEnumerator verticalCut()
    {
       
        GameObject v_createdObj = Instantiate(ver, _camera.transform.position + gameObject.transform.forward, Quaternion.Euler(gameObject.transform.localEulerAngles.x, player.transform.localEulerAngles.y, 0));
        v_createdObj.transform.parent = null;
        for(int _ = 0; _ < 30; _++)
        {
            v_createdObj.transform.position += gameObject.transform.forward;
            yield return null;
            
        }
        v_createdObj.SetActive(false);
    }
    IEnumerator holizontalCut()
    {
        GameObject h_createdObj = Instantiate(hol, _camera.transform.position + gameObject.transform.forward, Quaternion.Euler(gameObject.transform.localEulerAngles.x, player.transform.localEulerAngles.y, 90));
        h_createdObj.transform.parent = null;
        for (int _ = 0; _ < 30; _++)
        {
            h_createdObj.transform.position += gameObject.transform.forward;
            yield return null;

        }
        h_createdObj.SetActive(false);
    }



}
