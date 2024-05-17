using System;
using System.Collections.Generic;
using UnityEngine;
using BepInEx;
using K8Lib.Settings;
using K8Lib.Commands;
using K8Lib.Inventory;
using System.Configuration;
using System.IO;
using System.Reflection;
using UnityEngine.SceneManagement;

namespace K8Lib_Examples
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    [BepInDependency("K8Lib")]
    public class Plugin : BaseUnityPlugin
    {
        Sprite icon;

        private void Awake()
        {
            var assembly = Assembly.GetExecutingAssembly();
            using (var stream = assembly.GetManifestResourceStream("K8Lib_Examples.icon.sprite"))
            {
                if (stream == null)
                {
                    Logger.LogError("Failed to load asset bundle");
                    return;
                }

                using (var memoryStream = new MemoryStream())
                {
                    stream.CopyTo(memoryStream);
                    AssetBundle bundle = AssetBundle.LoadFromMemory(memoryStream.ToArray());
                    icon = bundle.LoadAsset<Sprite>("icon.sprite");
                }
            }

            Logger.LogInfo($"{PluginInfo.PLUGIN_NAME} V{PluginInfo.PLUGIN_VERSION} has loaded");
        }

        private void Start()
        {
            new TitleBar("ExampleTitle", "Example Title");
            new CheckBox("ExampleCheckBox", "Example Check Box", true, checkBoxChange);
            new Slider("ExampleSlider", "Example Slider", 0, 100, 50, true, sliderChange);
            List<string> list = ["example option 1", "example option 2", "example option 3", "example option 4", "example option 5", "example option 6", "example option 7"];
            new DropDown("ExampleDropdown", "Example Dropdown", list, 0, dropDownChange);
            new TextInput("ExampleTextBox", "Example Text Box", "Example Text", "Example Placeholder Text", textChange);

            new ConsoleCommand("exampleCommand", exampleCommandPrint);

            new InventoryIcon("ExampleIcon", "Example Icon", "This inventory icon has no amount", null, icon, inventoryIconClicked);
            new InventoryIcon("ExampleIcon2", "Example Icon 2", "This inventory icon has an amount", 69, icon, inventoryIconClicked);
        }

        public void checkBoxChange(bool value)
        {
            GameManager.GM.GetComponent<GTTOD_HUD>().CenterPopUp("Checkbox changed to " + value.ToString(), 20, 10f);
        }
        public void sliderChange(float value)
        {
            GameManager.GM.GetComponent<GTTOD_HUD>().CenterPopUp("slider changed to " + value.ToString(), 20, 10f);
        }
        public void dropDownChange(int value)
        {
            GameManager.GM.GetComponent<GTTOD_HUD>().CenterPopUp("dropdown changed to " + value.ToString(), 20, 10f);
        }

        public void textChange(string value)
        {
            GameManager.GM.GetComponent<GTTOD_HUD>().CenterPopUp("text changed to " + value, 20, 10f);
        }

        public void exampleCommandPrint(string value)
        {
            GameManager.GM.GetComponent<GTTOD_HUD>().CenterPopUp(value, 20, 10f);
        }

        public void inventoryIconClicked()
        {
            GameManager.GM.GetComponent<GTTOD_HUD>().CenterPopUp("Icon Clicked", 20, 10f);
        }
    }
}
