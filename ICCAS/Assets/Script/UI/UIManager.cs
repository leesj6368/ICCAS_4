using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    private void Awake()
    {
        instance = this;
    }

    #region �Ʒ��� �޴���
    public BottomBar bB;
    public int barSelect;
    #endregion

    #region
    #endregion

    public void ClosePanel(GameObject gameObjs)
    {
        gameObjs.SetActive(false);
    }
}
