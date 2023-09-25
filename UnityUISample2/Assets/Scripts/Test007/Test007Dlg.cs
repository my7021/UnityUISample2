using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test007Dlg : MonoBehaviour
{
    public Scrollbar m_sb;
    public Text m_txtResult;
    public Button m_btnOK;
    public Button m_btnClear;
    float m_time = 0;
    bool isStart = false;

    void Start()
    {
        m_sb.onValueChanged.AddListener(OnValueChanged_Sb);
        m_btnOK.onClick.AddListener(OnClicked_OK);
        m_btnClear.onClick.AddListener(OnClicked_Clear);
    }

    void OnValueChanged_Sb(float value)
    {
        PrintText(value);
    }
    void PrintText(float value)
    {
        Color c = m_txtResult.color;
        m_txtResult.color = new Color(c.r, c.g, c.b, value);
        m_txtResult.text = (value == 0 && value == 1) ? $"{value}" : $"{value:0.00}";
    }
    void OnClicked_OK()
    {
        if (!isStart)
        {
            OnClicked_Clear();
            isStart = true;
        }
    }
    void SbMove()
    {
        if(m_sb.value >= 1)
            isStart = false;
        m_time += Time.deltaTime;
        if(m_time >= 0.5f)
        {
            m_sb.value += 0.05f;
            m_time = 0;
        }
    }
    void OnClicked_Clear()
    {
        m_time = 0;
        m_sb.value = 0;
        m_txtResult.text = string.Empty;
    }

    void Update()
    {
        if(isStart)
        {
            SbMove();
        }
    }
}
