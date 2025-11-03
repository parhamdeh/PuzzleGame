using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsScript : MonoBehaviour
{
    [SerializeField]
    private GameObject SettingsPanel;
    [SerializeField]
    private Animator Settingsanim;
    public void OpenSettiongsPanel()
    {
        SettingsPanel.SetActive(true);
        Settingsanim.Play("SlideIn");
    }

    // Update is called once per frame
    public void CloseSettingsPanel()
    {
        StartCoroutine(CloseSettings());
    }
    IEnumerator CloseSettings()
    {
        Settingsanim.Play("SlideOut");
        yield return new WaitForSeconds(1f);
        SettingsPanel.SetActive(false);

    }
}
