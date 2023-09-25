using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test005Dlg : MonoBehaviour
{
    public Slider m_sldRed;
    public Slider m_sldGreen;
    public Slider m_sldBlue;
    public Text m_txtRed;
    public Text m_txtGreen;
    public Text m_txtBlue;
    public Text m_txtResult;
    public Button m_btnOK;
    public Button m_btnClear;

    void Start()
    {
        m_sldRed.onValueChanged.AddListener(OnValueChanged_Red);
        m_sldGreen.onValueChanged.AddListener(OnValueChanged_Green);
        m_sldBlue.onValueChanged.AddListener(OnValueChanged_Blue);
        m_btnOK.onClick.AddListener(OnClicked_OK);
        m_btnClear.onClick.AddListener(OnClicked_Clear);
    }

    void OnValueChanged_Red(float value)
    {
        m_txtRed.color = new Color(value / 255, 0, 0);
        m_txtRed.text = $"{value}";
        SetColor();
    }
    void OnValueChanged_Green(float value)
    {
        m_txtGreen.color = new Color(0, value / 255, 0);
        m_txtGreen.text = $"{value}";
        SetColor();
    }
    void OnValueChanged_Blue(float value)
    {
        m_txtBlue.color = new Color(0, 0, value / 255);
        m_txtBlue.text = $"{value}";
        SetColor();
    }
    void SetColor()
    {
        byte r = (byte)m_sldRed.value;
        byte g = (byte)m_sldGreen.value;
        byte b = (byte)m_sldBlue.value;
        m_txtResult.color = new Color32(r, g, b, 255);
    }
    void OnClicked_OK()
    {
        m_txtResult.text = $"당신이 선택한 색깔은 {m_sldRed.value}, {m_sldGreen.value}, {m_sldBlue.value} 입니다.";
    }
    void OnClicked_Clear()
    {
        m_sldRed.value = 0;
        m_sldGreen.value = 0;
        m_sldBlue.value = 0;
        m_txtResult.text = string.Empty;
    }
}
