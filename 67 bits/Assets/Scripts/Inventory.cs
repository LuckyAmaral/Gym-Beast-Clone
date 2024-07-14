using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

///<sumary>
///Pilha que o player carrega
///</sumary>
public class Inventory : MonoBehaviour
{
    private List<GameObject> m_Pile;
    private int m_PileLimit;
    private int m_CurrentPile;
    [SerializeField] private Transform m_Startrotation;
    [SerializeField] private Transform m_Angle;
    [SerializeField] private Animator m_Anim;
    private float m_Inpx;
    private float m_Inpz;

    ///<sumary>
    ///define os valores iniciais das variaveis
    ///</sumary>
    void Start(){
        m_PileLimit = 3;
        m_CurrentPile=0;
        m_Pile = new List<GameObject>();
    }

    ///<sumary>
    ///Aumenta a quantidade de NPCs que pode ser carregado
    ///</sumary>
    public void UpgradePile(){
        m_PileLimit++;
    }

    ///<sumary>
    ///se tiver espaço, adiciona o NPC para a pilha
    ///</sumary>
    ///<param name = "person">
    ///NPC à ser adicionado a pilha
    ///</param>
    public void AddToPile(GameObject person){
        if(!m_Pile.Contains(person)){
            if(m_CurrentPile<m_PileLimit){
                m_CurrentPile++;
                m_Pile.Add(person);
            }
        }
    }

    ///<sumary>
    ///Retorna os Quantos NPC estão sendo carregados para outros scripts sem deixar a variavel em publico
    ///</sumary>
    public int GetPile(){
        return m_CurrentPile;
    }

    ///<sumary>
    ///Funções de atualizar a rotação e a posição dos objetos na pilha
    ///</sumary>
    void FixedUpdate(){
        int i = 0;
        foreach(GameObject person in m_Pile){
            if(person != null){
                person.transform.position = new Vector3(transform.position.x + (i*Direction(m_Inpx)),
                                            transform.position.y +(i*1.25f),
                                            transform.position.z+ (i*Direction(m_Inpz)));
                person.transform.rotation = transform.rotation;
            }
            i++;
        }
        transform.rotation = Quaternion.Lerp(m_Startrotation.rotation, 
        m_Angle.rotation, 
       (Mathf.Abs(m_Inpx)+Mathf.Abs(m_Inpz))
        );
    }

    ///<sumary>
    ///Retorna um incremento para cada objeto na pilha, garantindo que eles se ajustem comforme a direção que o player se move
    ///</sumary>
    ///<param name = "name">
    ///O qaunto que vai ter que ir para tras
    ///</param>
    private float Direction(float value){
        if(value!= 0){
            float f = Mathf.Lerp(-0.3f,0.3f,value);
            return f;
        }else{
            return 0;
        }
    }

    ///<sumary>
    ///Zera a pilha, e direciona os NPCs dentro dela para o gol
    ///</sumary>
    ///<param name = "local">
    ///localização do gol
    ///</param>
    public void ClearPlie(Vector3 local){
        foreach(GameObject person in m_Pile){
            if(person!=null){
                person.transform.position = local;
            }
        }
        m_Pile.Clear();
        m_CurrentPile = 0;
        m_Anim.SetBool("IsCarrying",false);
    }

    ///<sumary>
    ///Recebe input do joystick
    ///</sumary>
    public void MoveJoystick(InputAction.CallbackContext value){
        Vector2 moviment = value.ReadValue<Vector2>();
        m_Inpx = moviment.y;
        m_Inpz = -moviment.x;
    }
}
