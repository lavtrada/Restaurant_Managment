﻿using System.ComponentModel.DataAnnotations;

namespace FoodApp.Areas.Auth.Models;

public class SignIn
{
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
}