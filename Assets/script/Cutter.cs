using EzySlice;// References https://github.com/DavidArayan/ezy-slice
using UnityEngine;

public class cutter : MonoBehaviour
{
    public Transform plane;
    public Material crossMaterial;
    public Camera cam;

   /* public Transform cam_transform;
    private void Start()
    {
        cam_transform = cam.transform;
        cam_transform.rotation = Quaternion.Euler(15, 0, 0);
    }
   */
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SlicedHull hull = gameObject.Slice(plane.position+new Vector3(0,0.1f,0), cam.transform.up);

            if (hull != null)
            {
                GameObject upperHull = hull.CreateUpperHull(gameObject, crossMaterial);
                GameObject lowerHull = hull.CreateLowerHull(gameObject, crossMaterial);

                Destroy(gameObject);

                upperHull.AddComponent<MeshCollider>().convex = true;
                lowerHull.AddComponent<MeshCollider>().convex = true;

                plane = lowerHull.GetComponent<Transform>();
//                cam_transform.rotation = Quaternion.Euler(-15, 0, 0);
                SlicedHull Hull_2 = lowerHull.Slice(plane.position + new Vector3(0,-0.1f,0),cam.transform.up);


                //Destroy(lowerHull);
                
                if (Hull_2 != null)
                {
                    Debug.Log("run");
                    //GameObject upperHull_2 = Hull_2.CreateUpperHull(lowerHull, crossMaterial);
                    GameObject lowerHull_2 = Hull_2.CreateLowerHull(lowerHull, crossMaterial);

                    Destroy(lowerHull);

                    //upperHull_2.AddComponent<MeshCollider>().convex = true;
                    lowerHull_2.AddComponent<MeshCollider>().convex = true;
                }

                    /*
                    upperHull.transform.position += new Vector3(-1, 0, 0);
                    lowerHull.transform.position += new Vector3(1, 0, 0);
                    */
                }
            }
    }
}
