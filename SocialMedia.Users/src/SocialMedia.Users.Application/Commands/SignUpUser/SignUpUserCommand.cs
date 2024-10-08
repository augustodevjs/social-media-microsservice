﻿using MediatR;
using SocialMedia.Users.Domain.Entities;

namespace SocialMedia.Users.Application.Commands.SignUpUser;

public class SignUpUserCommand : IRequest
{
    public string FullName { get; set; }
    public string DisplayName { get; set; }
    public DateTime BirthDate { get; set; }
    public string Email { get; set; }

    public User ToEntity() => new(Email, FullName, DisplayName, BirthDate);
}
