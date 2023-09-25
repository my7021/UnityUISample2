using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test008Dlg : MonoBehaviour
{
    public Dropdown m_dd;
    public Text m_txtResult;
    public Button m_btnOK;
    public Button m_btnClear;

    void Start()
    {
        m_dd.onValueChanged.AddListener(OnValueChanged_dd);
        m_btnOK.onClick.AddListener(OnClicked_OK);
        m_btnClear.onClick.AddListener(OnClicked_Clear);
    }

    void OnValueChanged_dd(int value)
    {
        m_txtResult.text = $"{value+1} : <color=#80FF00>{m_dd.options[value].text}</color>";
    }
    void OnClicked_OK()
    {
        m_txtResult.text = $"당신이 이동할 도시는 <color=#80FF00>{m_dd.options[m_dd.value].text}</color>입니다.";
    }
    void OnClicked_Clear()
    {
        m_dd.value = 0;
        m_txtResult.text = string.Empty;
    }
}
