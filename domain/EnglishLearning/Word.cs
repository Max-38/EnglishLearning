using EnglishLearning.Data;

namespace EnglishLearning;
public class Word
{
    private readonly WordDto dto;

    public int Id => dto.Id;
    public string Name => dto.Name;
    public string Translation => dto.Translation;
    public bool Passed
    {
        get => dto.Passed;
        set => dto.Passed = value;
    }
    public bool ExerciseWordTranslation
    {
        get => dto.ExerciseWordTranslation;
        set => dto.ExerciseWordTranslation = value;
    }
    public bool ExerciseListening
    {
        get => dto.ExerciseListening;
        set => dto.ExerciseListening = value;
    }
    public string NameAudio => dto.NameAudio;

    internal Word (WordDto dto)
    {
        this.dto = dto;
    }

    public static class Mapper
    {
        public static Word Map(WordDto dto) => new Word(dto);
        public static WordDto Map(Word domain) => domain.dto;
    }
}
