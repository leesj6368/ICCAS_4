using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;

public class PlayFabManager : MonoBehaviour
{
    public static PlayFabManager instance; // 싱글톤 인스턴스 정의

    public InputField EmailInput, PasswordInput, UsernameInput;
    public string myID;

    private void Awake()
    {
        // 싱글톤 인스턴스 초기화
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // 씬이 바뀌어도 오브젝트가 파괴되지 않도록 함
        }
        else
        {
            Destroy(gameObject); // 이미 인스턴스가 존재하면 새로운 오브젝트를 파괴
        }
    }

    public void LoginBtn() // 로그인
    {
        if (string.IsNullOrEmpty(PlayFabSettings.staticSettings.TitleId)){
            PlayFabSettings.staticSettings.TitleId = "AC580";
        }
        
        var request = new LoginWithEmailAddressRequest { Email = EmailInput.text, Password = PasswordInput.text };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnLoginFailure);
    }

    public void RegisterBtn()
    {
        if (string.IsNullOrEmpty(PlayFabSettings.staticSettings.TitleId)){
            PlayFabSettings.staticSettings.TitleId = "AC580";
        }
        
        var request = new RegisterPlayFabUserRequest { Email = EmailInput.text, Password = PasswordInput.text, Username = UsernameInput.text };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnRegisterFailure);
    }

    private void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("로그인 성공");
    }

    private void OnLoginFailure(PlayFabError error)
    {
        Debug.Log("로그인 실패");
    }

    private void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        Debug.Log("회원가입 성공");
    }

    private void OnRegisterFailure(PlayFabError error)
    {
        Debug.Log("회원가입 실패");
    }
}