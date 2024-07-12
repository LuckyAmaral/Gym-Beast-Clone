using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<GameObject> m_Pile;
    private int m_PileLimit;
    private int m_CurrentPile;
    [SerializeField] private Transform m_Startrotation;
    [SerializeField] private Transform m_Angle;

    void Start(){
        m_PileLimit = 3;
        m_CurrentPile=0;
        m_Pile = new List<GameObject>();
    }

    public void UpgradePile(){
        m_PileLimit++;
    }

    public void AddToPile(GameObject person){
        if(!m_Pile.Contains(person)){
            if(m_CurrentPile<m_PileLimit){
                m_CurrentPile++;
                m_Pile.Add(person);
            }
        }
    }

    public int GetPile(){
        return m_CurrentPile;
    }

    // Update is called once per frame
    void Update(){
        int i = 0;
        foreach(GameObject person in m_Pile){
            if(person != null){
                person.transform.position = new Vector3(transform.position.x + (i*Direction("Vertical",1)),
                                            transform.position.y +(i*1.25f),
                                            transform.position.z+ (i*Direction("Horizontal",-1)));
                person.transform.rotation = transform.rotation;
            }
            i++;
        }
        transform.rotation = Quaternion.Lerp(m_Startrotation.rotation, 
        m_Angle.rotation, 
       (Mathf.Abs(Input.GetAxis("Vertical"))+Mathf.Abs(Input.GetAxis("Horizontal")))
        );
    }

    private float Direction(string name,int multplier){
        if(Input.GetAxis(name)!= 0){
            float f = Mathf.Lerp(-0.3f,0.3f,Input.GetAxis(name));
            return multplier*f;
        }else{
            return 0;
        }
    }

    public void ClearPlie(Vector3 local){
        foreach(GameObject person in m_Pile){
            if(person!=null){
                person.transform.position = local;
            }
        }
        m_Pile.Clear();
        m_CurrentPile = 0;
    }
}
