namespace MovieMania.Helpers
{
   
        public class QueryObject
        {
            public int Rating { get; set; }
            public string? MovieName { get; set; } = null;

            public string? SortBy { get; set; } = null;

            public bool? IsDescending { get; set; } = false;
            

        }
    

}
