using UnityEngine;
using UnityEngine.UI;

public class Test006Dlg : MonoBehaviour
{
    public Scrollbar m_Sb;
    public Text m_txtResult;
    public Button m_btnOK;
    public Button m_btnClear;

    void Start()
    {
        m_Sb.onValueChanged.AddListener(OnValueChanged_Sb);
        m_btnOK.onClick.AddListener(OnClicked_OK);
        m_btnClear.onClick.AddListener(OnClicked_Clear);
    }

    void OnValueChanged_Sb(float value)
    {
        m_txtResult.text = value == 0 && value == 1 ? $"{value}" : $"{value:0.00}";
    }
    void OnClicked_OK()
    {
        m_txtResult.text = $"현재 진행된 값은 <color=#ff7f00>{m_Sb.value:0.00}</color> 입니다.";
    }
    void OnClicked_Clear()
    {
        m_Sb.value = 0;
        m_txtResult.text = string.Empty;
    }
}
