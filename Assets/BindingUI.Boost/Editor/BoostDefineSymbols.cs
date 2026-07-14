using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.Build;

namespace BindingUI.Boost.Editor
{
    internal static class BoostDefineSymbols
    {
        public static NamedBuildTarget CurrentBuildTarget
        {
            get
            {
                var group =
                    EditorUserBuildSettings.selectedBuildTargetGroup;

                return NamedBuildTarget.FromBuildTargetGroup(group);
            }
        }

        public static HashSet<string> GetSymbols(
            NamedBuildTarget buildTarget)
        {
            PlayerSettings.GetScriptingDefineSymbols(
                buildTarget,
                out var symbols);

            return symbols
                .Where(symbol =>
                    !string.IsNullOrWhiteSpace(symbol))
                .ToHashSet(StringComparer.Ordinal);
        }

        public static bool Contains(
            NamedBuildTarget buildTarget,
            string symbol)
        {
            return GetSymbols(buildTarget).Contains(symbol);
        }

        /// <summary>
        /// 指定されたBoost用defineだけを更新します。
        /// Boost以外の既存defineは維持されます。
        /// </summary>
        public static bool Apply(
            NamedBuildTarget buildTarget,
            IReadOnlyCollection<string> managedSymbols,
            IReadOnlyCollection<string> enabledSymbols)
        {
            var currentSymbols = GetSymbols(buildTarget);
            var updatedSymbols =
                new HashSet<string>(
                    currentSymbols,
                    StringComparer.Ordinal);

            foreach (var symbol in managedSymbols)
            {
                updatedSymbols.Remove(symbol);
            }

            foreach (var symbol in enabledSymbols)
            {
                updatedSymbols.Add(symbol);
            }

            if (currentSymbols.SetEquals(updatedSymbols))
            {
                return false;
            }

            var sortedSymbols = updatedSymbols
                .OrderBy(symbol => symbol, StringComparer.Ordinal)
                .ToArray();

            PlayerSettings.SetScriptingDefineSymbols(
                buildTarget,
                sortedSymbols);

            return true;
        }
    }
}