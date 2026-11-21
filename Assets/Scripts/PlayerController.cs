using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public CharacterController Controller;
    public float speed = 4;
    Transform camera;
    float gravity = 10;
    public float vertvelocity=0;
    public float jumpv = 3;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        Controller = GetComponent<CharacterController>();
        camera = Camera.main.transform;
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        
        bool issprint = Input.GetKey(KeyCode.LeftShift);

        if(Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("attack");
        }
        
        if (issprint)
        {
            speed = 5;
        }
        else
        {
            speed = 3;
        }
        if(Input.GetAxis("Jump")>0&& Controller.isGrounded)
        {
            vertvelocity = jumpv;
        }
        else
        {
            vertvelocity -= gravity * Time.deltaTime;
        }
        Vector3 moveDirection = new Vector3(h, 0, v);
        anim.SetFloat("speed", Mathf.Clamp(moveDirection.magnitude, 0, 0.5f) + (issprint ? 0.5f : 0));
        
        if(moveDirection.magnitude>0.1)
        {
            float angel = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg + camera.eulerAngles.y;
            transform.rotation = Quaternion.Euler(0, angel, 0);
        }
        
        moveDirection = camera.TransformDirection(moveDirection);

        moveDirection = new Vector3(moveDirection.x, vertvelocity, moveDirection.z);

        Controller.Move(moveDirection * Time.deltaTime * speed);

    }
    public void DoAttack()
    {
        transform.Find("colid").GetComponent<BoxCollider>().enabled = true;
        StartCoroutine(HitCollider());
        
    }
    IEnumerator HitCollider()
    {
        yield return new WaitForSeconds(0.5f);
        transform.Find("colid").GetComponent<BoxCollider>().enabled = false;
    }
}
