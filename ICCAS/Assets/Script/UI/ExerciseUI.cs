using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ExerciseUI : MonoBehaviour
{
    #region é��
    public GameObject[] chapterPanel;  // é�� �г�
    public GameObject[] startLockImg;
    #endregion

    #region �������� 
    public GameObject[] stageSelectPanels;
    public GameObject[] stagePanels;
   
    public GameObject[][] sBtns;
    public GameObject[][] saBtns;
    public GameObject[][] scBtns;

    private TextMeshProUGUI[] stageText;
    private TextMeshProUGUI[] expText;
    private TextMeshProUGUI[] goldText;
    
    public Button[] ecBtns;
    #endregion

    #region Exercise
    public GameObject exercisePanel;
    public Toggle[] exerciseToggle;
    public bool[] exerciseSelect;
    #endregion


    #region é�� ����
    private void Awake()
    {
        SetChapter();
        SetListener();
    }

    public void SetChapter()
    {
        stageText = new TextMeshProUGUI[stagePanels.Length];
        expText = new TextMeshProUGUI[stagePanels.Length];
        goldText = new TextMeshProUGUI[stagePanels.Length];
        sBtns = new GameObject[stagePanels.Length][];
        saBtns = new GameObject[stagePanels.Length][];
        scBtns = new GameObject[stagePanels.Length][];
        ecBtns = new Button[stagePanels.Length];

        for(int i = 0; i < stagePanels.Length; i++)
        {
            stageText[i] = stagePanels[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>();
            expText[i] = stagePanels[i].transform.GetChild(2).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
            goldText[i] = stagePanels[i].transform.GetChild(2).GetChild(0).GetChild(0).GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>();
            sBtns[i] = new GameObject[5];
            saBtns[i] = new GameObject[5];
            scBtns[i] = new GameObject[5];
            ecBtns[i] = stagePanels[i].transform.GetChild(3).GetComponent<Button>();

            for(int j = 0; j < sBtns[i].Length; j++)
            {
                sBtns[i][j] = stageSelectPanels[i].transform.GetChild(0).GetChild(3).GetChild(0).GetChild(0).GetChild(j).GetChild(1).GetChild(0).gameObject;
                saBtns[i][j] = stageSelectPanels[i].transform.GetChild(0).GetChild(3).GetChild(0).GetChild(0).GetChild(j).GetChild(1).GetChild(1).gameObject;
                scBtns[i][j] = stageSelectPanels[i].transform.GetChild(0).GetChild(3).GetChild(0).GetChild(0).GetChild(j).GetChild(1).GetChild(2).gameObject;
            }
        }
    }
    public void SetListener()
    {
        for(int i = 0; i < stageSelectPanels.Length; i++)
        {
            for(int j = 0; j < sBtns[i].Length; j++)
            {
                int temp = j;
                sBtns[i][j].GetComponent<Button>().onClick.AddListener(() => SelectStage(temp));
            }
        }

        for(int i = 0; i < ecBtns.Length; i++)
        {
            ecBtns[i].onClick.AddListener(OpenExercise);
        }
    }
    #endregion

    #region é�� ����
    // �ǿ��� Exercise ���ý� ���� �ְ� ��Ʈ���� é�ͷ� �����ֱ�
    public void OpenExercisePanel(int index)
    {
        for (int i = 0; i < chapterPanel.Length; i++)
        {
            if (i == index)
            {
                chapterPanel[i].SetActive(true);
            }
            else
            {
                chapterPanel[i].SetActive(false);
            }
        }
    }

    // ���� é�ͷ� ���� ��ư�� �Ҵ�
    public void PrevOnClickChapterSelect(int index)
    {
        chapterPanel[index].SetActive(false);
        chapterPanel[index - 1].SetActive(true);
    }

    // ���� é�ͷ� ���� ��ư�� �Ҵ�
    public void NextOnClickChapterSelect(int index)
    {
        chapterPanel[index].SetActive(false);
        chapterPanel[index + 1].SetActive(true);
    }
    #endregion

    #region �������� ����
    public void SelectChapter(int index)
    {
        UIManager.instance.chapterSelect = index;

        OpenSelecStage(index);
        SelectStage(0);
    }

    public void OpenSelecStage(int index)
    {
        // ���� �ְ� �������� ������ ���� ������������ clear �� ǥ�� ���� ���������� ��� ǥ�� �ϰ� ��������

        for(int i = 0; i < 5; i++)
        {
            if (i == index)
                stageSelectPanels[i].SetActive(true);
            else
                stageSelectPanels[i].SetActive(false);
        }
    }

    public void SelectStage(int index)
    {
        for (int i = 0; i < 5; i++)
        {
            if (i == index)
            {
                sBtns[UIManager.instance.chapterSelect][i].SetActive(false);
                saBtns[UIManager.instance.chapterSelect][i].SetActive(true);
            }
            else
            {
                sBtns[UIManager.instance.chapterSelect][i].SetActive(true);
                saBtns[UIManager.instance.chapterSelect][i].SetActive(false);
            }
        }

        SetStageText(UIManager.instance.chapterSelect, index);
    }

    private void SetStageText(int chapterNum, int stageNum)
    {
        if(stageNum == 4)
            stageText[chapterNum].text = "BOSS ";
        else
            stageText[chapterNum].text = "STAGE " + (stageNum + 1);
    }
    #endregion

    #region Exercise
    public void OpenExercise()
    {
        exercisePanel.SetActive(true);
    }

    public void OnRaid(int index)
    {
        for(int i = 0; i < exerciseToggle.Length; i++)
        {
            if(i == index)
            {
                if (exerciseToggle[i].isOn)
                {
                    exerciseSelect[i] = true;
                }
                else
                {
                    exerciseSelect[i] = false;
                }
            }
            else
            {
                exerciseSelect[i] = false;
            }
        }
        
    }

    public void SelectExercise()
    {

    }
    #endregion
}
