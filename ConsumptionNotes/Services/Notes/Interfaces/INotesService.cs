namespace ConsumptionNotes.Services.Notes.Interfaces;

public interface INotesService<TConsumption>
{
    void AddNote(TConsumption consumption);
    void RemoveNote(TConsumption consumption);
}