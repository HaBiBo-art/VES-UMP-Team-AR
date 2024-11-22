using System.Collections;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class LanguageSwitcher : MonoBehaviour
{
    public void SwitchLanguage(string localeCode)
    {
        StartCoroutine(SetLocale(localeCode));
    }

    private IEnumerator SetLocale(string localeCode)
    {
        // Wait for LocalizationSettings to initialize
        yield return LocalizationSettings.InitializationOperation;

        // Find the desired locale by code
        var locale = LocalizationSettings.AvailableLocales.GetLocale(localeCode);

        if (locale != null)
        {
            LocalizationSettings.SelectedLocale = locale;
            Debug.Log($"Language switched to: {locale.Identifier.Code}");
        }
        else
        {
            Debug.LogWarning($"Locale '{localeCode}' not found!");
        }
    }
}
