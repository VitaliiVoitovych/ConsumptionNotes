using System.Windows.Input;
using FluentAvalonia.UI.Controls;

namespace ConsumptionNotes.Utils.Dialogs;

public class DialogBuilder
{
    private const string DefaultCloseButtonText = "OK";
    
    private string? _title;
    private object? _content;

    private string? _primaryButtonText;
    private string _closeButtonText = DefaultCloseButtonText;

    private ICommand? _primaryButtonCommand;
    private ContentDialogButton _defaultButton = ContentDialogButton.None;

    public void Reset()
    {
        _title = default;
        _content = default;
        _primaryButtonText = default;
        _closeButtonText = DefaultCloseButtonText;
        _primaryButtonCommand = default;
        _defaultButton = ContentDialogButton.None;
    }
    
    public DialogBuilder SetTitle(string title)
    {
        _title = title;
        return this;
    }

    public DialogBuilder SetContent(object content)
    {
        _content = content;
        return this;
    }

    public DialogBuilder SetPrimaryButtonText(string text)
    {
        _primaryButtonText = text;
        return this;
    }

    public DialogBuilder SetCloseButtonText(string text)
    {
        _closeButtonText = text;
        return this;
    }

    public DialogBuilder SetPrimaryButtonCommand(ICommand command)
    {
        _primaryButtonCommand = command;
        return this;
    }

    public DialogBuilder SetDefaultButton(ContentDialogButton defaultButton)
    {
        _defaultButton = defaultButton;
        return this;
    }
    
    public ContentDialog Build()
    {
        return new ContentDialog
        {
            Title = _title,
            Content = _content,
            PrimaryButtonText = _primaryButtonText,
            CloseButtonText = _closeButtonText,
            PrimaryButtonCommand = _primaryButtonCommand,
            DefaultButton = _defaultButton
        };
    }
}