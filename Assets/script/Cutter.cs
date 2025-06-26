using EzySlice;
using UnityEngine;

public class Cutter : MonoBehaviour
{
    public Transform plane;
    public Material crossMaterial;
    public Camera cam;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SlicedHull hull = gameObject.Slice(plane.position, cam.transform.up);

            if (hull != null)
            {
                GameObject upperHull = hull.CreateUpperHull(gameObject, crossMaterial);
                GameObject lowerHull = hull.CreateLowerHull(gameObject, crossMaterial);

                Destroy(gameObject);

                upperHull.AddComponent<MeshCollider>().convex = true;
                lowerHull.AddComponent<MeshCollider>().convex = true;
            }
        }
    }
}
