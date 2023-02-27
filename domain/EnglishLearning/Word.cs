namespace EnglishLearning;
public class Word
{
    public int Id { get; }
    public string? Name { get; }
    public string? Translation { get; }
    public bool Passed { get; set; }
    public bool Learned { get; set; }
    public string? PathToAudio { get;  }

    public Word (int id, string? name, string? translation, bool passed, bool learned, string pathToAudio)
    {
        Id = id;
        Name = name;
        Translation = translation;
        Passed = passed;
        Learned = learned;
        PathToAudio = pathToAudio;
    }
}
