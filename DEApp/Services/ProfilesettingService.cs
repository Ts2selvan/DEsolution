using DEApp.Interfaces;
using DEApp.Models;
using DEApp.Models.DTOs;
using DEApp.Repositories;
using System.Data;

namespace DEApp.Services
{
    public class ProfilesettingService : IProfilesettingService
    {
        private readonly IProfilesettingRepository<int, ProfileSetting> _profilesettingRepository;
        private readonly IRoleRepository<string, Role> _roleRepository;
        private readonly IUserRepository<string, User> _userRepository;
       
        public ProfilesettingService(IProfilesettingRepository<int, ProfileSetting> profilesettingRepository, IRoleRepository<string, Role> roleRepository, IUserRepository<string, User> userRepository) 
        {
            _profilesettingRepository = profilesettingRepository;
            _roleRepository = roleRepository;
            _userRepository = userRepository;
        }

        public ProfileSettingDTO AddUserProfile(ProfileSettingDTO profileSettingDTO)
        {
            try
            {
                var userName = _userRepository.Get(profileSettingDTO.Username);
                if (userName != null) 
                {
                var role = _roleRepository.Get(profileSettingDTO.Role);
                if (role != null)
                {
                    var prflUserName= _profilesettingRepository.GetUserName(profileSettingDTO.Username);
                        if(prflUserName != null)
                        {

                            var profileSetting = new ProfileSetting
                            {
                                Email = profileSettingDTO.Email,
                                FirstName = profileSettingDTO.FirstName,
                                LastName = profileSettingDTO.LastName,
                                Username = profileSettingDTO.Username,
                                MobileNumber = profileSettingDTO.MobileNumber,
                                RoleId = role.RoleId
                            };
                            _profilesettingRepository.UpdatePrfl(profileSetting, prflUserName.UserId);
                            _userRepository.UpdateRoleId(role.RoleId, profileSetting.Username);
                            return new ProfileSettingDTO
                            {
                                ProfileSettingId = profileSetting.UserId,
                                Email = profileSetting.Email,
                                FirstName = profileSetting.FirstName,
                                LastName = profileSetting.LastName,
                                Username = profileSetting.Username,
                                MobileNumber = profileSetting.MobileNumber,
                                RoleId = profileSetting.RoleId,
                                Role = role.RoleName
                            };
                        }
                        else
                        {
                            var profileSetting = new ProfileSetting
                            {
                                Email = profileSettingDTO.Email,
                                FirstName = profileSettingDTO.FirstName,
                                LastName = profileSettingDTO.LastName,
                                Username = profileSettingDTO.Username,
                                MobileNumber = profileSettingDTO.MobileNumber,
                                RoleId = role.RoleId
                            };
                            _profilesettingRepository.Add(profileSetting);
                            _userRepository.UpdateRoleId(role.RoleId, profileSetting.Username);
                            return new ProfileSettingDTO
                            {
                                ProfileSettingId = profileSetting.UserId,
                                Email = profileSetting.Email,
                                FirstName = profileSetting.FirstName,
                                LastName = profileSetting.LastName,
                                Username = profileSetting.Username,
                                MobileNumber = profileSetting.MobileNumber,
                                RoleId = profileSetting.RoleId,
                                Role = role.RoleName
                            };
                        }

                 
                       
                   
                   
                  

                }
                
                }
                return new ProfileSettingDTO { };
                
               
            }
            catch (Exception)
            {

                throw;
            }




        }

        public ProfileSettingDTO DeleteUserProfileById(int profileSettingId)
        {
            var profileSetting = _profilesettingRepository.Get(profileSettingId);
            if (profileSetting == null)
            {
                return null;
            }

            _profilesettingRepository.Delete(profileSettingId);

            return new ProfileSettingDTO
            {
                ProfileSettingId = profileSetting.UserId,
                Email = profileSetting.Email,
                FirstName = profileSetting.FirstName,
                LastName = profileSetting.LastName,
                Username = profileSetting.Username,
                MobileNumber = profileSetting.MobileNumber,
                RoleId = profileSetting.RoleId
            };
        }

       

        public List<ProfileSettingDTO> GetAllUserProfiles()
        {
            var profileSettings = _profilesettingRepository.GetAll()
                .Select(profileSetting => new ProfileSettingDTO
                {
                    ProfileSettingId = profileSetting.UserId,
                    Email = profileSetting.Email,
                    FirstName = profileSetting.FirstName,
                    LastName = profileSetting.LastName,
                    Username = profileSetting.Username,
                    MobileNumber = profileSetting.MobileNumber,
                    RoleId = profileSetting.RoleId
                }).ToList();

            return profileSettings;
        }

        public ProfileSettingDTO GetUserProfileById(int profileSettingId)
        {
            var profileSetting = _profilesettingRepository.Get(profileSettingId);
            if (profileSetting == null)
            {
                return null;
            }

            return new ProfileSettingDTO
            {
                ProfileSettingId = profileSetting.UserId,
                Email = profileSetting.Email,
                FirstName = profileSetting.FirstName,
                LastName = profileSetting.LastName,
                Username = profileSetting.Username,
                MobileNumber = profileSetting.MobileNumber,
                RoleId = profileSetting.RoleId
            };
        }

        public ProfileSettingDTO UpdateUserProfile(ProfileSettingDTO profileSettingDTO)
        {
            var profileSetting = _profilesettingRepository.Get(profileSettingDTO.ProfileSettingId);
            if (profileSetting == null)
            {
                return null;
            }

            profileSetting.Email = profileSettingDTO.Email;
            profileSetting.FirstName = profileSettingDTO.FirstName;
            profileSetting.LastName = profileSettingDTO.LastName;
            profileSetting.Username = profileSettingDTO.Username;
            profileSetting.MobileNumber = profileSettingDTO.MobileNumber;
            profileSetting.RoleId = profileSettingDTO.RoleId;

            _profilesettingRepository.Update(profileSetting);

            return new ProfileSettingDTO
            {
                ProfileSettingId = profileSetting.UserId,
                Email = profileSettingDTO.Email,
                FirstName = profileSettingDTO.FirstName,
                LastName = profileSettingDTO.LastName,
                Username = profileSettingDTO.Username,
                MobileNumber = profileSettingDTO.MobileNumber,
                RoleId = profileSettingDTO.RoleId
            };
        }

       
    }
}
