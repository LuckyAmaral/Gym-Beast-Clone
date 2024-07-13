using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<sumary>
///Mostra e esconde a UI de upgrade
///</sumary>
public class ShowUI : MonoBehaviour
{
    [SerializeField] private GameObject m_UI;

    ///<sumary>
    ///Mostra a UI quando o player esta dentro da area de upgrade
    ///</sumary>
    void OnTriggerEnter(Collider collider){
        if(collider.gameObject.tag == "Player"){
            m_UI.SetActive(true);
        }
    }

    ///<sumary>
    ///remove a UI da tela quando o player esta longe
    ///</sumary>
    void OnTriggerExit(Collider collider){
        if(collider.gameObject.tag == "Player"){
            m_UI.SetActive(false);
        }
    }
}
