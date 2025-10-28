/* 
	Stick Crafter Junkyard
 	Create Folder Structure Script
*/

#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class CreateFolderStructure : ScriptableWizard
{

    public string FolderName = "_Game";
    private string SFGUID;
    List<string> folders = new List<string>() { "Animations","Animator","Fonts","Image","Materials","Models","Sound", "Scripts", "Resources", "Scenes", "Prefabs", "ThirdParty" };
    List<string> scriptsFolders = new List<string>() { "Editor", "Shaders","Base","Common","Controller","View" };



    List<string> controllerScriptsFolders = new List<string>() { "Audio", "Camera", "Character", "Items" };

    List<string> resourcesFolders = new List<string>() { "Characters", "Managers", "Props", "UI" };

    [MenuItem("Stick Crafter/Create Project Folders")]
    static void CreateWizard()
    {
        ScriptableWizard.DisplayWizard("Create Project Folders", typeof(CreateFolderStructure), "Create");
    }

    //Called when the window first appears
    void OnEnable()
    {

    }
    //Create button click
    void OnWizardCreate()
    {
        // creates the primary folder for game
        string primaryFolder = AssetDatabase.CreateFolder("Assets", FolderName);

        //create all the folders required in a project
        foreach (string folder in folders)
        {
            string guid = AssetDatabase.CreateFolder("Assets/" + FolderName, folder);
            string newFolderPath = AssetDatabase.GUIDToAssetPath(guid);
            if (folder == "Scripts")
                SFGUID = newFolderPath;
        }

        AssetDatabase.Refresh();

        //foreach (string art in ArtFolders)
        //{
        //    //AssetDatabase.Contain
        //    string guid = AssetDatabase.CreateFolder("Assets/" + FolderName + "/Art", art);
        //    string newFolderPath = AssetDatabase.GUIDToAssetPath(guid);

        //}

        AssetDatabase.Refresh();

        foreach (string script in scriptsFolders)
        {
            //AssetDatabase.Contain
            string guid = AssetDatabase.CreateFolder("Assets/" + FolderName + "/Scripts", script);
            string newFolderPath = AssetDatabase.GUIDToAssetPath(guid);

        }
        foreach (string script in controllerScriptsFolders)
        {
            //AssetDatabase.Contain
            string guid = AssetDatabase.CreateFolder("Assets/" + FolderName + "/Scripts"+ "/Controller", script);
            string newFolderPath = AssetDatabase.GUIDToAssetPath(guid);

        }
        AssetDatabase.Refresh();

        foreach (string resource in resourcesFolders)
        {
            //AssetDatabase.Contain
            string guid = AssetDatabase.CreateFolder("Assets/" + FolderName + "/Resources", resource);
            string newFolderPath = AssetDatabase.GUIDToAssetPath(guid);

        }

    }
}
#endif
