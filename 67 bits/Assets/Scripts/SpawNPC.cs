using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawNPC : MonoBehaviour
{
    [SerializeField] private GameObject m_Npc;
    [SerializeField] private int m_TimeToSpawn;
    private float m_Timer;

    void Start()
    {
       m_Timer =  m_TimeToSpawn;
       Instantiate(m_Npc, transform);
    }

    // Update is called once per frame
    void Update()
    {
        m_Timer -= Time.deltaTime;
        if(m_Timer <= 0){
           Instantiate(m_Npc, transform); 
           m_Timer = m_TimeToSpawn;
        }
    }
}
