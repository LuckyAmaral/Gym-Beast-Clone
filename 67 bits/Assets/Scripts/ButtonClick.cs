using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

///<sumary>
///Botões que vão ser clicados para comprar upgrades
///</sumary>
public class ButtonClick : MonoBehaviour
{
    [SerializeField] private Money m_Currency;
    private Button m_Button;
    [SerializeField] private int m_Price;
    [SerializeField] private TMP_Text m_Text;

    ///<sumary>
    ///define a variavel botão
    ///</sumary>
    void Start(){
        m_Button = GetComponent<Button>();
    }

    ///<sumary>
    ///verifica se o botão pode ou não ser comprado
    ///</sumary>
    void FixedUpdate()
    {
        if(m_Currency.GetValue()<m_Price){
            m_Button.interactable = false;
        }else{
            m_Button.interactable = true;
        }
    }

    ///<sumary>
    ///ajusta o botão e o visual dele para vendido
    ///</sumary>
    public void SouldOut(){
        m_Text.text="SOULD";
        m_Price = 0;
    }
}
