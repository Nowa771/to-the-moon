



#if UNITY_EDITOR
using PolygonPlanet.Editor;
using System.Linq;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(StockManager))]
public class StockManagerEditor : Editor
{
    //Variables
    private StockManager myScript;
    private ReorderableList defaultStocks;

    private void OnEnable()
    {
        myScript = (StockManager)target;
        defaultStocks = new ReorderableList(serializedObject.FindProperty("defaultStocks"));
    }

    public override void OnInspectorGUI()
    {
        EditorGUI.BeginChangeCheck();

        defaultStocks.DoLayoutList();

        serializedObject.ApplyModifiedProperties();
        if (EditorGUI.EndChangeCheck())
            EditorUtility.SetDirty(myScript);
    }
}
#endif