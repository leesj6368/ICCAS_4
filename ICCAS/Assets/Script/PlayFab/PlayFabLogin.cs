using PlayFab;
using PlayFab.ClientModels;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;

public class PlayFabLogin : MonoBehaviour
{
    public static PlayFabLogin instance;

    //public TMP_InputField emailInput, passwardInput, nameInput;
    public string emailInput, passwardInput, nameInput;
    public string myID;

    private void Awake()
    {
        if (instance != null)
            Destroy(this.gameObject);
        else
            instance = this;

        DontDestroyOnLoad(gameObject);

        // �׽�Ʈ�� �α���/ȸ������
        EmailLogin();
        
        
    }

    public void EmailLogin()
    {
        //InputField�� �޾ƿö� ���
        //var request = new LoginWithEmailAddressRequest { Email = emailInput.text, Password = passwardInput.text };
        //PlayFabClientAPI.LoginWithEmailAddress(request, (result) => { print("�α��� ����"); myID = result.PlayFabId; }, (error) => print("�α��� ����"));

        //�׽�Ʈ�� 
        var request = new LoginWithEmailAddressRequest { Email = emailInput, Password = passwardInput };
        PlayFabClientAPI.LoginWithEmailAddress(request, (result) => { print("�α��� ����"); myID = result.PlayFabId; DataBase.instance.GetUserData(); }, (error) => { print("�α��� ����"); EmailRegister(); });
    }

    public void EmailRegister()
    {
        //InputField�� �޾ƿö� ���
        //var request = new RegisterPlayFabUserRequest { Email = emailInput.text, Password = passwardInput.text, Username = nameInput.text };
        //PlayFabClientAPI.RegisterPlayFabUser(request, (result) => print("ȸ������ ����"), (error) => print("ȸ������ ����"));

        //�׽�Ʈ�� 
        var request = new RegisterPlayFabUserRequest { Email = emailInput, Password = passwardInput, Username = nameInput };
        PlayFabClientAPI.RegisterPlayFabUser(request, (result) => { print("ȸ������ ����"); EmailLogin(); }, (error) => print("ȸ������ ����"));
    }
}
