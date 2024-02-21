using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BepInEx;
using K8Lib;

namespace K8Lib_Examples
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    [BepInDependency("K8Lib")]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            Logger.LogInfo($"{PluginInfo.PLUGIN_NAME} V{PluginInfo.PLUGIN_VERSION} has loaded");

            ConsoleCommand consoleCommand = new ConsoleCommand("exampleCommand", exampleCommandPrint);
        }

        private void Update()
        {
            addSettings();
        }

        private void addSettings()
        {
            SettingsManager.SettingsElement.TitleBar titleBar = new SettingsManager.SettingsElement.TitleBar("ExapleTitle", "Example Title");
            SettingsManager.SettingsElement.CheckBox checkBox = new SettingsManager.SettingsElement.CheckBox("ExampleCheckBox", "Example Check Box", true, checkBoxChange);
            SettingsManager.SettingsElement.Slider slider = new SettingsManager.SettingsElement.Slider("ExampleSlider", "Example Slider", 50, 0, 100, true, sliderChange);
            List<string> list = ["example option 1", "example option 2", "example option 3", "example option 4", "example option 5", "example option 6", "example option 7"];
            SettingsManager.SettingsElement.DropDown dropdown = new SettingsManager.SettingsElement.DropDown("FunnyDropdown", "Funny Dropdown", list, 0, dropDownChange);
            SettingsManager.SettingsElement.TextInput textBox = new SettingsManager.SettingsElement.TextInput("ExampleTextBox", "Example Text Box", "Example Text", "Exaple Placholder Text", textChange);
        }

        public void checkBoxChange(bool value)
        {
            GTTOD_HUD hud = FindAnyObjectByType<GTTOD_HUD>();
            if (hud != null)
            {
                hud.CenterPopUp("Checkbox changed to " + value.ToString(), 20, 10f);
            }
        }
        public void sliderChange(float value)
        {
            GTTOD_HUD hud = FindAnyObjectByType<GTTOD_HUD>();
            if (hud != null)
            {
                hud.CenterPopUp("slider changed to " + value.ToString(), 20, 10f);
            }
        }
        public void dropDownChange(int value)
        {
            GTTOD_HUD hud = FindAnyObjectByType<GTTOD_HUD>();
            if (hud != null)
            {
                hud.CenterPopUp("dropdown changed to " + value.ToString(), 20, 10f);
            }
        }

        public void textChange(string value)
        {
            GTTOD_HUD hud = FindAnyObjectByType<GTTOD_HUD>();
            if (hud != null)
            {
                hud.CenterPopUp("text changed to " + value, 20, 10f);
            }
        }

        public void exampleCommandPrint(string value)
        {
            GTTOD_HUD hud = FindAnyObjectByType<GTTOD_HUD>();
            if (hud != null)
            {
                hud.CenterPopUp(value, 20, 10f);
            }
        }
    }
}
