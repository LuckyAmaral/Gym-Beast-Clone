using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody m_Rb;
    [SerializeField] private float m_MoveSpeed;
    [SerializeField] private Transform m_CharacterPlace;

    // Start is called before the first frame update
    void Start()
    {
        m_Rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float dirZ = Input.GetAxis("Horizontal");
        float dirX = -Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(dirX, 0, dirZ);
        if (movement != Vector3.zero){
            Quaternion newRotation = Quaternion.LookRotation(movement.normalized);
            m_Rb.MoveRotation(newRotation);
        }
        m_Rb.MovePosition(transform.position + movement * m_MoveSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider collider){
        if(collider.gameObject.tag == "NPC"){
            NPC character = collider.gameObject.GetComponent<NPC>();
            if(character.GetUncontius()){
                character.Ragdol(false);
                StartCoroutine(character.SetUncontius(false));
                
            }else{
                character.Ragdol(true);
                foreach(Rigidbody rb in character.GetRb()){
                    rb.AddExplosionForce(7f,transform.position,7f,0f,ForceMode.Impulse);
                }
                StartCoroutine(character.SetUncontius(true));
            }
        }
    }
}
