namespace Movies.Dtos
{
    internal class MovieDTO
    {
        public Guid Id { get; set; }
        public string Color { get; set; }
        public string Title { get; set; }
        public int Rating { get; set; }
        public string Image { get; set; }

        public Models.Movie ToModel()
        {
            return new Models.Movie()
            {
                Id = Id,
                Color = Android.Graphics.Color.ParseColor(this.Color),
                Title = this.Title,
                Rating = this.Rating,
                Image = ImageSource.FromUri(new Uri(this.Image))
            };
        }
    }
}
