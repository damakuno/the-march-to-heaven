using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MailNotif : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField]
    Sprite spr_unread;
    [SerializeField]
    Sprite spr_read;
    [SerializeField]
    TextMeshProUGUI headerText;
    [SerializeField]
    TextMeshProUGUI previewText, dateText;
    Image bgImage;

    MailController mailCtrller;
    DayEventsManager dm;

    // port over from MailItem in love2D
    string title, content;
    int daySent;
    bool isRead;

    // Start is called before the first frame update
    void Awake()
    {
        bgImage = GetComponent<Image>();
        mailCtrller = FindObjectOfType<MailController>();
        dm = FindObjectOfType<DayEventsManager>();
    }

    // Update is called once per frame
    public void InitMailNotif(MailData data)
    {
        title = data.title;
        content = data.content;
        daySent = data.daySent;
        headerText.text = title;
        previewText.text = content;
        dateText.text = dm.GetFormattedDate(daySent);
    }

    public void OpenMail()
    {
        if (!isRead)
        {
            isRead = true;
            bgImage.sprite = spr_read;
            //
        }
        mailCtrller.isMailOpen = true;
    }

    public void CloseMail()
    {
        mailCtrller.isMailOpen = false;
    }
}
