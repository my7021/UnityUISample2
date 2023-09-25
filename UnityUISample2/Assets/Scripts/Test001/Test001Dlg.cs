using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test001Dlg : MonoBehaviour
{
    public InputField m_infName;
    public Text m_txtResult;
    public Button m_btnOK;
    public Button m_btnClear;

    void Start()
    {
        m_infName.onSubmit.AddListener(OnSubmit_Name);
        m_btnOK.onClick.AddListener(OnClicked_OK);
        m_btnClear.onClick.AddListener(OnClicked_Clear);
    }
    void OnSubmit_Name(string str)
    {
        m_txtResult.text = $"당신이 입력한 이름은 <color=\"#008000\">{m_infName.text}</color> 입니다.";
    }
    void OnClicked_OK()
    {
        m_txtResult.text = $"당신이 입력한 이름은 <color=\"#008000\">{m_infName.text}</color> 입니다.";
    }
    void OnClicked_Clear()
    {
        m_infName.text = string.Empty;
        m_txtResult.text = string.Empty;
    }
}
