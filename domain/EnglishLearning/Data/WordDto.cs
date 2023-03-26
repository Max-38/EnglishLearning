namespace EnglishLearning.Data
{
    public class WordDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Translation { get; set; }
        public bool Passed { get; set; }
        public bool ExerciseWordTranslation { get; set; }
        public bool ExerciseListening { get; set; }
        public string NameAudio { get; set; }
    }
}
