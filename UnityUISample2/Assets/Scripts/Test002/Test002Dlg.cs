using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test002Dlg : MonoBehaviour
{
    public Toggle m_togApple;
    public Toggle m_togPair;
    public Toggle m_togOrange;
    public Text m_txtResult;
    public Button m_btnOK;
    public Button m_btnClear;

    void Start()
    {
        m_togApple.onValueChanged.AddListener(OnValueChanged_Apple);
        m_togPair.onValueChanged.AddListener (OnValueChanged_Pair);
        m_togOrange.onValueChanged.AddListener(OnValueChanged_Orange);
        m_btnOK.onClick.AddListener(OnClicked_OK);
        m_btnClear.onClick.AddListener(OnClicked_Clear);
    }

    void OnValueChanged_Apple(bool isOn)
    {
        if(isOn)
            m_txtResult.text = "���";
    }
    void OnValueChanged_Pair(bool isOn)
    {
        if (isOn)
            m_txtResult.text = "��";
    }
    void OnValueChanged_Orange(bool isOn)
    {
        if (isOn)
            m_txtResult.text = "������";
    }
    void OnClicked_OK()
    {
        if(m_togApple.isOn == false && m_togPair.isOn == false && m_togOrange.isOn == false)
        {
            m_txtResult.text = "������ ������ �����ϴ�.";
            return;
        }
        m_txtResult.text = $"������ ������ {(m_togApple.isOn ? "<color=#ff7f00>���</color> " : "")}{(m_togPair.isOn ? "<color=#ff7f00>��</color> " : "")}{(m_togOrange.isOn ? "<color=#ff7f00>������</color> " : "")}�Դϴ�.";
    }
    void OnClicked_Clear()
    {
        m_togApple.isOn = false;
        m_togPair.isOn = false;
        m_togOrange.isOn = false;
        m_txtResult.text = string.Empty;
    }
}
