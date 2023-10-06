using UnityEngine;
using UnityEngine.UI;

public class TextItem : MonoBehaviour
{
    public int m_idx;
    public Text m_txtName;

    public void Initialize(int idx, string name)
    {
        m_idx = idx;
        m_txtName.text = name;
    }
}
