using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public GameObject ver , hol , player , camera;
    //private Rigidbody rb;
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) StartCoroutine(verticalCut());//StartCoroutine(horTrue());
        if(Input.GetMouseButtonDown(1))StartCoroutine(holizontalCut());
    }
    /*IEnumerator horTrue()
    {
        GameObject createdObj = Instantiate(hor, gameObject.transform.position + gameObject.transform.forward,Quaternion.identity);
        createdObj.transform.parent = null;
        rb = createdObj.GetComponent<Rigidbody>();
        rb.AddExplosionForce(1000, gameObject.transform.position - player.transform.forward, 20);

        yield return new WaitForSeconds(10);
        createdObj.SetActive(false);
    }
    */
    IEnumerator verticalCut()
    {
       
        GameObject v_createdObj = Instantiate(ver, camera.transform.position + gameObject.transform.forward, Quaternion.Euler(gameObject.transform.localEulerAngles.x, player.transform.localEulerAngles.y, 0));
        v_createdObj.transform.parent = null;
       // Debug.Log("xPos= "+player. transform.rotation.y);
       // rb = createdObj.GetComponent<Rigidbody>();

        for(int _ = 0; _ < 30; _++)
        {
            v_createdObj.transform.position += gameObject.transform.forward;
            yield return null;
            
        }
        v_createdObj.SetActive(false);
    }
    IEnumerator holizontalCut()
    {
        GameObject h_createdObj = Instantiate(hol, camera.transform.position + gameObject.transform.forward, Quaternion.Euler(gameObject.transform.localEulerAngles.x, player.transform.localEulerAngles.y, 90));
        h_createdObj.transform.parent = null;
        // Debug.Log("xPos= "+player. transform.rotation.y);
        // rb = createdObj.GetComponent<Rigidbody>();

        for (int _ = 0; _ < 30; _++)
        {
            h_createdObj.transform.position += gameObject.transform.forward;
            yield return null;

        }
        h_createdObj.SetActive(false);
    }
}
