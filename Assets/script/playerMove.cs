using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMove : MonoBehaviour
{
    [SerializeField] Vector3 axis;
    void OnMove(InputValue value)
    {
        axis = value.Get<Vector2>();
    }
    void Update()
    {
        gameObject.transform.position += axis;
    }
}
