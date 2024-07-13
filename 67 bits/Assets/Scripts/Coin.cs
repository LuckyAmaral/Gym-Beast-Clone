using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<sumary>
///Moeda coletavel
///</sumary>
public class Coin : MonoBehaviour
{
    [SerializeField] private int m_Quantity;
    private bool m_OnlyOnce;

    ///<sumary>
    ///garante que a Moeda não foi pegada ainda
    ///</sumary>
    void Start(){
       m_OnlyOnce=false;
    }

    ///<sumary>
    ///verifica se o player colidiu com a moeda, coletando ela. OnlyOnce garante que não vai ser coletada denovo
    ///</sumary>
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
