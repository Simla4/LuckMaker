using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject startScene;
    [SerializeField] private GameObject failSecene;
    [SerializeField] private GameObject winScene;
    [SerializeField] private TextMeshProUGUI winCoinScore;
    [SerializeField] private TextMeshProUGUI winCloverScore;
    [SerializeField] private TextMeshProUGUI failCoinScore;
    [SerializeField] private TextMeshProUGUI failCloverScore;
    [SerializeField] private TextMeshProUGUI mainSceneText;
    [SerializeField] private GameObject mainScene;
    [SerializeField] private GameObject particle;

    public void StartScene()
    {
        startScene.SetActive(false);
    }

    public void FailScene(int luckValue, int coinValue)
    {
        failSecene.SetActive(true);
        mainScene.SetActive(false);
        failCloverScore.text = luckValue.ToString();
        failCoinScore.text = coinValue.ToString();
    }

    public void WinScene(int luckValue, int coinValue)
    {
        winScene.SetActive(true);
        mainScene.SetActive(false);
        winCloverScore.text = luckValue.ToString();
        winCoinScore.text = coinValue.ToString();
        particle.SetActive(true);
    }
    public void MainScene(int coinValue)
    {
        mainSceneText.text = coinValue.ToString();
    }
}
