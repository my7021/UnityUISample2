using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StudentItem : MonoBehaviour
{
    public Text m_txtNum;
    public Text m_txtName;
    public Text m_txtKor;
    public Text m_txtEng;
    public Text m_txtMath;
    public Text m_txtSum;
    public Text m_txtAvg;

    public int m_num;
    public string m_name;
    public int m_kor;
    public int m_eng;
    public int m_math;
    public int m_sum;
    public float m_avg;

    Image img;
    void Awake()
    {
        img = GetComponent<Image>();
    }

    public void SetInfo(int num, string name, int kor, int eng, int math)
    {
        m_num = num;
        m_name = name;
        m_kor = kor;
        m_eng = eng;
        m_math = math;
        m_sum = kor + eng + math;
        m_avg = (float)m_sum / 3;
    }

    public void SetString()
    {
        m_txtNum.text = m_num.ToString();
        m_txtName.text = m_name;
        m_txtKor.text = m_kor.ToString();
        m_txtEng.text = m_eng.ToString();
        m_txtMath.text = m_math.ToString();
        m_txtSum.text = m_sum.ToString();
        m_txtAvg.text = $"{m_avg:0.00}";
    }

    public void SetColor(bool isSelected)
    {
        if (!isSelected)
            img.color = Color.white;
        else
            img.color = Color.green;
    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }
}
