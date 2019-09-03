using System;

namespace TechnicalRadiation.Models.InputModels
{
    public class NewsItemInputModel
    {
        public string Title { get; set; }
        public string ImgSource { get; set; }
        public string ShortDescription { get; set; }
        #nullable enable
        public string? LongDescription { get; set; }
        public DateTime PublishDate { get; set; }
    }
}