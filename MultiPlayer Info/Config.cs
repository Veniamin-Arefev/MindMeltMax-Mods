﻿using StardewModdingAPI;
using System;

namespace MPInfo 
{
    public class Config 
    {
        public bool EnabledByDefault { get; set; } = true;

        public SButton ToggleButton { get; set; } = SButton.F6s;
        public bool ShowSelf { get; set; } = false;
        public bool ShowHostCrown { get; set; } = true;
        public bool HideHealthBars { get; set; } = false;
        public Position Position { get; set; } = Position.BottomLeft;
        public int XOffset { get; set; } = 0;
        public int YOffset { get; set; } = 0;
        public int SpaceBetween { get; set; } = 112;
    }

    public interface IGenericModConfigMenuApi 
    {
        void Register(IManifest mod, Action reset, Action save, bool titleScreenOnly = false);

        void AddBoolOption(IManifest mod, Func<bool> getValue, Action<bool> setValue, Func<string> name, Func<string>? tooltip = null, string? fieldId = null);

        void AddTextOption(IManifest mod, Func<string> getValue, Action<string> setValue, Func<string> name, Func<string> tooltip = null, string[] allowedValues = null, Func<string, string> formatAllowedValue = null, string fieldId = null);

        void AddNumberOption(IManifest mod, Func<int> getValue, Action<int> setValue, Func<string> name, Func<string> tooltip = null, int? min = null, int? max = null, int? interval = null, Func<int, string> formatValue = null, string fieldId = null);

        void AddKeybind(IManifest mod, Func<SButton> getValue, Action<SButton> setValue, Func<string> name, Func<string> tooltip = null, string fieldId = null);
    }
}
