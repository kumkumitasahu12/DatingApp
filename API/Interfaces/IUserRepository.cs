using System;
using API.DTOS;
using API.Entities;

namespace API.Interfaces;

public interface IUserRepository
{
    void Update(AppUser user);
    Task<bool> SaveAllAsync();
    Task<IEnumerable<AppUser>> GerUsersAsync();
    Task<AppUser?> GetUserByIdAsync(int id);
    Task<AppUser?> GetUserByUsernameAsync(string username);

    Task<MemberDto?> GetMemberAsync(string username);
    Task<IEnumerable<MemberDto>> GetMembersAsync();
}
