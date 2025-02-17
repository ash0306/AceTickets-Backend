﻿using AutoMapper;
using MovieBookingBackend.Exceptions.User;
using MovieBookingBackend.Interfaces;
using MovieBookingBackend.Models;
using MovieBookingBackend.Models.DTOs.Users;
using MovieBookingBackend.Models.Enums;

namespace MovieBookingBackend.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<int, User> _repository;
        private readonly ILogger<UserService> _logger;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="repository">The repository instance used for user data access.</param>
        /// <param name="logger">The logger instance for logging operations.</param>
        /// <param name="mapper">The AutoMapper instance for object mapping.</param>
        public UserService(IRepository<int, User> repository, ILogger<UserService> logger, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves all users with the Admin role.
        /// </summary>
        /// <returns>A list of <see cref="UserDTO"/> objects representing admin users.</returns>
        /// <exception cref="NoUsersFoundException">Thrown if no admin users are found.</exception>
        public async Task<IEnumerable<UserDTO>> GetAllAdminUserDetails()
        {
            try
            {
                var users = (await _repository.GetAll()).Where(u => u.Role == UserRole.Admin);
                if (users.Count() <= 0)
                {
                    throw new NoUsersFoundException("No users found");
                }

                IList<UserDTO> userDTOs = new List<UserDTO>();
                foreach (var item in users)
                {
                    var result = _mapper.Map<UserDTO>(item);
                    userDTOs.Add(result);
                }
                return userDTOs;
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"No Users found. {ex}");
                throw new NoUsersFoundException($"No users found. {ex.Message}");
            }
        }

        /// <summary>
        /// Retrieves all users regardless of role.
        /// </summary>
        /// <returns>A list of <see cref="UserDTO"/> objects representing all users.</returns>
        /// <exception cref="NoUsersFoundException">Thrown if no users are found.</exception>
        public async Task<IEnumerable<UserDTO>> GetAllUsers()
        {
            try
            {
                var users = await _repository.GetAll();
                if(users.Count() <= 0)
                {
                    throw new NoUsersFoundException("No users found");
                }

                IList<UserDTO> userDTOs = new List<UserDTO>();
                foreach (var item in users)
                {
                    var result = _mapper.Map<UserDTO>(item);
                    userDTOs.Add(result);
                }
                return userDTOs;
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"No Users found. {ex}");
                throw new NoUsersFoundException($"No users found. {ex.Message}");
            }
        }

        /// <summary>
        /// Retrieves all users with the User role.
        /// </summary>
        /// <returns>A list of <see cref="UserDTO"/> objects representing regular users.</returns>
        /// <exception cref="NoUsersFoundException">Thrown if no regular users are found.</exception>
        public async Task<IEnumerable<UserDTO>> GetAllUserDetails()
        {
            try
            {
                var users = (await _repository.GetAll()).Where(u => u.Role == UserRole.User);
                if (users.Count() <= 0)
                {
                    throw new NoUsersFoundException("No users found");
                }

                IList<UserDTO> userDTOs = new List<UserDTO>();
                foreach (var item in users)
                {
                    var result = _mapper.Map<UserDTO>(item);
                    userDTOs.Add(result);
                }
                return userDTOs;
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"No Users found. {ex}");
                throw new NoUsersFoundException($"No users found. {ex.Message}");
            }
        }

        /// <summary>
        /// Retrieves a user by their email address.
        /// </summary>
        /// <param name="email">The email address of the user to retrieve.</param>
        /// <returns>A <see cref="UserDTO"/> object representing the user.</returns>
        /// <exception cref="NoSuchUserException">Thrown if no user with the given email is found.</exception>
        public async Task<UserDTO> GetUserByEmail(string email)
        {
            try
            {
                var user = (await _repository.GetAll()).FirstOrDefault(u => u.Email == email);
                if (user == null)
                {
                    throw new NoSuchUserException($"No user with email {email} was found");
                }

                UserDTO userDTO = _mapper.Map<UserDTO>(user);
                
                return userDTO;
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"No User found. {ex}");
                throw new NoSuchUserException($"No user with email {email} found. {ex.Message}");
            }
        }

        /// <summary>
        /// Retrieves a user by their ID.
        /// </summary>
        /// <param name="id">The ID of the user to retrieve.</param>
        /// <returns>A <see cref="UserDTO"/> object representing the user.</returns>
        /// <exception cref="NoSuchUserException">Thrown if no user with the given ID is found.</exception>
        public async Task<UserDTO> GetUserById(int id)
        {
            try
            {
                var user = (await _repository.GetAll()).FirstOrDefault(u => u.Id == id);
                if (user == null)
                {
                    throw new NoSuchUserException($"No user with ID {id} was found");
                }

                UserDTO userDTO = _mapper.Map<UserDTO>(user);

                return userDTO;
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"No User found. {ex}");
                throw new NoSuchUserException($"No user with ID {id} found. {ex.Message}");
            }
        }

        /// <summary>
        /// Updates user information based on the provided details.
        /// </summary>
        /// <param name="updateUserDTO">The details to update for the user.</param>
        /// <returns>A <see cref="UserDTO"/> object representing the updated user.</returns>
        /// <exception cref="NoSuchUserException">Thrown if no user with the given ID is found.</exception>
        public async Task<UserDTO> UpdateUser(UpdateUserDTO updateUserDTO)
        {
            try
            {
                var user = (await _repository.GetAll()).FirstOrDefault(u => u.Id == updateUserDTO.Id);
                if (user == null)
                {
                    throw new NoSuchUserException($"No user with ID {updateUserDTO.Id} was found");
                }

                if(!string.IsNullOrEmpty(updateUserDTO.PhoneNumber))
                {
                    user.Phone = updateUserDTO.PhoneNumber;
                }

                var result = await _repository.Update(user);

                UserDTO userDTO = _mapper.Map<UserDTO>(result);

                return userDTO;
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"No User found. {ex}");
                throw new NoSuchUserException($"No user with ID {updateUserDTO.Id} found. {ex.Message}");
            }
        }
    }
}
