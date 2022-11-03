using Api.Configs;
using Api.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Common;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Api.Services
{
    public class UserService
    {
        private readonly IMapper _mapper;
        private readonly DAL.DataContext _context;
        private readonly AuthConfig _config;

        public UserService(IMapper mapper, DataContext context, IOptions<AuthConfig> config)
        {
            _mapper = mapper;
            _context = context;
            _config = config.Value;
        }

        public async Task CreateUser(CreateUserModel model)
        {
            var dbUser = _mapper.Map<DAL.Entities.Uzer>(model);
            await _context.User.AddAsync(dbUser);
            await _context.SaveChangesAsync();
        }

        public async Task<List<UserModel>> GetUsers()
        {
            return await _context.User.AsNoTracking().ProjectTo<UserModel>(_mapper.ConfigurationProvider).ToListAsync();
        }

        private async Task<DAL.Entities.Uzer> GetUzerCredenton(string login, string password)
        {
            var user = await _context.User.FirstOrDefaultAsync(x => x.Email == login);
            if (user == null)
            
                throw new Exception("user not found");

                if (!HashHelper.Verify(password, user.PasswordHash))
               
                    throw new Exception("password is incorrect");
            
                return user;
            
        }
        public async Task<TokenModel> GetToken (string login, string password)
        {
            var user = await GetUzerCredenton(login, password);

            var claimes = new Claim[]
            {
                // имейл в токенах лучше не хранить
                // new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim("displayName", user.Name),
                new Claim("id", user.Id.ToString()),
            };

            var dtNow = DateTime.Now;

            var jwt = new JwtSecurityToken(
                issuer: _config.Issuer,
                audience: _config.Audience,
                notBefore: dtNow,
                claims: claimes,
                expires: DateTime.Now.AddMinutes(_config.LifeTime),
                signingCredentials: new SigningCredentials(_config.SymmetricSecurityKey(), SecurityAlgorithms.HmacSha256)
                );
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new TokenModel(encodedJwt);

        }
    }
}
