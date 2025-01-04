namespace ConsumptionNotes.Application.Localization;
// Temporary solution
public static class ExceptionMessages
{
    public const string JsonFileNotSelectedMessage = "Не обрали потрібний файл з даними";

    public const string FileNotSelectedExceptionMessage = "Не було обрано файл";
    public const string FolderNotSelectedExceptionMessage = "Папка не була вибрана";

    public const string DuplicateNoteErrorMessage = "Запис про цей місяць вже є";
    public const string InvalidDateErrorMessage = "Не можна додавати запис \r\nпро поточний чи майбутній місяць";
}
