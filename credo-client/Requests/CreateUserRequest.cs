﻿namespace credo_client.Requests;

public class CreateUserRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string PersonalId { get; set; }
    public DateTime BirthDate { get; set; }
    
}