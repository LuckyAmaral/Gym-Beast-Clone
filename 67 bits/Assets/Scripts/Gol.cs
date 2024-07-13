using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<sumary>
///Local de conversão de NPC para moeda
///</sumary>
public class Gol : MonoBehaviour
{
    [SerializeField] private GameObject m_Coin;
    [SerializeField] private Inventory m_Pile;

    ///<sumary>
    ///verifica se um npc entrou no gatilho, trocando ele por uma moeda
    ///</sumary>
    void OnTriggerEnter(Collider collider){
        if(collider.gameObject.tag == "NPC"){
            Destroy(collider.gameObject);
            Instantiate(m_Coin, transform);
        }else if(collider.gameObject.tag == "Player"){
            m_Pile.ClearPlie(transform.position);
        }
    }
}
