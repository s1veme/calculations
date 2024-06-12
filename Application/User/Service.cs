using GeoApp.Domain;
using GeoApp.Infrastructure.Repositories;
using System;
using System.Text.RegularExpressions;

public class UserService
{
    private readonly UserRepository _userRepository;

    private static UserService instance;

    public static UserService GetInstance()
    {
        return instance;
    }

    public UserService(UserRepository userRepository)
    {
        _userRepository = userRepository;
        instance = this;
    }

    public bool RegisterUser(string email, string password, string phoneNumber)
    {
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(phoneNumber))
        {
            throw new ArgumentException("Все поля должны быть заполнены.");
        }

        if (!IsValidEmail(email))
        {
            throw new ArgumentException("Неверный формат адреса электронной почты.");
        }

        if (!IsValidPhoneNumber(phoneNumber))
        {
            throw new ArgumentException("Неверный формат телефонного номера.");
        }

        var existingUser = _userRepository.GetUserByEmail(email);
        if (existingUser != null)
        {
            throw new InvalidOperationException("Пользователь с таким адресом электронной почты уже существует.");
        }

        var user = new User
        {
            Email = email,
            Password = password,
            PhoneNumber = phoneNumber,
            Role = "Инженер"
        };

        _userRepository.AddUser(user);
        return true;
    }

    public User LoginUser(string email, string password)
    {
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            throw new ArgumentException("Email и пароль должны быть заполнены.");
        }

        var user = _userRepository.GetUserByEmail(email);
        if (user == null)
        {
            throw new InvalidOperationException("Пользователь с таким email не найден.");
        }

        if (user.Password != password)
        {
            throw new InvalidOperationException("Неверный пароль.");
        }

        return user;
    }

    private bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }

    private bool IsValidPhoneNumber(string phoneNumber)
    {
        string pattern = @"^\+\d{11}$";
        return Regex.IsMatch(phoneNumber, pattern);
    }
}
