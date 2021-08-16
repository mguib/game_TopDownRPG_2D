using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CreateAssetMenu(fileName ="New Dialogue", menuName ="New Dialogue/Dialogue")]
public class DialogSetings : ScriptableObject
{
    [Header("Settings")]
    public GameObject actor;

    [Header("Dialogue")]
    public Sprite speakerSprite;
    public string sentence;

    public List<Sentences> dialogues = new List<Sentences>();

}

[System.Serializable]
public class Sentences
{
    public string actorName;
    public Sprite profile;
    public Languages sentence;
}

[System.Serializable]
public class Languages
{
    public string portuguese;
    public string english;
    public string spanish;
}


//Lido quando a unity esta executando
#if UNITY_EDITOR
[CustomEditor(typeof(DialogSetings))]
public class BuilderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        DialogSetings ds = (DialogSetings)target;

        Languages l = new Languages();
        l.portuguese = ds.sentence;

        Sentences s = new Sentences();
        s.profile = ds.speakerSprite;
        s.sentence = l;

        if(GUILayout.Button("Creat Dealogue"))
        {
            if(ds.sentence != "")
            {
                ds.dialogues.Add(s);
                ds.speakerSprite = null;
                ds.sentence = "";

            }
        }

    }
}
#endif
