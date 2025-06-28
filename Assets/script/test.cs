using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public GameObject hor,player,camera;
    private Rigidbody rb;
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) StartCoroutine(newCut());//StartCoroutine(horTrue());
    }
    IEnumerator horTrue()
    {
        GameObject createdObj = Instantiate(hor, gameObject.transform.position + gameObject.transform.forward,Quaternion.identity);
        createdObj.transform.parent = null;
        rb = createdObj.GetComponent<Rigidbody>();
        rb.AddExplosionForce(1000, gameObject.transform.position - player.transform.forward, 20);

        yield return new WaitForSeconds(10);
        createdObj.SetActive(false);
    }
    IEnumerator newCut()
    {
       
        GameObject createdObj = Instantiate(hor, camera.transform.position + gameObject.transform.forward, Quaternion.Euler(gameObject.transform.localEulerAngles.x, player.transform.localEulerAngles.y, 0));
        createdObj.transform.parent = null;
        Debug.Log("xPos= "+player. transform.rotation.y);
        rb = createdObj.GetComponent<Rigidbody>();

        for(int _ = 0; _ < 30; _++)
        {
            createdObj.transform.position += gameObject.transform.forward;
            yield return null;
            
        }
        createdObj.SetActive(false);
    }
}
