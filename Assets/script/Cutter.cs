using EzySlice;// References https://github.com/DavidArayan/ezy-slice
using UnityEngine;

public class cutter : MonoBehaviour
{
   // private Transform plane;
    private Material crossMaterial;
    private Camera cam;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) SliceObj(0);
    }
    private void Start()
    {
       // plane = gameObject.transform;
        cam = Camera.main;
        crossMaterial = Resources.Load<Material>("material/white_material");
    }
    /*
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))SliceObj(0);
    }
    */

    void SliceObj(int i)
    {
        if (i == 0)
        {
            SlicedHull hull = gameObject.Slice(cam.transform.position, cam.transform.up);

            if (hull != null)
            {
                GameObject upperHull = hull.CreateUpperHull(gameObject, crossMaterial);
                GameObject lowerHull = hull.CreateLowerHull(gameObject, crossMaterial);

                Destroy(gameObject);

                upperHull.AddComponent<MeshCollider>().convex = true;
                lowerHull.AddComponent<MeshCollider>().convex = true;

                upperHull.AddComponent<cutter>();
                lowerHull.AddComponent<cutter>();
                /*
                upperHull.transform.position += new Vector3(0, 1, 0);
                lowerHull.transform.position -= new Vector3(0, 1, 0);*/

               // plane = lowerHull.GetComponent<Transform>();
                //                cam_transform.rotation = Quaternion.Euler(-15, 0, 0);
                SlicedHull Hull_2 = lowerHull.Slice(cam.transform.position + new Vector3(0, -0.1f, 0), cam.transform.up);


                Destroy(lowerHull);

                if (Hull_2 != null)
                {
                    Debug.Log("run");
                    //GameObject upperHull_2 = Hull_2.CreateUpperHull(lowerHull, crossMaterial);
                    GameObject lowerHull_2 = Hull_2.CreateLowerHull(lowerHull, crossMaterial);

                    Destroy(lowerHull);

                    //upperHull_2.AddComponent<MeshCollider>().convex = true;
                    lowerHull_2.AddComponent<MeshCollider>().convex = true;

                    lowerHull_2.AddComponent<cutter>();
                }
                upperHull.AddComponent<cutter>();
                lowerHull.AddComponent<cutter>();

                /*
                upperHull.transform.position += new Vector3(-1, 0, 0);
                lowerHull.transform.position += new Vector3(1, 0, 0);
                */
            }
        }
        else if (i == 1)
        {

        }
    }
   } 
    
//}