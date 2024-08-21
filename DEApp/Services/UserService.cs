using DEApp.Interfaces;
using DEApp.Models;
using DEApp.Models.DTOs;
using DEApp.Services;
using DEApp.Utilities;
using System.Security.Cryptography;
using System.Text;

namespace DEApp.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository<string, User> _userRepository;
        private readonly ITokenService _tokenSevice;

        public UserService(IUserRepository<string, User> repository, ITokenService tokenService)
        {
            _userRepository = repository;
            _tokenSevice = tokenService;
        }


        #region login
        public UserDTO Login(UserDTO userDTO)
        {
            var user = _userRepository.Get(userDTO.UserName);
            if (user != null)
            {
                var dbPass = user.Password;
                HMACSHA512 hMACSHA512 = new HMACSHA512(user.Key);
                var userPass = hMACSHA512.ComputeHash(Encoding.UTF8.GetBytes(userDTO.Password));
                if (userPass.Length == dbPass.Length)
                {
                    for (int i = 0; i < dbPass.Length; i++)
                    {
                        if (userPass[i] != dbPass[i])
                            return null;
                    }
                    var loggedinUser = new UserDTO
                    {
                        UserName = user.UserName,
                        Token = _tokenSevice.GenerateToken(user.UserName),
                        RoleId=user.RoleId,

                    };
                    return loggedinUser;
                }
            }
            throw new InvalidUserName();
        }
        #endregion
        #region Registration
        public UserDTO Register(UserDTO userDTO)
        {
            HMACSHA512 hMACSHA512 = new HMACSHA512();
            User user = new User();
            user.UserName = userDTO.UserName;
            user.Password = hMACSHA512.ComputeHash(Encoding.UTF8.GetBytes(userDTO.Password));
         
            user.Key = hMACSHA512.Key;
       
            var data = _userRepository.Add(user);
            var regiteredUser = new UserDTO
            {
                UserName = user.UserName,
                Token = _tokenSevice.GenerateToken(user.UserName)
            };
            return regiteredUser;
        }
        #endregion
    }
}
