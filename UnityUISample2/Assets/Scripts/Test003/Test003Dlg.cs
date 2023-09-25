using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test003Dlg : MonoBehaviour
{
    public Toggle[] m_toggles;
    public Text m_txtResult;
    public Button m_btnOK;
    public Button m_btnClear;
    string[] m_txts = {"사과", "배", "오렌지"};

    void Start()
    {
        for (int i = 0; i < m_toggles.Length; i++)
        {
            int idx = i;
            m_toggles[i].onValueChanged.AddListener((isOn) => OnValueChanged(isOn, idx));
        }
        m_btnOK.onClick.AddListener(OnClicked_OK);
        m_btnClear.onClick.AddListener(OnClicked_Clear);
    }

    void OnValueChanged(bool isOn, int i)
    {
        m_txtResult.text = m_txts[i];
    }
    void OnClicked_OK()
    {
        m_txtResult.text = "당신이 선택한 과일은 ";
        for (int i = 0; i < m_toggles.Length; i++)
        {
            if (m_toggles[i].isOn)
                m_txtResult.text += $"<color=#81c147>{m_txts[i]}</color> ";
        }
        m_txtResult.text += "입니다.";
    }
    void OnClicked_Clear()
    {
        for (int i = 0; i < m_toggles.Length; i++)
        {
            m_toggles[i].isOn = false;
        }
        m_txtResult.text = string.Empty;
    }
}
