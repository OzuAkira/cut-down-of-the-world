using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public GameObject ver, hol, player , eim;
    public Camera _camera;
    //public AudioClip _audioClip;
    public AudioSource _audioSource;
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) StartCoroutine(verticalCut());
        if (Input.GetMouseButtonDown(1))StartCoroutine(holizontalCut());
        if (Input.GetMouseButtonDown(2)) 
        {
            if(eim.activeSelf == true)eim.SetActive(false);
            else eim.SetActive(true);
        }
    }
    IEnumerator verticalCut()
    {
        _audioSource.pitch = 1.5f;
        _audioSource.Play();
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
        _audioSource.pitch = 1.5f;
        _audioSource.Play();
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
