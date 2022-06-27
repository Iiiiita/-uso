using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    public GameObject SettingsPanel;
    public GameObject PrivacyPolicyPanel;
    public GameObject UserAgreementPanel;
    public GameObject CreditsPanel;
    public GameObject ExitAgreementButton;
    public GameObject ExitPolicyButton;
    public Toggle PrivacyPolicyCheckButton;
    public Toggle AgreementButton;

    public static bool isDone = false;

    // Start is called before the first frame update
    void Start()
    {
        SettingsPanel.SetActive(false);
        ExitAgreementButton.SetActive(false);
        ExitPolicyButton.SetActive(false);
        PrivacyPolicyPanel.SetActive(false);
        UserAgreementPanel.SetActive(false);
        CreditsPanel.SetActive(false);

        if (PlayerPrefs.GetInt("isAgreementCheck") == 1)
        {
            AgreementButton.isOn = true;
        }
        else
            AgreementButton.isOn = false;

        if (PlayerPrefs.GetInt("isPolicyCheck") == 1)
        {
            PrivacyPolicyCheckButton.isOn = true;
        }
        else
            PrivacyPolicyCheckButton.isOn = false;
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void OnPlayButtonClick()
    {
        PrivacyPolicyCheckButton.isOn = true;

        PlayerPrefs.SetInt("isPolicyCheck", 1);
        AgreementButton.isOn = true;
        PlayerPrefs.SetInt("isAgreementCheck", 1);
        SceneManager.LoadScene(1);
    }

    public void OnExitButtonClick()
    {
        SettingsPanel.SetActive(false);
    }

    public void OnSettingsButtonClick()
    {
        SettingsPanel.SetActive(true);
    }

    public void OnUserAgreementButtonClick()
    {
        UserAgreementPanel.SetActive(true);

        if (!AgreementButton.isOn)
        {
            AgreementButton.interactable = true;
            ExitAgreementButton.SetActive(false);
        }
        else
        {
            AgreementButton.interactable = false;
            ExitAgreementButton.SetActive(true);
        }
    }
    public void OnUserAgreementCheckButtonClick()
    {
        AgreementButton.isOn = true;
        AgreementButton.interactable = false;
        PlayerPrefs.SetInt("isAgreementCheck", 1);
        ExitAgreementButton.SetActive(true);
    }

    public void OnPrivacyPolicyButtonClick()
    {
        PrivacyPolicyPanel.SetActive(true);

        if (!PrivacyPolicyCheckButton.isOn)
        {
            PrivacyPolicyCheckButton.interactable = true;
            ExitPolicyButton.SetActive(false);
        }
        else
        {
            PrivacyPolicyCheckButton.interactable = false;
            ExitPolicyButton.SetActive(true);
        }

    }
    public void OnPrivacyPolicyCheckButtonClick()
    {
        PrivacyPolicyCheckButton.isOn = true;
        PrivacyPolicyCheckButton.interactable = false;
        PlayerPrefs.SetInt("isPolicyCheck", 1);
        ExitPolicyButton.SetActive(true);
    }

    public void ClosePolicy()
    {
        PrivacyPolicyPanel.SetActive(false);
    }

    public void CloseAgreement()
    {
        UserAgreementPanel.SetActive(false);
    }

    public void OnCreditsButtonClick()
    {
        CreditsPanel.SetActive(true);
    }

    public void OnExitCreditsButtonClick()
    {
        CreditsPanel.SetActive(false);
    }

    public void OnExitGameButtonClick()
    {
        Application.Quit();
    }
}
