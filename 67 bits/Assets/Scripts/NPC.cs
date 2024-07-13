using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<sumary>
///Realiza as funções basicas do NPC, como andar e Ragdoll
///</sumary>
public class NPC : MonoBehaviour
{
    
    [SerializeField] private Animator m_Anim;
    [SerializeField] private List<Collider> m_Collider;
    [SerializeField] private List<HingeJoint> m_Joints;
    [SerializeField] private List<Rigidbody> m_Rb;
    [SerializeField] private float m_Speed;
    private Transform m_GoForward;
    private bool m_Uncontius;

    ///<sumary>
    ///define que não esta como no modo ragdoll ou inconciente quando iniciado
    ///</sumary>
    void Start()
    {
        m_Uncontius = false;
        Ragdol(m_Uncontius);
    }

    ///<sumary>
    ///Move o NPC para frente
    ///</sumary>
    void FixedUpdate()
    {
        if(!m_Uncontius){
            transform.position = Vector3.MoveTowards(transform.position,m_GoForward.position, m_Speed);
        }
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

    ///<sumary>
    ///Muda a Layer do NPC, garantindo que ele não vai colidir com outros npc ou o player quando carregado
    ///</sumary>
    public void ChangeLayer(){
        gameObject.layer = 6;
        foreach(Collider col in m_Collider){
            col.gameObject.layer = 6;
        }
    }

    ///<sumary>
    ///Retorna os Rigidybodies para outros scripts sem deixar a variavel em publico
    ///</sumary>
    public List<Rigidbody> GetRb(){
        return m_Rb;
    }

    ///<sumary>
    ///Retorna se esta inconciente ou não para outros scripts sem deixar a variavel em publico
    ///</sumary>
    public bool GetUncontius(){
        return m_Uncontius;
    }

    ///<sumary>
    ///Permite modificar o valor da booleana. tem um delay para evitar que o player colete o NPC imediatamente depois de ataca-lo
    ///</sumary>
    ///<param name = "define">
    ///booleana para modificar o estado Unconcious
    ///</param>
    public IEnumerator SetUncontius(bool define){
        yield return new WaitForSeconds(0.5f);
        m_Uncontius = define;
    }

    ///<sumary>
    ///Destroi o NPC
    ///</sumary>
    void OnTriggerEnter(Collider collider){
        if(collider.gameObject.tag == "DestroyNPC"){
            Destroy(gameObject);
        }
    }

    ///<sumary>
    ///Define o destino onde o NPC irá
    ///</sumary>
    public void SetGoFoward(Transform target){
        m_GoForward = target;
    }
}