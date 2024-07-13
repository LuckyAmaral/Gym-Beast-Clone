using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<sumary>
///Muda a cor do Player
///</sumary>
public class ChangeMaterial : MonoBehaviour
{
    private Material[] m_Material= new Material[3];
    private Color[] m_Colors= new Color[5];

    ///<sumary>
    ///Define os valores das variaveis
    ///</sumary>
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            m_Material[i] = GetComponent<Renderer>().materials[i];
        }
        m_Colors[0] = new Color(0,1,0);
        m_Colors[1] = new Color(1,0,0);
        m_Colors[2] = new Color(0,0,1);
        m_Colors[3] = new Color(1,1,0);
        m_Colors[4] = new Color(0,0,0);
    }

    ///<sumary>
    ///Muda a cor do material para uma cor dentro das cores dentro do Color
    ///</sumary>
    ///<param name = "colorIndex">
    ///escolhe qual cor quer botar no material
    ///</param>
    public void ChangeColor(int colorIndex)
    {
        m_Material[0].SetColor("_Color",m_Colors[colorIndex]);
        m_Material[2].SetColor("_Color",m_Colors[colorIndex]);
    }
}
