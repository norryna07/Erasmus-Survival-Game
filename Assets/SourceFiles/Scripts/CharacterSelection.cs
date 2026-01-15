using UnityEngine;
using TMPro;
using System.IO;
using UnityEngine.SceneManagement;
using ErasmusGame.Models;


public class CharacterSelection : MonoBehaviour
{
    public TMP_InputField nameInput;
    public TMP_InputField surnameInput;
    public TMP_Dropdown genderDropdown;
    public TMP_Dropdown homeCountryDropdown;
    public TMP_Dropdown erasmusCountryDropdown;
    public TMP_Dropdown majorDropdown;
    public TMP_Text errorMessage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SavePlayer()
    {
        // error cases will display a text on the screen
        if (nameInput == null || string.IsNullOrEmpty(nameInput.text))
        {
            errorMessage.text = "You forgot your name";
            errorMessage.color = Color.red;
            return;
        }
        if (surnameInput == null || string.IsNullOrEmpty(surnameInput.text))
        {
            errorMessage.text= "You forgot your surname";
            errorMessage.color = Color.red;
            return;
        }
        string homeCountry = homeCountryDropdown.options[homeCountryDropdown.value].text;
        string erasmusCountry = erasmusCountryDropdown.options[erasmusCountryDropdown.value].text;

        if (homeCountry.Equals(erasmusCountry))
        {
            errorMessage.text = "You can't do Erasmus in your country.";
            errorMessage.color = Color.red;
            return;
        }

        // all good, let's save the player
        PlayerProfile playerProfile = new PlayerProfile
        {
            name = nameInput.text,
            surname = surnameInput.text,
            gender = genderDropdown.options[genderDropdown.value].text,
            homeCountry = homeCountry,
            erasmusCountry = erasmusCountry,
            major = majorDropdown.options[majorDropdown.value].text
        };

        string json = JsonUtility.ToJson(playerProfile, true);

        string path = Path.Combine(
            Application.persistentDataPath,
            "SaveData",
            "playerProfile.json"
        );

        File.WriteAllText(path, json);

        Debug.Log("Profile saved to: " + path);

        // go to the first scene of the game
        SceneManager.LoadScene("BeforeScene");
    }
}
