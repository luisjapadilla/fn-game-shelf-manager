﻿namespace GameShelfManager.Domain.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }
        public string ReviewerName { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; } 
        public DateTime ReviewDate { get; set; }
    }
}
