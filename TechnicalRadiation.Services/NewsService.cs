using System;
using System.Collections.Generic;
using TechnicalRadiation.Models.Entities;

namespace TechnicalRadiation.Services
{
    public static class NewsService
    {
        public static List<NewsItem> NewsItems = new List<NewsItem>()
        {
            new NewsItem { Id = 1, Title = "Bla", ImgSource = "", ShortDescription = "Once upon a time...", LongDescription = "Once upon a time there lived a wizard", PublishDate = new DateTime(), ModifiedBy = "TechnicalRadiationAdmin", CreatedDate = new DateTime(), ModifiedDate = new DateTime() },
            new NewsItem { Id = 2, Title = "Bla", ImgSource = "", ShortDescription = "Once upon a time...", LongDescription = "Once upon a time there lived a wizard", PublishDate = new DateTime(), ModifiedBy = "TechnicalRadiationAdmin", CreatedDate = new DateTime(), ModifiedDate = new DateTime() },
            new NewsItem { Id = 3, Title = "Bla", ImgSource = "", ShortDescription = "Once upon a time...", LongDescription = "Once upon a time there lived a wizard", PublishDate = new DateTime(), ModifiedBy = "TechnicalRadiationAdmin", CreatedDate = new DateTime(), ModifiedDate = new DateTime() },
            new NewsItem { Id = 4, Title = "Bla", ImgSource = "", ShortDescription = "Once upon a time...", LongDescription = "Once upon a time there lived a wizard", PublishDate = new DateTime(), ModifiedBy = "TechnicalRadiationAdmin", CreatedDate = new DateTime(), ModifiedDate = new DateTime() },
            new NewsItem { Id = 5, Title = "Bla", ImgSource = "", ShortDescription = "Once upon a time...", LongDescription = "Once upon a time there lived a wizard", PublishDate = new DateTime(), ModifiedBy = "TechnicalRadiationAdmin", CreatedDate = new DateTime(), ModifiedDate = new DateTime() },
            new NewsItem { Id = 6, Title = "Bla", ImgSource = "", ShortDescription = "Once upon a time...", LongDescription = "Once upon a time there lived a wizard", PublishDate = new DateTime(), ModifiedBy = "TechnicalRadiationAdmin", CreatedDate = new DateTime(), ModifiedDate = new DateTime() },
            new NewsItem { Id = 7, Title = "Bla", ImgSource = "", ShortDescription = "Once upon a time...", LongDescription = "Once upon a time there lived a wizard", PublishDate = new DateTime(), ModifiedBy = "TechnicalRadiationAdmin", CreatedDate = new DateTime(), ModifiedDate = new DateTime() },
            new NewsItem { Id = 8, Title = "Bla", ImgSource = "", ShortDescription = "Once upon a time...", LongDescription = "Once upon a time there lived a wizard", PublishDate = new DateTime(), ModifiedBy = "TechnicalRadiationAdmin", CreatedDate = new DateTime(), ModifiedDate = new DateTime() },
            new NewsItem { Id = 9, Title = "Bla", ImgSource = "", ShortDescription = "Once upon a time...", LongDescription = "Once upon a time there lived a wizard", PublishDate = new DateTime(), ModifiedBy = "TechnicalRadiationAdmin", CreatedDate = new DateTime(), ModifiedDate = new DateTime() },
            new NewsItem { Id = 10, Title = "Bla", ImgSource = "", ShortDescription = "Once upon a time...", LongDescription = "Once upon a time there lived a wizard", PublishDate = new DateTime(), ModifiedBy = "TechnicalRadiationAdmin", CreatedDate = new DateTime(), ModifiedDate = new DateTime() },
            new NewsItem { Id = 11, Title = "Bla", ImgSource = "", ShortDescription = "Once upon a time...", LongDescription = "Once upon a time there lived a wizard", PublishDate = new DateTime(), ModifiedBy = "TechnicalRadiationAdmin", CreatedDate = new DateTime(), ModifiedDate = new DateTime() },
            new NewsItem { Id = 12, Title = "Bla", ImgSource = "", ShortDescription = "Once upon a time...", LongDescription = "Once upon a time there lived a wizard", PublishDate = new DateTime(), ModifiedBy = "TechnicalRadiationAdmin", CreatedDate = new DateTime(), ModifiedDate = new DateTime() },
            new NewsItem { Id = 13, Title = "Bla", ImgSource = "", ShortDescription = "Once upon a time...", LongDescription = "Once upon a time there lived a wizard", PublishDate = new DateTime(), ModifiedBy = "TechnicalRadiationAdmin", CreatedDate = new DateTime(), ModifiedDate = new DateTime() },
            new NewsItem { Id = 14, Title = "Bla", ImgSource = "", ShortDescription = "Once upon a time...", LongDescription = "Once upon a time there lived a wizard", PublishDate = new DateTime(), ModifiedBy = "TechnicalRadiationAdmin", CreatedDate = new DateTime(), ModifiedDate = new DateTime() },
            new NewsItem { Id = 15, Title = "Bla", ImgSource = "", ShortDescription = "Once upon a time...", LongDescription = "Once upon a time there lived a wizard", PublishDate = new DateTime(), ModifiedBy = "TechnicalRadiationAdmin", CreatedDate = new DateTime(), ModifiedDate = new DateTime() },
            new NewsItem { Id = 16, Title = "Bla", ImgSource = "", ShortDescription = "Once upon a time...", LongDescription = "Once upon a time there lived a wizard", PublishDate = new DateTime(), ModifiedBy = "TechnicalRadiationAdmin", CreatedDate = new DateTime(), ModifiedDate = new DateTime() },
            new NewsItem { Id = 17, Title = "Bla", ImgSource = "", ShortDescription = "Once upon a time...", LongDescription = "Once upon a time there lived a wizard", PublishDate = new DateTime(), ModifiedBy = "TechnicalRadiationAdmin", CreatedDate = new DateTime(), ModifiedDate = new DateTime() },
            new NewsItem { Id = 18, Title = "Bla", ImgSource = "", ShortDescription = "Once upon a time...", LongDescription = "Once upon a time there lived a wizard", PublishDate = new DateTime(), ModifiedBy = "TechnicalRadiationAdmin", CreatedDate = new DateTime(), ModifiedDate = new DateTime() },
            new NewsItem { Id = 19, Title = "Bla", ImgSource = "", ShortDescription = "Once upon a time...", LongDescription = "Once upon a time there lived a wizard", PublishDate = new DateTime(), ModifiedBy = "TechnicalRadiationAdmin", CreatedDate = new DateTime(), ModifiedDate = new DateTime() },
            new NewsItem { Id = 20, Title = "Bla", ImgSource = "", ShortDescription = "Once upon a time...", LongDescription = "Once upon a time there lived a wizard", PublishDate = new DateTime(), ModifiedBy = "TechnicalRadiationAdmin", CreatedDate = new DateTime(), ModifiedDate = new DateTime() },
            new NewsItem { Id = 21, Title = "Bla", ImgSource = "", ShortDescription = "Once upon a time...", LongDescription = "Once upon a time there lived a wizard", PublishDate = new DateTime(), ModifiedBy = "TechnicalRadiationAdmin", CreatedDate = new DateTime(), ModifiedDate = new DateTime() },
            new NewsItem { Id = 22, Title = "Bla", ImgSource = "", ShortDescription = "Once upon a time...", LongDescription = "Once upon a time there lived a wizard", PublishDate = new DateTime(), ModifiedBy = "TechnicalRadiationAdmin", CreatedDate = new DateTime(), ModifiedDate = new DateTime() },
            new NewsItem { Id = 23, Title = "Bla", ImgSource = "", ShortDescription = "Once upon a time...", LongDescription = "Once upon a time there lived a wizard", PublishDate = new DateTime(), ModifiedBy = "TechnicalRadiationAdmin", CreatedDate = new DateTime(), ModifiedDate = new DateTime() },
            new NewsItem { Id = 24, Title = "Bla", ImgSource = "", ShortDescription = "Once upon a time...", LongDescription = "Once upon a time there lived a wizard", PublishDate = new DateTime(), ModifiedBy = "TechnicalRadiationAdmin", CreatedDate = new DateTime(), ModifiedDate = new DateTime() },
            new NewsItem { Id = 25, Title = "Bla", ImgSource = "", ShortDescription = "Once upon a time...", LongDescription = "Once upon a time there lived a wizard", PublishDate = new DateTime(), ModifiedBy = "TechnicalRadiationAdmin", CreatedDate = new DateTime(), ModifiedDate = new DateTime() },
            new NewsItem { Id = 26, Title = "Bla", ImgSource = "", ShortDescription = "Once upon a time...", LongDescription = "Once upon a time there lived a wizard", PublishDate = new DateTime(), ModifiedBy = "TechnicalRadiationAdmin", CreatedDate = new DateTime(), ModifiedDate = new DateTime() },
            new NewsItem { Id = 27, Title = "Bla", ImgSource = "", ShortDescription = "Once upon a time...", LongDescription = "Once upon a time there lived a wizard", PublishDate = new DateTime(), ModifiedBy = "TechnicalRadiationAdmin", CreatedDate = new DateTime(), ModifiedDate = new DateTime() },
            new NewsItem { Id = 28, Title = "Bla", ImgSource = "", ShortDescription = "Once upon a time...", LongDescription = "Once upon a time there lived a wizard", PublishDate = new DateTime(), ModifiedBy = "TechnicalRadiationAdmin", CreatedDate = new DateTime(), ModifiedDate = new DateTime() },
            new NewsItem { Id = 29, Title = "Bla", ImgSource = "", ShortDescription = "Once upon a time...", LongDescription = "Once upon a time there lived a wizard", PublishDate = new DateTime(), ModifiedBy = "TechnicalRadiationAdmin", CreatedDate = new DateTime(), ModifiedDate = new DateTime() },
            new NewsItem { Id = 30, Title = "Bla", ImgSource = "", ShortDescription = "Once upon a time...", LongDescription = "Once upon a time there lived a wizard", PublishDate = new DateTime(), ModifiedBy = "TechnicalRadiationAdmin", CreatedDate = new DateTime(), ModifiedDate = new DateTime() }
        };
    }
}