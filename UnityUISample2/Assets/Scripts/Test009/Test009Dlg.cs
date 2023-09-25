using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test009Dlg : MonoBehaviour
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
        Dropdown.OptionData od4 = new Dropdown.OptionData("����");
        Dropdown.OptionData od5 = new Dropdown.OptionData("���");
        m_dd.options[0].text = "����";
        m_dd.options[1].text = "�λ�";
        m_dd.options[2].text = "�ͻ�";
        m_dd.options.Add(od4);
        m_dd.options.Add(od5);
    }

    void OnValueChanged_dd(int value)
    {
        m_txtResult.text = $"{value+1} : {m_dd.options[value].text}";
    }
    void OnClicked_OK()
    {
        m_txtResult.text = $"����� �̵��� ���ô� {m_dd.options[m_dd.value].text}�Դϴ�.";
    }
    void OnClicked_Clear()
    {
        m_dd.value = 0;
        m_txtResult.text = string.Empty;
    }
}
