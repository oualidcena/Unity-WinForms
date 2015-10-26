﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace System.Drawing
{
#if UNITY_EDITOR
    public class Editor
    {
        private static float _width { get; set; }
        private static float _nameWidth { get; set; }
        private static float _contentWidth { get; set; }

        public static void BeginGroup(float width)
        {
            _width = width;
            _nameWidth = 160;
            _contentWidth = width - _nameWidth + 8;

            UnityEngine.GUILayout.BeginVertical();
        }
        public static void BeginHorizontal()
        {
            if (_width > 0)
                UnityEngine.GUILayout.BeginHorizontal(UnityEngine.GUILayout.Width(_width));
            else
                UnityEngine.GUILayout.BeginHorizontal();
        }
        public static void BeginVertical()
        {
            UnityEngine.GUILayout.BeginVertical();
        }
        public static void EndGroup()
        {
            UnityEngine.GUILayout.EndVertical();
        }
        public static void EndHorizontal()
        {
            UnityEngine.GUILayout.EndHorizontal();
        }
        public static void EndVertical()
        {
            UnityEngine.GUILayout.EndVertical();
        }

        public static EditorValue<bool> BooleanField(string name, bool value)
        {
            UnityEngine.GUILayout.BeginHorizontal();
            UnityEngine.GUILayout.Label(name + ":", UnityEngine.GUILayout.Width(_nameWidth));
            var boolBuffer = UnityEngine.GUILayout.Toolbar(value ? 0 : 1, new string[] { "On", "Off" }, UnityEngine.GUILayout.Width(_contentWidth)) == 0 ? true : false;
            UnityEngine.GUILayout.EndHorizontal();

            return new EditorValue<bool>(boolBuffer, boolBuffer != value);
        }
        public static bool Button(string name, string text)
        {
            UnityEngine.GUILayout.BeginHorizontal();
            UnityEngine.GUILayout.Label(name + ":", UnityEngine.GUILayout.Width(_nameWidth));
            var boolResult = UnityEngine.GUILayout.Button(text, UnityEngine.GUILayout.Width(_contentWidth));
            UnityEngine.GUILayout.EndHorizontal();

            return boolResult;
        }
        public static bool Button(string text)
        {
            return UnityEngine.GUILayout.Button(text);
        }
        public static bool Button(string text, int width)
        {
            return UnityEngine.GUILayout.Button(text, UnityEngine.GUILayout.Width(width));
        }
        public static EditorValue<Color> ColorField(string name, Color value)
        {
            UnityEngine.GUILayout.BeginHorizontal();
            UnityEngine.GUILayout.Label(name + ":", UnityEngine.GUILayout.Width(_nameWidth));
            var colorBuffer = System.Drawing.Color.FromUColor(UnityEditor.EditorGUILayout.ColorField(value.ToUColor(), UnityEngine.GUILayout.Width(_contentWidth)));
            UnityEngine.GUILayout.EndHorizontal();

            return new EditorValue<Color>(colorBuffer, colorBuffer != value);
        }
        public static EditorValue<Enum> EnumField(string name, Enum value)
        {
            UnityEngine.GUILayout.BeginHorizontal();
            UnityEngine.GUILayout.Label(name + ":", UnityEngine.GUILayout.Width(_nameWidth));
            var enumBuffer = UnityEditor.EditorGUILayout.EnumPopup(value, UnityEngine.GUILayout.Width(_contentWidth));
            UnityEngine.GUILayout.EndHorizontal();

            return new EditorValue<Enum>(enumBuffer, enumBuffer != value);
        }
        public static bool Foldout(string name, bool value)
        {
            return UnityEditor.EditorGUILayout.Foldout(value, name);
        }
        public static void Header(string text)
        {
            UnityEngine.GUI.skin.label.fontStyle = UnityEngine.FontStyle.Bold;
            UnityEngine.GUI.skin.label.alignment = UnityEngine.TextAnchor.MiddleCenter;
            UnityEngine.GUI.Label(new UnityEngine.Rect(0, 0, _width, 36), text);

            UnityEngine.GUI.skin.label.fontStyle = UnityEngine.FontStyle.Normal;
            UnityEngine.GUI.skin.label.alignment = UnityEngine.TextAnchor.UpperLeft;
        }
        public static void Label(object value)
        {
            UnityEngine.GUILayout.Label(value.ToString());
        }
        public static void Label(string name, object value)
        {
            UnityEngine.GUILayout.BeginHorizontal();
            UnityEngine.GUILayout.Label(name + ":", UnityEngine.GUILayout.Width(_nameWidth));
            UnityEngine.GUILayout.Label(value.ToString(), UnityEngine.GUILayout.Width(_contentWidth));
            UnityEngine.GUILayout.EndHorizontal();
        }
        public static EditorValue<int[]> IntField(string name, params int[] value)
        {
            UnityEngine.GUILayout.BeginHorizontal();
            UnityEngine.GUILayout.Label(name + ":", UnityEngine.GUILayout.Width(_nameWidth));

            bool changed = false;
            int[] intBuffer = new int[value.Length];
            for (int i = 0; i < value.Length; i++)
            {
                intBuffer[i] = UnityEditor.EditorGUILayout.IntField(value[i], UnityEngine.GUILayout.Width(_contentWidth / value.Length));
                if (intBuffer[i] != value[i])
                    changed = true;
            }
            UnityEngine.GUILayout.EndHorizontal();

            return new EditorValue<int[]>(intBuffer, changed);
        }
        public static void NewLine(int cnt)
        {
            for (int i = 0; i < cnt; i++)
                UnityEngine.GUILayout.Label("");
        }
        public static EditorValue<UnityEngine.Object> ObjectField(string name, UnityEngine.Object value, Type type)
        {
            UnityEngine.GUILayout.BeginHorizontal();
            UnityEngine.GUILayout.Label(name + ":", UnityEngine.GUILayout.Width(_nameWidth));
            var objectBuffer = UnityEditor.EditorGUILayout.ObjectField(value, type, UnityEngine.GUILayout.Width(_contentWidth));
            UnityEngine.GUILayout.EndHorizontal();

            return new EditorValue<UnityEngine.Object>(objectBuffer, objectBuffer != value);
        }
        public static EditorValue<int> Popup(string name, int index, string[] values)
        {
            UnityEngine.GUILayout.BeginHorizontal();
            UnityEngine.GUILayout.Label(name + ":", UnityEngine.GUILayout.Width(_nameWidth));
            var intBuffer = UnityEditor.EditorGUILayout.Popup(index, values, UnityEngine.GUILayout.Width(_contentWidth - 8));
            UnityEngine.GUILayout.EndHorizontal();

            return new EditorValue<int>(intBuffer, intBuffer != index);
        }
        public static EditorValue<float> Slider(string name, float value, float min, float max)
        {
            UnityEngine.GUILayout.BeginHorizontal();
            UnityEngine.GUILayout.Label(name + ":", UnityEngine.GUILayout.Width(_nameWidth));
            var floatBuffer = UnityEditor.EditorGUILayout.Slider(value, min, max, UnityEngine.GUILayout.Width(_contentWidth - 8));
            UnityEngine.GUILayout.EndHorizontal();

            return new EditorValue<float>(floatBuffer, floatBuffer != value);
        }
        public static EditorValue<string> TextField(string name, string value)
        {
            UnityEngine.GUILayout.BeginHorizontal();
            UnityEngine.GUILayout.Label(name + ":", UnityEngine.GUILayout.Width(_nameWidth));
            var textBuffer = UnityEngine.GUILayout.TextField(value, UnityEngine.GUILayout.Width(_contentWidth));
            UnityEngine.GUILayout.EndHorizontal();

            return new EditorValue<string>(textBuffer, textBuffer != value);
        }
        public static bool Toggle(string name, bool value)
        {
            return UnityEngine.GUILayout.Toggle(value, name, UnityEngine.GUILayout.Width(_width));
        }
    }
#endif

    public struct EditorValue<T>
    {
        private bool _changed;
        private T _value;

        public bool Changed { get { return _changed; } }
        public T Value { get { return _value; } }

        public EditorValue(T value, bool changed)
        {
            _value = value;
            _changed = changed;
        }

        public static bool operator ==(EditorValue<T> left, EditorValue<T> right)
        {
            return left.Value.Equals(right.Value);
        }
        public static bool operator ==(EditorValue<T> left, T right)
        {
            return left.Value.Equals(right);
        }
        public static bool operator !=(EditorValue<T> left, T right)
        {
            return !left.Value.Equals(right);
        }
        public static bool operator !=(EditorValue<T> left, EditorValue<T> right)
        {
            return !left.Value.Equals(right.Value);
        }
        public static implicit operator T(EditorValue<T> value)
        {
            return value.Value;
        }
        public static implicit operator EditorValue<T>(T value)
        {
            return new EditorValue<T>(value, true);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
