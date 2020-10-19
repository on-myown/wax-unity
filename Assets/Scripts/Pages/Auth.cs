using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Auth : MonoBehaviour
{
    public WAX Wax;
    
    public Auth()
    {
        Wax = new WAX("https://wax.greymass.com", null, null, false);
    }

    public void autoLogin()
    {
        bool isAutoLoginAvailable = Wax.isAutoLoginAvailable();
        if (isAutoLoginAvailable)
        {
            print("Auto Log In is available");
        }
        else
        {
            Wax.loginViaWindow();
//            SceneManager.LoadScene(1);
            
            print("Auto Log In is not available");
        }
    }
    public void OpenWAXLogIn()
    {
        autoLogin();
    }

}
