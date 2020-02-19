using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public static PlayerJump instance;

    private Rigidbody2D myBody;
    private Animator anim;

    [SerializeField]
    private float fX, fY;
    
    private float thX = 7f;
    private float thY = 14f;

    private bool setPower, didJump;

    void Awake() {
        MakeInstance();
        Initialize();
    }

    void Update() {
        SetPower();    
    }

    void MakeInstance(){
        if(instance == null){
            instance = this;
        }
    }

    void Initialize(){
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void SetPower(){
        if(setPower){
            fX += thX * Time.deltaTime;
            fY += thY * Time.deltaTime;
        }

        if(fX > 6.5f){
            fX = 6.5f;
        }
        if(fY > 13.5f){
            fY = 13.5f;
        }
    }

    public void SetPower(bool setPower){
        this.setPower = setPower;

        if(!setPower){
            Jump();
        }
    }

    void Jump(){
        myBody.velocity = new Vector2(fX, fY);
        fX = fY = 0f; //reset after landing to the platform
        didJump = true; //later using
    }

    private void OnTriggerEnter2D(Collider2D target) {

        if(didJump){
            didJump = false;
            if(target.tag == "platform"){
                if(GameManager.instance != null){
                    GameManager.instance.CreateNewPlatformAndLerp(target.transform.position.x);//lerp positon passing according to new platform position
                }
            }
        }
    }

}
