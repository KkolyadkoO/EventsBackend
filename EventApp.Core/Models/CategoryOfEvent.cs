﻿namespace EventApp.Core.Models
{
    public class CategoryOfEvent
    {
       
        public CategoryOfEvent(Guid id, string title)
        {
            Id = id;
            Title = title;
        }

        public Guid Id { get; }
        public string Title { get; }
    }
}