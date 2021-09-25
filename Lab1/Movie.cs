namespace Lab1
{
    public struct Movie
    {
        public string Name;
        public string Genre;
        public string Director;
        public int Year;

        public Movie(string name, string genre, string director, int year)
        {
            Name = name;
            Genre = genre;
            Director = director;
            Year = year;
        }
    }
}
