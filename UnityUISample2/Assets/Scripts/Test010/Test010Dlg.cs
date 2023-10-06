using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test010Dlg : MonoBehaviour
{
    public ScrollRect m_SV;
    public Text m_txtResult;
    public Button m_btnOK;
    public Button m_btnClear;
    public GameObject m_PrbItem;
    public Transform m_ItemParent;

    List<Animal> m_Animals = new List<Animal>();

    int curIdx = -1;
    
    void Start()
    {
        m_btnOK.onClick.AddListener(OnClicked_OK);
        m_btnClear.onClick.AddListener(OnClikced_Clear);

        CreateItem("사자", 0);
        CreateItem("호랑이", 1);
        CreateItem("개", 2);
        CreateItem("박쥐", 3);
        CreateItem("토끼", 4);
    }

    void CreateItem(string name, int idx)
    {
        GameObject go = Instantiate(m_PrbItem, m_ItemParent);
        Animal kAnim = go.GetComponent<Animal>();
        kAnim.Initialize(name, idx);
        m_Animals.Add(kAnim);
        Button kButton = go.GetComponent<Button>();
        kButton.onClick.AddListener(() => OnClicked_Item(idx));
    }

    void OnClicked_OK()
    {
        if(curIdx == -1)
        {
            m_txtResult.text = $"동물을 선택해주세요.";
        }
        m_txtResult.text = $"선택한 동물은 <color=#FF0000>{m_Animals[curIdx].m_txtName.text}</color> 입니다.";
    }
    void OnClikced_Clear()
    {
        m_txtResult.text = string.Empty;
    }
    void OnClicked_Item(int idx)
    {
        curIdx = idx;
        for (int i = 0; i < m_ItemParent.childCount; i++)
        {
            m_ItemParent.GetChild(i).GetComponent<Text>().color = Color.black;
        }
        m_ItemParent.GetChild(idx).GetComponent<Text>().color = Color.red;

        m_txtResult.text = $"<color=#FF0000>{m_ItemParent.GetChild(idx).GetComponent<Animal>().m_txtName.text}</color>";
    }
}
