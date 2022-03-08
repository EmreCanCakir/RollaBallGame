using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class PlayerController : MonoBehaviour
{
    public float speed = 0f;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    private int count;
    private Rigidbody rb;           //Object e nesnellik ve fizik yüklüyor kütle gibi 
    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
    }
    
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();          // Nesnenin 2 boyutlu vectorlerini ve noktalarini tutar. 
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Count:" + count.ToString();
        if (count >= 11)
        {
            winTextObject.SetActive(true);
            
        }
    }

    void FixedUpdate()              // FixedUpdate() fizik motoru tarafýndan sabit aralýklarla çaðrýlýr( Ayarlayabiliyoruz kendimiz).
    {                               // Bu temel olarak fizikle ilgili tüm fonksiyonalar trigger(), collision() için uygundur.
    

        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement*speed);                                    // Nesneye kuvvet katar. 
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);          //Çarptýðýmýz nesnenin yok olmasýný saðlýyor.
            count = count + 1;
            SetCountText();
        }
        
    }
}
