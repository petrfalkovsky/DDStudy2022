using Api.Models;
using AutoMapper;
using DAL;
using DAL.Entites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Services
{
    public class PostService
    {
        private readonly DAL.DataContext _context;
        private readonly IMapper _mapper;

        public PostService (DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddPost(Guid userId, CreatePostModel model, Dictionary<MetadataModel, string> filePaths)
        {
            var user = await _context.Users.Include(x => x.Posts).ThenInclude(y => y.PostPictures).FirstOrDefaultAsync(x => x.Id == userId);
            if (user != null)
            {
                var dbPost = _mapper.Map<DAL.Entites.Post>(model);
                dbPost.User = user;

                await _context.Posts.AddAsync(dbPost);
                await _context.SaveChangesAsync();

                if (filePaths.Count > 0)
                {
                    foreach (var filePath in filePaths)
                    {
                        await AddPictureToPost(dbPost, filePath.Key, filePath.Value);
                    }
                }
            }
        }

        private async Task AddPictureToPost(Post post, MetadataModel meta, string filePath)
        {
            var postPicture = new PostPicture { Author = post.User, MimeType = meta.MimeType, FilePath = filePath, Name = meta.Name, Size = meta.Size };
            postPicture.Post = post;

            await _context.PostPictures.AddAsync(postPicture);
            await _context.SaveChangesAsync();
        }
    }
}
