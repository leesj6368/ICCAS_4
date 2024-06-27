using PlayFab;
using PlayFab.ClientModels;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBase : MonoBehaviour
{
    public static DataBase instance;

    private void Awake()
    {
        if(instance != null)
            Destroy(instance);
        else
            instance = this;

        DontDestroyOnLoad(gameObject);
    }

    private void DisplayPlayfabError(PlayFabError error) => Debug.LogError("error : " + error.GenerateErrorReport());

    #region ����� ������ ���� ���� �� �ʱ�ȭ
    public PlayerData playerData = new PlayerData();
    public CharacterData enemyData = new CharacterData();
    #endregion

    #region ������ ����
    // ������ ����
    public void SaveJsonToPlayfab()
    {
        Dictionary<string, string> dataDic = new Dictionary<string, string>();

        // ������ �����ϱ� �߰�
        dataDic.Add("DataContent", JsonUtility.ToJson(playerData));
        dataDic.Add("DataContent1", JsonUtility.ToJson(enemyData));

        SetUserData(dataDic);
    }

    public void SetUserData(Dictionary<string, string> data)
    {
        var request = new UpdateUserDataRequest() { Data = data, Permission = UserDataPermission.Public };
        try
        {
            PlayFabClientAPI.UpdateUserData(request, (result) =>
            {
                Debug.Log("Update Player Data!");

            }, DisplayPlayfabError);
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
        }
    }

    // ������ �ҷ�����
    public void GetUserData()
    {
        var request = new GetUserDataRequest() { PlayFabId = PlayFabLogin.instance.myID };
        PlayFabClientAPI.GetUserData(request, (result) =>
        {
            foreach (var eachData in result.Data)
            {
                string key = eachData.Key;

                // ������ �ҷ����� �߰�
                if (key == "DataContent")
                {
                    playerData = JsonUtility.FromJson<PlayerData>(eachData.Value.Value);

                    Debug.Log(playerData);
                }
                if (key == "DataContent1")
                {
                    enemyData = JsonUtility.FromJson<CharacterData>(eachData.Value.Value);

                    Debug.Log(enemyData);
                }
            }

        }, DisplayPlayfabError);
    }
    #endregion
}

[Serializable]
public struct PlayerData
{
    public int level;
    public int exp;
    public int gold;
    public int curStage;
    public int topStage;

    // Daily �Ǵ�
    public bool isSurvey;
}

[Serializable]
public struct CharacterData
{
    public int level;
    public bool[] skinOpen;
}
