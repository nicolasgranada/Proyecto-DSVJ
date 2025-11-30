using UnityEngine;
using UnityEditor;

public class MissingScriptCleaner : EditorWindow
{
    [MenuItem("Tools/Clean Missing Scripts")]
    public static void Clean()
    {
        int count = 0;

        foreach (GameObject go in Resources.FindObjectsOfTypeAll<GameObject>())
        {
            var components = go.GetComponents<Component>();
            var serializedObj = new SerializedObject(go);
            var prop = serializedObj.FindProperty("m_Component");

            int r = 0;

            for (int i = 0; i < components.Length; i++)
            {
                if (components[i] == null)
                {
                    prop.DeleteArrayElementAtIndex(i - r);
                    r++;
                    count++;
                }
            }

            serializedObj.ApplyModifiedProperties();
        }

        Debug.Log($"✔ Missing scripts removidos: {count}");
    }
}
