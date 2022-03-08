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
    void LateUpdate()              // LateUpdate() tüm update() metodlarý iþlendikten sonra çaðrýlýr. Kameranýn hareketi için uygundur. 
    {
        transform.position = player.transform.position + offset;                //transform position camera nin o an ki pozisyonu
    }
}
