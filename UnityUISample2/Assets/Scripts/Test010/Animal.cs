using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Animal : MonoBehaviour
{
    public Text m_txtName;
    public int m_idx = -1;

    public void Initialize(string name, int idx)
    {
        m_txtName.text = name;
        m_idx = idx;
    }
}
