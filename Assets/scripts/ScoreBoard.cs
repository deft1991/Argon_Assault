using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] private int scorePerHit = 12;
    
    private int m_Score;

    private Text m_ScoreText;

    // Start is called before the first frame update
    void Start()
    {
        m_ScoreText = GetComponent<Text>();
        m_ScoreText.text = m_Score.ToString();
    }

    /**
     * increase scores by hit 
     */
    public void ScoreHit()
    {
        m_Score += scorePerHit;
        m_ScoreText.text = m_Score.ToString();
    }
}