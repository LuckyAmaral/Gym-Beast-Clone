using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

///<sumary>
///Controle do player
///</sumary>
public class Player : MonoBehaviour
{
    private Rigidbody m_Rb;
    [SerializeField] private float m_MoveSpeed;
    [SerializeField] Inventory m_Inventory;
    private float m_PunchForce;
    [SerializeField] private Animator m_Anim;
    private Vector2 m_moviment;

    ///<sumary>
    ///Define as variaveis
    ///</sumary>
    void Start()
    {
        m_Rb = GetComponent<Rigidbody>();
        m_PunchForce = 8.5f;
    }

    ///<sumary>
    ///Movimenta e rotaciona o player
    ///</sumary>
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(-m_moviment.y, 0, m_moviment.x);
        if (movement != Vector3.zero){
            Quaternion newRotation = Quaternion.LookRotation(movement.normalized);
            m_Rb.MoveRotation(newRotation);
            m_Anim.SetBool("IsRunning",true);
        }else{
            m_Anim.SetBool("IsRunning",false);
        }
        m_Rb.MovePosition(transform.position + movement * m_MoveSpeed * Time.deltaTime);
    }

    ///<sumary>
    ///verifica se colidiu com um NPC, socando ele se estiver acordado e adiconando ele a pilha se dormindo
    ///</sumary>
    void OnTriggerEnter(Collider collider){
        if(collider.gameObject.tag == "NPC"){
            NPC character = collider.gameObject.GetComponent<NPC>();
            if(character.GetUncontius()){
                m_Inventory.AddToPile(collider.gameObject);
                character.ChangeLayer();
                character.Ragdol(false);
                m_Anim.SetBool("IsCarrying",true);
            }else{
                character.Ragdol(true);
                foreach(Rigidbody rb in character.GetRb()){
                    rb.AddExplosionForce(m_PunchForce,transform.position,m_PunchForce,0,ForceMode.Impulse);
                }
                StartCoroutine(character.SetUncontius(true));
                m_Anim.SetBool("Punch",true);
            }
        }
    }

    ///<sumary>
    ///Termina a animação de ataque
    ///</sumary>
    void OnTriggerExit(Collider collider){
        m_Anim.SetBool("Punch",false);
    }

    ///<sumary>
    ///Recebe input do joystick
    ///</sumary>
    public void MoveCharacter(InputAction.CallbackContext value){
        m_moviment = value.ReadValue<Vector2>();
    }
}
