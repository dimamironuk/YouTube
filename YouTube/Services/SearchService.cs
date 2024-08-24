using Core.Dtos;
using Core.Interfaces;
using Data.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace YouTube.Services
{
    public class SearchService : ISearchService
    {
        private readonly YouTubeDbContext _context;

        public SearchService(YouTubeDbContext context)
        {
            _context = context;
        }

        public List<SearchResultDto> Search(string query)
        {
            var videoResults = _context.Videos
                .Where(v => v.Title.Contains(query))
                .Select(v => new SearchResultDto
                {
                    Id = v.Id,
                    Title = v.Title,
                    Description = v.Description,
                    Result = v.PreviewUrl,
                    Type = "Video" 
                })
                .ToList();

            var userResults = _context.Users
                .Where(u => u.Nickname.Contains(query))
                .Select(u => new SearchResultDto
                {
                    Id = u.Id.ToString(),
                    Title = u.Nickname,
                    Description = null,
                    Result = u.AvatarUrl,
                    Type = "User" 
                })
                .ToList();

            return videoResults.Concat(userResults).ToList();
        }

    }
}
