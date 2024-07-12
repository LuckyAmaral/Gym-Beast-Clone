using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Money : MonoBehaviour
{
    [SerializeField] private TMP_Text m_Text;
    [SerializeField] private int m_Value;

    void Update()
    {
        m_Text.text = m_Value.ToString();
    }

    public void SetValue(int add){
        m_Value = m_Value + add;
    }

    public int GetValue(){
        return m_Value;
    }
}
