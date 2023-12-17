using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UiManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI enemyAmountText;
    public GameObject GameOverPanel;
    public GameObject GamWinPanel;

    public static UiManager ins;
    private void Awake()
    {
         ins = this;
    }
}
