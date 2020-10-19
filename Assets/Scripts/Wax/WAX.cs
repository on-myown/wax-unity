using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Networking;

public class IWishlistedContract
{
    string contract { get; set; }
    string domain { get; set; }
    string[] recipients { get; set; }
}

public class LogInData
{
    bool verfied { get; set; }
    string userAccount { get; set; }
    string[] pubKeys { get; set; }
    string autoLogin { get; set; }
}

public class WAX
{
    private string userAccount;
    private string[] pubKeys;
    private string waxSigningURL = "https://all-access.wax.io";
    public WAX(string _rpcEndpoint, string _userAccount, string[] _pubKeys, bool _tryAutoLogin)
    {
        userAccount = _userAccount;
        pubKeys = _pubKeys;
        if (userAccount != null && pubKeys !=null)
        {
 //           receiveLogin({ data});
        }
    }

    public void receiveLogin(LogInData data)
    {
    }
    public IEnumerator LogInViaEndpoint()
    {
        string url = "https://api-idm.wax.io/v1/accounts/auto-accept/login";
        var request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();
      

        if (request.isNetworkError)
        {
            Debug.Log("Error While Sending: " + request.error);
        }
        else
        {
            var data = request.downloadHandler.text;
            Debug.Log("Received: " + data);
        }
       
    }

    public void loginViaWindow()
    {
        string endpoint = waxSigningURL + "/cloud-wallet/login/";

        var webViewGameObject = new GameObject("UniWebView");
        UniWebView webView;
        webView = webViewGameObject.AddComponent<UniWebView>();


        webView.Frame = new Rect(0, 0, Screen.width, Screen.height); // 1
        webView.Load(endpoint);       // 2
        webView.Show();

        webView.OnPageFinished += (view, statusCode, url) =>
        {
            Debug.Log(view);
            Debug.Log(statusCode);
            Debug.Log(url);
        };

//        UnityWebRequest www = UnityWebRequest.Get(url);
//        yield return www.SendWebRequest();

    }
    public bool isAutoLoginAvailable()
    {
    
        return false;
    }


}
