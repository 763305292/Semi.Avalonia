﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Semi.Avalonia.Demo.ViewModels;

public partial class IconDemoViewModel : ObservableObject
{
    private readonly IResourceDictionary? _resources = new Icons();

    private readonly Dictionary<string, IconItem> _filledIcons = new();
    private readonly Dictionary<string, IconItem> _strokedIcons = new();

    [ObservableProperty] private string? _searchText;

    public ObservableCollection<IconItem> FilteredFilledIcons { get; set; } = [];
    public ObservableCollection<IconItem> FilteredStrokedIcons { get; set; } = [];

    public void InitializeResources()
    {
        if (_resources is null) return;

        foreach (var provider in _resources.MergedDictionaries)
        {
            var dic = provider as ResourceDictionary;
            if (dic?.Keys is null) continue;
            foreach (var key in dic.Keys)
            {
                if (dic[key] is not Geometry geometry) continue;
                var icon = new IconItem { ResourceKey = key.ToString(), Geometry = geometry };

                if (key.ToString().EndsWith("Stroked"))
                {
                    _strokedIcons[key.ToString()] = icon;
                }
                else
                {
                    _filledIcons[key.ToString()] = icon;
                }
            }
        }

        OnSearchTextChanged(string.Empty);
    }

    partial void OnSearchTextChanged(string? value)
    {
        var search = value?.ToLowerInvariant() ?? string.Empty;

        FilteredFilledIcons.Clear();
        foreach (var icon in _filledIcons.Values.Where(i => i.ResourceKey?.ToLowerInvariant().Contains(search) == true))
        {
            FilteredFilledIcons.Add(icon);
        }

        FilteredStrokedIcons.Clear();
        foreach (var icon in
                 _strokedIcons.Values.Where(i => i.ResourceKey?.ToLowerInvariant().Contains(search) == true))
        {
            FilteredStrokedIcons.Add(icon);
        }
    }
}

public class IconItem
{
    public string? ResourceKey { get; set; }
    public Geometry? Geometry { get; set; }
}