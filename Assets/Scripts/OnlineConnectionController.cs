using System;
using System.Text;
using System.Collections;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.Networking;

public class OnlineConnectionController : MonoBehaviour
{
    public static OnlineConnectionController Instance { get; private set; }
    public static bool IsOnline { get; private set; } = true;

    private static string _scoreURL = "https://blebleble.000webhostapp.com/raff/score.php?";
    private static string _balanceURL = "https://blebleble.000webhostapp.com/raff/balance.php?";
    private static string _key = "meh";

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
            IsOnline = false;

        if (IsOnline)
        {
            StartCoroutine(TryRegister());
            StartCoroutine(GetCoins());
            StartCoroutine(GetGems());
        } else
        {
            MessageBoxPanelController.Instance.ShowMessage("Who stole internet from you?!", "Without active connection you won't be able to gain free coins, and your scores will not be uploaded..." + Environment.NewLine + "Little cats will be sad...");
        }
    }

    public IEnumerator SendScore(int score)
    {
        string id = SettingsController.DeviceID;
        string hash = id + score.ToString() + _key;
        hash = hash.ToMD5();
        StringBuilder url = new StringBuilder();
        url.Append(_scoreURL);
        url.Append("id=" + id);
        url.Append("&");
        url.Append("score=" + score.ToString())
;
        url.Append("&");
        url.Append("hash=" + hash);
        WWW request = new WWW(url.ToString());

        yield return request;
    }
    public IEnumerator GetCoins()
    {
        string url = _balanceURL;
        url += "id=" + SettingsController.DeviceID;
        url += "&operation=" + ((int)OperationType.GetCoins).ToString();
        url += "&hash=" + (SettingsController.DeviceID + ((int)OperationType.GetCoins).ToString() + _key).ToMD5();
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();
            int coins;
            if(int.TryParse(request.downloadHandler.text, out coins))
            {
                WalletController.Instance.Coins = coins;
            } else
            {
                Debug.Log(request.downloadHandler.text);
            }
        }
    }
    public IEnumerator GetGems()
    {
        string url = _balanceURL;
        url += "id=" + SystemInfo.deviceUniqueIdentifier;
        url += "&operation=" + ((int)OperationType.GetGems).ToString();
        url += "&hash=" + (SettingsController.DeviceID + ((int)OperationType.GetCoins).ToString() + _key).ToMD5();
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();
            int gems;
            if (int.TryParse(request.downloadHandler.text, out gems))
            {
                WalletController.Instance.Gems = gems;
            }
            else
            {
                Debug.Log("Could not parse gems ammount");
            }
        }
    }
    public IEnumerator TryRegister()
    {
        string url = _balanceURL;
        url += "id=" + SystemInfo.deviceUniqueIdentifier;
        url += "&operation=" + ((int)OperationType.TryRegister).ToString();
        url += "&hash=" + (SettingsController.DeviceID + ((int)OperationType.GetCoins).ToString() + _key).ToMD5();
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();
            if(request.downloadHandler.text == "0") //Response from server - registered
            {
                WalletController.Instance.Coins = 0;
                WalletController.Instance.Gems = 0;
            }
        }
    }

    public enum OperationType
    {
        GetCoins,
        GetGems,
        AddCoins,
        AddGems,
        TryRegister
    }
}

