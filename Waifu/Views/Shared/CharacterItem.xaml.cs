﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Waifu.Models;

namespace Waifu.Views.Shared;

public partial class CharacterItem : UserControl
{
    private readonly RoleplayCharacter? _roleplayCharacter;

    public CharacterItem(RoleplayCharacter? roleplayCharacter = null)
    {
        _roleplayCharacter = roleplayCharacter;

        InitializeComponent();
    }

    // for wpf previews to work
    public CharacterItem() : this(null)
    {
    }

    public event EventHandler<RoleplayCharacter?> OnActiveRequest;

    #region Character Name Property

    public String CharacterName
    {
        get { return (String)GetValue(CharacterNameProperty); }
        set { SetValue(CharacterNameProperty, value); }
    }

    public static readonly DependencyProperty CharacterNameProperty =
        DependencyProperty.Register(nameof(CharacterName), typeof(String), typeof(CharacterItem),
            new FrameworkPropertyMetadata(null)
            {
                //  It's read-write, so make it bind both ways by default
                BindsTwoWayByDefault = true
            });

    #endregion

    #region Character Image Property

    public ImageSource Image
    {
        get { return (ImageSource)GetValue(ImageProperty); }
        set { SetValue(ImageProperty, value); }
    }

    public static readonly DependencyProperty ImageProperty =
        DependencyProperty.Register(nameof(Image), typeof(ImageSource), typeof(CharacterItem),
            new FrameworkPropertyMetadata(null));

    #endregion

    private void ItemClicked(object sender, MouseButtonEventArgs e)
    {
        OnActiveRequest?.Invoke(this, _roleplayCharacter);
    }

    private void CharacterItemLoaded(object sender, RoutedEventArgs e)
    {
        ToolTipService.SetToolTip(MainGrid, CharacterName);
    }
}