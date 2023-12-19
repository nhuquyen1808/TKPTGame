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
    public GameObject instructionPanel;

    public static UiManager ins;
    private void Awake()
    {
        ins = this;

    }

    private void Start()
    {
        StartCoroutine(HideInstructionPanel());
    }
    IEnumerator HideInstructionPanel()
    {
        yield return new WaitForSeconds(4);
        instructionPanel.gameObject.SetActive(false);
    }
}
