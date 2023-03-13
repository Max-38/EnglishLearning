namespace EnglishLearning;
public class Word
{
    public int Id { get; }
    public string? Name { get; }
    public string? Translation { get; }
    public bool Passed { get; set; }
    public bool ExerciseWordTranslation { get; set; }
    public bool ExerciseListening { get; set; }
    public string? PathToAudio { get;  }

    public Word (int id,
                 string? name,
                 string? translation,
                 bool passed,
                 bool exerciseWordTranslation,
                 bool exerciseListening,
                 string pathToAudio)
    {
        Id = id;
        Name = name;
        Translation = translation;
        Passed = passed;
        ExerciseWordTranslation = exerciseWordTranslation;
        ExerciseListening = exerciseListening;
        PathToAudio = pathToAudio;
    }
}
