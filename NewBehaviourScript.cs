using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    Transform tr;
    CharacterController contr;
    [SerializeField] TextMeshProUGUI text;
    bool isGrounded = false;
    float jumpHeight = 5f;
    float horizontalSpeed = 2.0f;
    float verticalSpeed = 2.0f;
    public float speed = 12f;
    int score = 0;
    void Start()
    {
        tr = GetComponent<Transform>();
        contr = GetComponent<CharacterController>();       
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * 2;
        float vertical = Input.GetAxis("Vertical");
        contr.Move(tr.forward * vertical * speed * Time.deltaTime);
        float gravityValue = -9.81f;  
        if (Input.GetKeyDown("space") && isGrounded == true)
        {
            contr.Move(tr.up * jumpHeight);
        }

        isGrounded = false;
        tr.Rotate(0,mouseX,0);
             
    }
    void OnControllerColliderHit(ControllerColliderHit col){
        if(col.gameObject.tag == "ground"){
            isGrounded = true;
        }
        if(col.gameObject.tag == "coins"){
            Destroy(col.gameObject);
            score = score + 1;
            text.text = score + "";
        
        }
    }

}
