using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test004Dlg : MonoBehaviour
{
    public Slider m_Slider;
    public Text m_txtResult;
    public Button m_btnOK;
    public Button m_btnClear;

    void Start()
    {
        m_btnOK.onClick.AddListener(OnClicked_OK);
        m_btnClear.onClick.AddListener (OnClicked_Clear);
        m_Slider.onValueChanged.AddListener(OnValueChanged_Sld);
    }

    void OnValueChanged_Sld(float value)
    {
        m_txtResult.text = $"<color=#FFD700>{value}</color>";
    }
    void OnClicked_OK()
    {
        m_txtResult.text = $"현재 진행된 값은 <color=#FFD700>{m_Slider.value}</color> 입니다.";
    }
    void OnClicked_Clear()
    {
        m_Slider.value = 0;
        m_txtResult.text = string.Empty;
    }
}
