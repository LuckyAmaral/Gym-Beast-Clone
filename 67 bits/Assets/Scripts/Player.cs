using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody m_Rb;
    [SerializeField] private float m_MoveSpeed;
    [SerializeField] Inventory m_Inventory;
    private float m_PunchForce;

    // Start is called before the first frame update
    void Start()
    {
        m_Rb = GetComponent<Rigidbody>();
        m_PunchForce = 8.5f;
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
                m_Inventory.AddToPile(collider.gameObject);
                character.ChangeLayer();
                character.Ragdol(false);
            }else{
                character.Ragdol(true);
                foreach(Rigidbody rb in character.GetRb()){
                    rb.AddExplosionForce(m_PunchForce,transform.position,m_PunchForce,0,ForceMode.Impulse);
                }
                StartCoroutine(character.SetUncontius(true));
            }
        }
    }
}
