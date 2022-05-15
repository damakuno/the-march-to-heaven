using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using Enumerations;

public class PhoneController : MonoBehaviour
{
    PhoneState curPhoneState = PhoneState.Minimized;
    [SerializeField]
    Button btn_hidePhone;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void OnPhoneHover()
    {
        if (curPhoneState != PhoneState.Active)
        {
            // popup phone a little
            GetComponent<RectTransform>().DOAnchorPosY(-368f, 0.5f);
            curPhoneState = PhoneState.Peeking;
        }
    }

    public void OnPhoneUnhover()
    {
        if (curPhoneState != PhoneState.Active)
        {
            // return phone back to minimized state from 
            GetComponent<RectTransform>().DOAnchorPosY(-457f, 0.5f);
            curPhoneState = PhoneState.Minimized;
        }
    }

    public void OnPhoneClicked()
    {
        if (curPhoneState != PhoneState.Active)
        {
            curPhoneState = PhoneState.Active;
            GetComponent<RectTransform>().DOAnchorPosY(0f, 0.7f)
                .OnComplete(() => btn_hidePhone.gameObject.SetActive(true));
        }
    }

    public void OnHidePhone()
    {
        if (curPhoneState == PhoneState.Active)
        {
            GetComponent<RectTransform>().DOAnchorPosY(-457f, 0.7f)
                .OnComplete(() =>
                {
                    curPhoneState = PhoneState.Minimized;
                    btn_hidePhone.gameObject.SetActive(false);
                });
        }
    }
}
