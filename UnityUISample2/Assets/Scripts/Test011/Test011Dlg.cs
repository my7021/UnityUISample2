using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test011Dlg : MonoBehaviour
{
    public ScrollRect m_SR;
    public Text m_txtResult;
    public Button m_btnOK;
    public Button m_btnClear;
    public GameObject m_prbItem;
    public Transform m_prbParent;

    List<TextItem> m_items = new List<TextItem>();
    List<GameObject> m_prbs = new List<GameObject>();
    string[] m_names = { "강아지", "고양이", "키위새", "뱀", "양아치", "장다민", "김재원" };

    TextItem curItem;

    void Start()
    {
        m_btnOK.onClick.AddListener(OnClicked_OK);
        m_btnClear.onClick.AddListener(OnClicked_Clear);
        for (int i = 0; i < m_names.Length; i++)
        {
            CreateItem(i, m_names[i]);
        }
    }
    public void CreateItem(int idx, string name)
    {
        GameObject go = Instantiate(m_prbItem, m_prbParent);
        m_prbs.Add(go);
        TextItem kItem = go.GetComponent<TextItem>();
        kItem.Initialize(idx, name);
        m_items.Add(kItem);
        Button kBtn = go.GetComponent<Button>();
        kBtn.onClick.AddListener(() => OnClicked_Item(idx));
    }

    void OnClicked_Item(int idx)
    {
        curItem = m_items[idx];
        for (int i = 0; i < m_items.Count; i++)
        {
            m_items[i].m_txtName.color = Color.black;
        }
        curItem.m_txtName.color = Color.white;
        m_txtResult.text = $"<color=#FFFFFF>{curItem.m_txtName.text}</color>";
    }
    void OnClicked_OK()
    {
        if (curItem == null)
        {
            m_txtResult.text = "동물을 선택해주세요.";
            return;
        }
        m_txtResult.text = $"당신이 선택한 동물은 <color=#FFFFFF>{curItem.m_txtName.text}</color> 입니다.";
    }
    void OnClicked_Clear()
    {
        for (int i = 0; i < m_prbs.Count; i++)
        {
            Destroy(m_prbs[i]);
        }
        m_items.Clear();
        curItem = null;
        m_txtResult.text = string.Empty;
    }
}
