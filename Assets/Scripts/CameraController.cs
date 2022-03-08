using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()              // LateUpdate() t�m update() metodlar� i�lendikten sonra �a�r�l�r. Kameran�n hareketi i�in uygundur. 
    {
        transform.position = player.transform.position + offset;                //transform position camera nin o an ki pozisyonu
    }
}
