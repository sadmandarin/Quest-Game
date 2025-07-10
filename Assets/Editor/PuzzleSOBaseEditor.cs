using UnityEditor;
using UnityEngine;
using System;
using System.Linq;

[CustomEditor(typeof(PuzzleSOBase), true)]
public class PuzzleSOBaseEditor : Editor
{
    private SerializedProperty conditionProperty;
    private string[] conditionTypeNames;
    private Type[] conditionTypes;
    private int selectedConditionIndex = 0;

    private void OnEnable()
    {
        conditionProperty = serializedObject.FindProperty("Condition");

        // Найдём все наследники PuzzleConditionBase
        conditionTypes = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(asm => asm.GetTypes())
            .Where(t => !t.IsAbstract && typeof(PuzzleConditionBase).IsAssignableFrom(t))
            .ToArray();

        conditionTypeNames = conditionTypes.Select(t => t.Name).ToArray();
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        DrawDefaultInspector();

        GUILayout.Space(10);
        EditorGUILayout.LabelField("Puzzle Condition", EditorStyles.boldLabel);

        if (conditionProperty.managedReferenceValue != null)
        {
            EditorGUILayout.PropertyField(conditionProperty, new GUIContent("Condition"), true);

            if (GUILayout.Button("Remove Condition"))
            {
                conditionProperty.managedReferenceValue = null;
            }
        }
        else
        {
            EditorGUILayout.LabelField("No Condition Assigned");
        }

        GUILayout.Space(10);
        EditorGUILayout.LabelField("Add New Condition", EditorStyles.boldLabel);

        selectedConditionIndex = EditorGUILayout.Popup("Select Condition", selectedConditionIndex, conditionTypeNames);

        if (GUILayout.Button("Add Condition"))
        {
            var conditionInstance = Activator.CreateInstance(conditionTypes[selectedConditionIndex]);
            conditionProperty.managedReferenceValue = conditionInstance;
        }

        serializedObject.ApplyModifiedProperties();
    }
}