using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    [SerializeField] GameObject camaraPrincipal;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = camaraPrincipal.transform.position + new Vector3(0,0,-10);
    }
}
