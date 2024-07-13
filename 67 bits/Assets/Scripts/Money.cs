using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

///<sumary>
///Quantidade de dinheiro que o player possui
///</sumary>
public class Money : MonoBehaviour
{
    [SerializeField] private TMP_Text m_Text;
    [SerializeField] private int m_Value;

    ///<sumary>
    ///Garante que o texto sempre seja a quantidade de dinheiro que o player tem
    ///</sumary>
    void FixedUpdate()
    {
        m_Text.text = m_Value.ToString();
    }

    ///<sumary>
    ///Modifica a Quantidade de dinheiro do player
    ///</sumary>
    ///<param name = "add">
    ///quantidade a ser adicionada
    ///</param>
    public void SetValue(int add){
        m_Value = m_Value + add;
    }

    ///<sumary>
    ///Retorna a quantidade de dinheiro do player para outros scripts sem deixar a variavel em publico
    ///</sumary>
    public int GetValue(){
        return m_Value;
    }
}
