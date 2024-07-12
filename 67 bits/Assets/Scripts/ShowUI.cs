using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUI : MonoBehaviour
{
    [SerializeField] private GameObject m_UI;

    void OnTriggerEnter(Collider collider){
        if(collider.gameObject.tag == "Player"){
            m_UI.SetActive(true);
        }
    }

    void OnTriggerExit(Collider collider){
        if(collider.gameObject.tag == "Player"){
            m_UI.SetActive(false);
        }
    }
}
