using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTest : MonoBehaviour
{
    [Header("InputField")]
    public InputField m_infNum;
    public InputField m_infName;
    public InputField m_infKor;
    public InputField m_infEng;
    public InputField m_infMath;
    [Header("Button")]
    public Button m_btnAdd;
    public Button m_btnEdit;
    public Button m_btnRemove;
    public Button m_btnSave;
    public Button m_btnLoad;
    public Button m_btnClear;
    public Button m_btnSort;
    [Header("Item")]
    public GameObject m_prbItem;
    public Transform m_itemParent;

    List<GameObject> m_items = new List<GameObject>();

    StudentItem curItem;

    void Start()
    {
        m_btnAdd.onClick.AddListener(OnClicked_Add);
        m_btnEdit.onClick.AddListener(OnClicked_Edit);
        m_btnRemove.onClick.AddListener(OnClicked_Remove);
        m_btnSave.onClick.AddListener(OnClicked_Save);
        m_btnLoad.onClick.AddListener(OnClicked_Load);
        m_btnClear.onClick.AddListener (OnClicked_Clear);
        m_btnSort.onClick.AddListener(OnClicked_Sort);
    }

    void OnClicked_Add()
    {
        if (InfCheck())
            return;
        int num = int.Parse(m_infNum.text);
        string name = m_infName.text;
        int kor = int.Parse(m_infKor.text);
        int eng = int.Parse(m_infEng.text);
        int math = int.Parse(m_infMath.text);
        CreateItem(num, name, kor, eng, math);
        InfClear();
    }
    bool InfCheck()
    {
        if(m_infNum.text == string.Empty || m_infName.text == string.Empty || m_infKor.text == string.Empty || m_infEng.text == string.Empty || m_infMath.text == string.Empty)
        {
            return true;
        }
        return false;
    }
    void CreateItem(int num, string name, int kor, int eng, int math)
    {
        GameObject go = Instantiate(m_prbItem, m_itemParent);
        StudentItem kStu = go.GetComponent<StudentItem>();
        kStu.SetInfo(num, name, kor, eng, math);
        kStu.SetString();
        Button kBtn = go.GetComponent<Button>();
        kBtn.onClick.AddListener(() => OnClicked_Item(kStu));
        m_items.Add(go);
    }
    void OnClicked_Edit()
    {
        if (curItem == null)
            return;

        int num = int.Parse(m_infNum.text);
        string name = m_infName.text;
        int kor = int.Parse(m_infKor.text);
        int eng = int.Parse(m_infEng.text);
        int math = int.Parse(m_infMath.text);
        curItem.SetInfo(num, name, kor, eng, math);
        curItem.SetString();
    }
    void OnClicked_Remove()
    {
        if (curItem == null)
            return;
        curItem.DestroyMe();
        curItem = null;
        InfClear();
    }
    void OnClicked_Save()
    {
        StreamWriter sw = new StreamWriter("ScoreTest.txt");
        sw.WriteLine(m_items.Count);
        for (int i = 0; i < m_items.Count; i++)
        {
            StudentItem item = m_items[i].GetComponent<StudentItem>();
            sw.WriteLine(item.m_num);
            sw.WriteLine(item.m_name);
            sw.WriteLine(item.m_kor);
            sw.WriteLine(item.m_eng);
            sw.WriteLine(item.m_math);
        }
        sw.Close();
    }
    void OnClicked_Load()
    {
        OnClicked_Clear();
        StreamReader sr = new StreamReader("ScoreTest.txt");
        int count = int.Parse(sr.ReadLine());
        for (int i = 0; i < count; i++)
        {
            int num = int.Parse(sr.ReadLine());
            string name = sr.ReadLine();
            int kor = int.Parse(sr.ReadLine());
            int eng = int.Parse(sr.ReadLine());
            int math = int.Parse(sr.ReadLine());
            CreateItem(num, name, kor, eng, math);
        }
        sr.Close();
    }
    void OnClicked_Item(StudentItem item)
    {
        curItem = item;
        m_infNum.text = item.m_num.ToString();
        m_infName.text = item.m_name;
        m_infKor.text = item.m_kor.ToString();
        m_infEng.text = item.m_eng.ToString();
        m_infMath.text = item.m_math.ToString();

        for (int i = 0; i < m_items.Count; i++)
        {
            m_items[i].GetComponent<StudentItem>().SetColor(false);
        }
        curItem.SetColor(true);
    }
    void OnClicked_Sort()
    {
        SortItem();
    }
    void SortItem()
    {
        m_items.Sort((a, b) => a.GetComponent<StudentItem>().m_sum < b.GetComponent<StudentItem>().m_sum ? 1 : -1);
        for (int i = 0; i < m_items.Count; i++)
        {
            m_items[i].GetComponent<StudentItem>().SetString();
        }
    }
    void OnClicked_Clear()
    {
        m_items.Clear();
        for (int i = 0; i < m_itemParent.childCount; i++)
        {
            Destroy(m_itemParent.GetChild(i).gameObject);
        }
        InfClear();
    }
    void InfClear()
    {
        m_infNum.text = string.Empty;
        m_infName.text = string.Empty;
        m_infKor.text = string.Empty;
        m_infEng.text = string.Empty;
        m_infMath.text = string.Empty;
    }
}
