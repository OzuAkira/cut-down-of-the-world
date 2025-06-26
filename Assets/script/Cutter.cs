using EzySlice;
using UnityEngine;

public class Cutter : MonoBehaviour
{
    public Transform plane;
    public Material crossMaterial;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SlicedHull hull = gameObject.Slice(plane.position, plane.up);

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
