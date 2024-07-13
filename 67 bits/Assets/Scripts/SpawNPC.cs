using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<sumary>
///Grante que vai ter NPC constantemente no mapa
///</sumary>
public class SpawNPC : MonoBehaviour
{
    [SerializeField] private Transform m_Target;
    [SerializeField] private GameObject m_Npc;
    [SerializeField] private int m_TimeToSpawn;
    private float m_Timer;

    ///<sumary>
    ///Define a variavel Timer, cria um NPC
    ///</sumary>
    void Start()
    {
       m_Timer =  m_TimeToSpawn;
       Spawnpc();
    }

    ///<sumary>
    ///Depois que o tempo acabar, chama a função Spawnpc(), e reseta o tempo
    ///</sumary>
    void FixedUpdate()
    {
        m_Timer -= Time.deltaTime;
        if(m_Timer <= 0){
           Spawnpc();
           m_Timer = m_TimeToSpawn;
        }
    }

    ///<sumary>
    ///cria um NPC
    ///</sumary>
    void Spawnpc()
    {
        GameObject go = Instantiate(m_Npc, transform);
        NPC person = go.GetComponent<NPC>();
        person.SetGoFoward(m_Target);
    }
}
