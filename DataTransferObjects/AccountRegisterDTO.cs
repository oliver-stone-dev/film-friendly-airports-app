﻿namespace film_friendly_airports_app.DataTransferObjects;

public class AccountRegisterDTO
{
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? DisplayName { get; set; }
}