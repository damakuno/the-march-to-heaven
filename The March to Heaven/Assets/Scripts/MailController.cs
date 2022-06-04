using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailController : MonoBehaviour
{
    [SerializeField]
    GameObject notifArea;
    [SerializeField]
    MailNotif p_mailNotif;
    [SerializeField]
    TextAsset dataJson;
    GameData gameData;

    public bool isMailOpen;
    List<MailNotif> mailItemList;
    string currMailId = ""; //if isMailOpen == true, stores the mailId reference for mailItemList
    AudioManager am;

    // Start is called before the first frame update
    void Awake()
    {
        // import mail data
        gameData = JsonUtility.FromJson<GameData>(dataJson.text);
        am = FindObjectOfType<AudioManager>();
    }

    public void SendMail(MailData md)
    {
        MailNotif temp = Instantiate(p_mailNotif, notifArea.transform).GetComponent<MailNotif>();
        temp.InitMailNotif(md);
    }

    public void SendMail(string mailname)
    {
        MailData md = Array.Find(gameData.mailDatas, m => m.name == mailname);
        MailNotif temp = Instantiate(p_mailNotif, notifArea.transform).GetComponent<MailNotif>();
        temp.InitMailNotif(md);
    }

    // Send all mail on a specific day
    public void SendAllMailOnDay(int dayNum)
    {
        MailData[] mds = Array.FindAll(gameData.mailDatas, m => m.daySent == dayNum);
        foreach(MailData md in mds)
        {
            MailNotif temp = Instantiate(p_mailNotif, notifArea.transform).GetComponent<MailNotif>();
            temp.InitMailNotif(md);
        }
    }

    public void SendBillWarningMail()
    {
        MailData md = Array.Find(gameData.mailDatas, m => m.name == "billwarningtemplate");
        MailNotif temp = Instantiate(p_mailNotif, notifArea.transform).GetComponent<MailNotif>();
        temp.InitMailNotif(md);
    }
}

[Serializable]
public struct GameData
{
    public MailData[] mailDatas;
}

[System.Serializable]
public struct MailData
{
    public string name, title, content;
    public int daySent;
}