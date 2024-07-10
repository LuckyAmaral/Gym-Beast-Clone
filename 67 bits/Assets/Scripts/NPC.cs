using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    ///<sumary>
    ///Realiza as funções basicas do NPC, como andar e Ragdoll
    ///</sumary>
    [SerializeField] private Animator m_Anim;
    [SerializeField] private List<Collider> m_Collider;
    [SerializeField] private List<HingeJoint> m_Joints;
    [SerializeField] private List<Rigidbody> m_Rb;
    private bool m_Uncontius;

    ///<sumary>
    ///define que não esta como no modo ragdoll quando iniciado
    ///</sumary>
    void Start()
    {
        m_Uncontius = false;
        Ragdol(m_Uncontius);
    }

    ///<sumary>
    ///Modifica o NPC para botar e tirar no estado de ragdoll
    ///</sumary>
    ///<param name = "RagOn">
    ///booleana para decidir se esta ligado ou desligado
    ///</param>
    public void Ragdol(bool RagOn){ 
            m_Anim.enabled = !RagOn;
        foreach (var col in m_Collider) {
            col.enabled = RagOn;
        }
        foreach (var rb in m_Rb) {
            rb.isKinematic  = !RagOn;
        }
    }


    public List<Rigidbody> GetRb(){
        return m_Rb;
    }

    public bool GetUncontius(){
        return m_Uncontius;
    }

    public IEnumerator SetUncontius(bool define){
        yield return new WaitForSeconds(0.5f);
        m_Uncontius = define;
    }
}