using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.Build;
using UnityEngine;

namespace BindingUI.Boost.Editor
{
    public sealed class BoostSettingsWindow : EditorWindow
    {
        static readonly BoostIntegrationDefinition[] Integrations =
        {
            new(
                displayName: "R3",
                defineSymbol: "BINDINGUI_BOOST_R3",
                officialUrl: "https://github.com/Cysharp/R3"),

            new(
                displayName: "DOTween",
                defineSymbol: "BINDINGUI_BOOST_DOTWEEN",
                officialUrl: "https://dotween.demigiant.com/")
        };

        readonly Dictionary<string, bool> enabledStates =
            new(StringComparer.Ordinal);

        NamedBuildTarget currentBuildTarget;
        Vector2 scrollPosition;
        bool hasPendingChanges;

        [MenuItem("Window/BindingUI/Boost Settings")]
        static void Open()
        {
            var window = GetWindow<BoostSettingsWindow>();

            window.titleContent =
                new GUIContent("BindingUI.Boost");

            window.minSize = new Vector2(380f, 230f);
            window.Show();
        }

        void OnEnable()
        {
            Reload();
        }

        void OnFocus()
        {
            var selectedTarget =
                BoostDefineSymbols.CurrentBuildTarget;

            if (!selectedTarget.Equals(currentBuildTarget))
            {
                Reload();
            }
        }

        void OnGUI()
        {
            DrawHeader();
            DrawBuildTarget();
            DrawInformation();

            EditorGUILayout.Space(6f);

            DrawIntegrations();

            EditorGUILayout.Space(8f);

            DrawFooter();
        }

        void DrawHeader()
        {
            EditorGUILayout.LabelField(
                "BindingUI.Boost Settings",
                EditorStyles.boldLabel);

            EditorGUILayout.LabelField(
                "Enable optional integrations for the current build target.",
                EditorStyles.wordWrappedMiniLabel);
        }

        void DrawBuildTarget()
        {
            EditorGUILayout.Space(6f);

            using (new EditorGUI.DisabledScope(true))
            {
                EditorGUILayout.TextField(
                    "Build Target",
                    currentBuildTarget.TargetName);
            }
        }

        void DrawInformation()
        {
            EditorGUILayout.HelpBox(
                "Install the required external library before enabling " +
                "its integration. BindingUI.Boost does not detect whether " +
                "the library is installed.",
                MessageType.Info);
        }

        void DrawIntegrations()
        {
            scrollPosition =
                EditorGUILayout.BeginScrollView(scrollPosition);

            foreach (var integration in Integrations)
            {
                DrawIntegration(integration);
            }

            EditorGUILayout.EndScrollView();
        }

        void DrawIntegration(
            BoostIntegrationDefinition integration)
        {
            using (new EditorGUILayout.VerticalScope(
                       EditorStyles.helpBox))
            {
                using (new EditorGUILayout.HorizontalScope())
                {
                    var currentValue =
                        enabledStates.TryGetValue(
                            integration.DefineSymbol,
                            out var enabled) &&
                        enabled;

                    EditorGUI.BeginChangeCheck();

                    var newValue =
                        EditorGUILayout.ToggleLeft(
                            integration.DisplayName,
                            currentValue,
                            EditorStyles.boldLabel);

                    if (EditorGUI.EndChangeCheck())
                    {
                        enabledStates[integration.DefineSymbol] =
                            newValue;

                        hasPendingChanges = true;
                    }

                    GUILayout.FlexibleSpace();

                    if (GUILayout.Button(
                            "Official Page",
                            GUILayout.Width(100f)))
                    {
                        Application.OpenURL(
                            integration.OfficialUrl);
                    }
                }

                EditorGUILayout.LabelField(
                    integration.DefineSymbol,
                    EditorStyles.miniLabel);
            }
        }

        void DrawFooter()
        {
            using (new EditorGUILayout.HorizontalScope())
            {
                using (new EditorGUI.DisabledScope(
                           !hasPendingChanges))
                {
                    if (GUILayout.Button(
                            "Revert",
                            GUILayout.Width(80f)))
                    {
                        Reload();
                    }
                }

                GUILayout.FlexibleSpace();

                using (new EditorGUI.DisabledScope(
                           !hasPendingChanges))
                {
                    if (GUILayout.Button(
                            "Apply",
                            GUILayout.Width(100f),
                            GUILayout.Height(26f)))
                    {
                        Apply();
                    }
                }
            }
        }

        void Reload()
        {
            currentBuildTarget =
                BoostDefineSymbols.CurrentBuildTarget;

            var currentSymbols =
                BoostDefineSymbols.GetSymbols(
                    currentBuildTarget);

            enabledStates.Clear();

            foreach (var integration in Integrations)
            {
                enabledStates[integration.DefineSymbol] =
                    currentSymbols.Contains(
                        integration.DefineSymbol);
            }

            hasPendingChanges = false;
            Repaint();
        }

        void Apply()
        {
            var enabledSymbols = Integrations
                .Where(integration =>
                    enabledStates.TryGetValue(
                        integration.DefineSymbol,
                        out var enabled) &&
                    enabled)
                .Select(integration =>
                    integration.DefineSymbol)
                .ToArray();

            var managedSymbols = Integrations
                .Select(integration =>
                    integration.DefineSymbol)
                .ToArray();

            var changed = BoostDefineSymbols.Apply(
                currentBuildTarget,
                managedSymbols,
                enabledSymbols);

            hasPendingChanges = false;

            if (changed)
            {
                ShowNotification(
                    new GUIContent("Boost settings applied"));

                Debug.Log(
                    $"BindingUI.Boost defines updated for " +
                    $"{currentBuildTarget.TargetName}: " +
                    $"{string.Join(", ", enabledSymbols)}");
            }
            else
            {
                ShowNotification(
                    new GUIContent("No changes"));
            }
        }
    }
}