using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<sumary>
///Move o Joystick pra onde foi clicado
///</sumary>
public class MoveUI : MonoBehaviour
{
    void Update()
    {
        if(Input.touchCount > 0){
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                transform.position = touch.position;
                gameObject.SetActive(true);
                break;
            }
        }else{
            gameObject.SetActive(false);
        }
    }
}
