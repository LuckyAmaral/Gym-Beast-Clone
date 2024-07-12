using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int m_Quantity;
    private bool m_OnlyOnce;

    void Start(){
       m_OnlyOnce=false;
    }

    void OnTriggerEnter(Collider collider){
        if(collider.gameObject.tag == "Player"){
            if(!m_OnlyOnce){
                Money money = collider.gameObject.GetComponent<Money>();
                money.SetValue(m_Quantity);
                Destroy(gameObject);
                m_OnlyOnce = true;
            }
        }
    }
}
