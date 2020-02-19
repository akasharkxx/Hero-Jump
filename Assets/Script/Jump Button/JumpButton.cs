using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JumpButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData data){
        //Debug.Log("We have touch button");
        if(PlayerJump.instance != null){
            PlayerJump.instance.SetPower(true);
        }
    }
    public void OnPointerUp(PointerEventData data){
        //Debug.Log("We are Releasing the Button");
        if(PlayerJump.instance != null){
            PlayerJump.instance.SetPower(false);
        }
    }
}
